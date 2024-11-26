using UnityEngine;
//using System.Collections.Generic;


public class ButtonPush : MonoBehaviour
{
    public GameObject light1;
    public GameObject light2;
    public GameObject light3;
    //public Restart res;
    //public List<GameObject> objects;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        GetComponent<UnityEngine.XR.Interaction.Toolkit.Interactables.XRSimpleInteractable>().selectEntered.AddListener(x => Push());
        //res = GetComponent<Restart>();
        //res.mr.enabled = false;
     }
    public void Push()
    {
        light1.SetActive(true);
        light2.SetActive(true);
        light3.SetActive(true);
        //.foreach (GameObject obj in objects)
        
            //res.mr.enabled = true;
        
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
