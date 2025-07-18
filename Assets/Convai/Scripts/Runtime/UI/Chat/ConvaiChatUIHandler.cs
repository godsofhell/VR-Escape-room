using System;
using System.Collections.Generic;
using System.Linq;
using Convai.Scripts.Runtime.Addons;
using Convai.Scripts.Runtime.Attributes;
using Convai.Scripts.Runtime.Core;
using Convai.Scripts.Runtime.LoggerSystem;
using Convai.Scripts.Runtime.PlayerStats;
using UnityEngine;

namespace Convai.Scripts.Runtime.UI
{
    [AddComponentMenu("Convai/Chat UI Handler")]
    [DisallowMultipleComponent]
    [DefaultExecutionOrder(-100)]
    public class ConvaiChatUIHandler : MonoBehaviour
    {
        /// <summary>
        ///     Enum to represent different UI types.
        /// </summary>
        public enum UIType
        {
            ChatBox,
            QuestionAnswer,
            Subtitle
        }
        

        [Header("UI Prefabs")] [Tooltip("Prefab for the chat box UI.")]
        public GameObject chatBoxPrefab;

        [Tooltip("Prefab for the subtitle UI.")]
        public GameObject subtitlePrefab;

        [Tooltip("Prefab for the question-answer UI.")]
        public GameObject questionAnswerPrefab;

        [Header("Character List")] [Tooltip("List of characters.")]
        public List<Character> characters = new();

        [ColorUsage(true)] [Tooltip("Color of the player's text. Alpha value will be ignored.")]
        public Color playerTextColor = Color.white;

        private ConvaiPlayerDataSO _convaiPlayerData;

        private IChatUI _currentUIImplementation;

        private bool _hasPlayerData;
        public static ConvaiChatUIHandler Instance { get; private set; }

        public Dictionary<UIType, IChatUI> GetUIAppearances { get; } = new();

        private void Awake()
        {
            if (Instance != null)
            {
                // Log a warning and destroy the duplicate instance
                ConvaiLogger.DebugLog("<color=red> There's More Than One ConvaiChatUIHandler </color> " + transform + " - " + Instance, ConvaiLogger.LogCategory.UI);
                Destroy(gameObject);
                return;
            }

            // Set the singleton instance
            Instance = this;

            ValidateUIPrefabs();
            InitializeUIStrategies();

            _hasPlayerData = ConvaiPlayerDataSO.GetPlayerData(out _convaiPlayerData);
        }

        // Subscribe to events when this component is enabled.
        private void OnEnable()
        {
            // Subscribe to the event when saved data is loaded.
            UISaveLoadSystem.Instance.OnLoad += UISaveLoadSystem_OnLoad;

            // Subscribe to the event when data is saved.
            UISaveLoadSystem.Instance.OnSave += UISaveLoadSystem_OnSave;
        }

        // Unsubscribe from events when this component is disabled.
        private void OnDisable()
        {
            // Unsubscribe from the event when saved data is loaded.
            UISaveLoadSystem.Instance.OnLoad -= UISaveLoadSystem_OnLoad;

            // Unsubscribe from the event when data is saved.
            UISaveLoadSystem.Instance.OnSave -= UISaveLoadSystem_OnSave;
        }

        private void OnDestroy()
        {
            SaveUIType();
        }

        private void OnValidate()
        {
            UpdateCharacterList();
            RemoveDuplicateCharacters();
        }


        /// <summary>
        ///     Updates the character list by synchronizing names between Convai Transcript UI Character list and NPC
        ///     characterName, removing null characters, and adding missing characters.
        /// </summary>
        public void UpdateCharacterList()
        {
            // Synchronize names between Convai Transcript UI Character list and NPC characterName 
            for (int i = 0; i < characters.Count; i++)
            {
                Character character = characters[i];
                // If the character's game object is missing, remove it from the list
                if (character.characterGameObject == null)
                    characters.Remove(character);
                else
                    // Update the character's name using the game object's characterName
                    character.characterName = character.characterGameObject.characterName;
            }

            // Remove null characters
            characters = characters.Where(c => c.characterGameObject != null).ToList();

            // Add missing characters
            foreach (ConvaiNPC convaiNpc in FindObjectsOfType<ConvaiNPC>())
            {
                if (characters.Any(c => c.characterGameObject == convaiNpc))
                    continue;

                characters.Add(new Character
                {
                    characterGameObject = convaiNpc,
                    characterName = convaiNpc.characterName
                });
            }
        }

        /// <summary>
        ///     Removes duplicate characters from the character list based on their GameObject.
        /// </summary>
        private void RemoveDuplicateCharacters()
        {
            characters = characters
                .GroupBy(c => c.characterGameObject)
                .Select(g => g.First())
                .ToList();
        }

        /// <summary>
        ///     Event handler when saved data is loaded.
        /// </summary>
        private void UISaveLoadSystem_OnLoad()
        {
            _currentUIImplementation = GetChatUIByUIType(UISaveLoadSystem.Instance.UIType);
            SetUIType(UISaveLoadSystem.Instance.UIType);
            _currentUIImplementation.ActivateUI();
        }

        /// <summary>
        ///     Event handler when data is saved.
        /// </summary>
        private void UISaveLoadSystem_OnSave()
        {
            SaveUIType();
        }

