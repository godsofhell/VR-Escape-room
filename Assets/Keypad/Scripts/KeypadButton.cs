using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace NavKeypad
{
    public class KeypadButton : MonoBehaviour
    {
        [Header("Value")]
        [SerializeField] private string value;
        [Header("Button Animation Settings")]
        [SerializeField] private float bttnspeed = 0.1f;
        [SerializeField] private float moveDist = 0.0025f;
        [SerializeField] private float buttonPressedTime = 0.1f;
        [Header("Component References")]
        [SerializeField] private Keypad keypad;
        public Animator press;


        public void PressButton()
        {
            // if button is pressed then moving is false then keypad will enter value and MoveSmooth function will start 
            if (!moving)
            {
                keypad.AddInput(value);
                StartCoroutine(MoveSmooth());
                Debug.Log("value entered");
                press.SetTrigger("press1");
            }
        }
        private bool moving;

        private IEnumerator MoveSmooth()
        {

            moving = true;
            Vector3 startPos = transform.localPosition;
            Vector3 endPos = transform.localPosition + new Vector3(0, 0, moveDist);

            float elapsedTime = 0;
            while (elapsedTime < bttnspeed)
            {
                elapsedTime += Time.deltaTime;
                // Math.Clamp01 is used to restrict a value between 0 and 1, if the input value is less than 0 it returns 0 if the valje is greater 1 it returns 1
                float t = Mathf.Clamp01(elapsedTime / bttnspeed);
                // this line is used to smoothly interpolate between 2 positions "startPos" and "EndPos" based on value of "t"
                transform.localPosition = Vector3.Lerp(startPos, endPos, t);

                yield return null;
            }
            transform.localPosition = endPos;
            yield return new WaitForSeconds(buttonPressedTime);
            startPos = transform.localPosition;
            endPos = transform.localPosition - new Vector3(0, 0, moveDist);

            elapsedTime = 0;
            

            moving = false;
        }
    }
}