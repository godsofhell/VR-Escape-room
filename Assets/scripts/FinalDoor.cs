using UnityEngine;

public class FinalDoor : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public Transfer trans;
    int count = 0;
    public GameObject Door;

    
    void Start()
    {
       // trans = gameObject.AddComponent<Transfer>();
        //if (trans.ChatText.object != null)
        
            //Debug.Log("not null");
           // counter();
        
    }
     void Update()
    {
        counter();
    }
    public void counter()
    {
        //trans.ExtractChatText(text);
        //trans.RedirectPlayerMessage();
        string[] WordsToLook = { "Congratulations", "well done", "awesome", "outstanding", "excellent" };
    //string[] words = ChatText.Split('');

        foreach(string word in WordsToLook)
        {
           if(trans.ChatText.Contains(word))
            {
                count++;
                Debug.Log("count is " + count);
                break;
                
               
                
            }
            if(count>=4)
            {
                Destroy(Door,2f); 
            }
        }
    }

}