        /// <summary>
        ///     Initializes the UI with the given prefab and UI type.
        /// </summary>
        private void InitializeUIStrategies()
        {
            InitializeUI(chatBoxPrefab, UIType.ChatBox);
            InitializeUI(questionAnswerPrefab, UIType.QuestionAnswer);
            InitializeUI(subtitlePrefab, UIType.Subtitle);
        }

        private void InitializeUI(GameObject uiPrefab, UIType uiType)
        {
            try
            {
                IChatUI uiComponent = uiPrefab.GetComponent<IChatUI>();
                if (uiComponent == null)
                {
                    ConvaiLogger.Warn($"The provided prefab for {uiType} does not have a component that implements IChatUI.", ConvaiLogger.LogCategory.UI);
                    return;
                }

                uiComponent.Initialize(uiPrefab);
                GetUIAppearances[uiType] = uiComponent;
            }
            catch (Exception ex)
            {
                ConvaiLogger.Exception($"An error occurred while initializing the UI: {ex.Message}", ConvaiLogger.LogCategory.UI);
            }
        }

        /// <summary>
        ///     Sends character text to the current UI.
        /// </summary>
        /// <param name="charName">The character's name.</param>
        /// <param name="text">The text to send.</param>
        /// 
         public delegate void TextSentEventHandler(string text);
        public static event TextSentEventHandler OnTextSent;
        public void SendCharacterText(string charName, string text)
        {
            Character character = characters.Find(c => c.characterName == charName);
            if (character == null)
            {
                ConvaiLogger.Warn($"No character found named {charName}", ConvaiLogger.LogCategory.Character);
                return;
            }

            if (!ConvaiNPCManager.Instance.CheckForNPCToNPCConversation(character.characterGameObject))
            { 
            _currentUIImplementation?.SendCharacterText(charName, text, character.CharacterTextColor);
            OnTextSent?.Invoke(text);
        }
            else
                ConvaiLogger.DebugLog($"Character {charName} is in conversation with another NPC.", ConvaiLogger.LogCategory.Character);
        }
        //public delegate void TextSentEventHandler(string text);
        //public static event TextSentEventHandler OnTextSent;
        /// <summary>
        ///     Sends player text to the current UI.
        /// </summary>
        /// <param name="text">The text to send.</param>
        public void SendPlayerText(string text)
        {
            _currentUIImplementation?.SendPlayerText(_hasPlayerData ? _convaiPlayerData.PlayerName : _convaiPlayerData.DefaultPlayerName, text, playerTextColor);
            //OnTextSent?.Invoke(text);
        }

        /// <summary>
        ///     Validates that all UI prefabs are assigned.
        /// </summary>
        private void ValidateUIPrefabs()
        {
            try
            {
                if (chatBoxPrefab == null || subtitlePrefab == null || questionAnswerPrefab == null)
                    throw new InvalidOperationException("All UI prefabs must be assigned in the inspector.");
            }
            catch (InvalidOperationException ex)
            {
                ConvaiLogger.Exception($"An error occurred while validating UI prefabs: {ex.Message}", ConvaiLogger.LogCategory.UI);
            }
        }

        /// <summary>
        ///     Sets the current UI type and fades between UIs.
        /// </summary>
        /// <param name="newUIType">The new UI type to set.</param>
        public void SetUIType(UIType newUIType)
        {
            if (!GetUIAppearances.ContainsKey(newUIType))
            {
                ConvaiLogger.Warn($"The UI type {newUIType} is not available.", ConvaiLogger.LogCategory.UI);
                return;
            }

            _currentUIImplementation = GetUIAppearances[newUIType];
        }

        private void SaveUIType()
        {
            foreach (KeyValuePair<UIType, IChatUI> strategy in GetUIAppearances.Where(strategy =>
                         strategy.Value == _currentUIImplementation))
            {
                UISaveLoadSystem.Instance.UIType = strategy.Key;
                break;
            }
        }

        public IChatUI GetChatUIByUIType(UIType uiType)
        {
            return GetUIAppearances[uiType];
        }

        /// <summary>
        ///     Gets the current UI implementation.
        /// </summary>
        /// <returns>The current IChatUI implementation.</returns>
        public IChatUI GetCurrentUI()
        {
            return _currentUIImplementation;
        }

        public bool HasCharacter(string convaiNPCCharacterName)
        {
            return characters.Any(character => character.characterName == convaiNPCCharacterName);
        }

        public void AddCharacter(Character newCharacter)
        {
            characters.Add(newCharacter);
        }
    }
}

namespace Convai.Scripts.Runtime.Addons
{
    [Serializable]
    public class Character
    {
        [Header("Character settings")] [Tooltip("Convai NPC Game Object")]
        public ConvaiNPC characterGameObject;

        [ReadOnly] [Tooltip("Display name of the NPC")]
        public string characterName = "Character";

        [ColorUsage(true)] [Tooltip("Color of the NPC text. Alpha value will be ignored.")] [SerializeField]
        private Color characterTextColor = Color.red;

        public Color CharacterTextColor
        {
            get => characterTextColor;
            set => characterTextColor = value;
        }
    }
}