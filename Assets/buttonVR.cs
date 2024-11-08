using System.Collections;
using UnityEngine;
using UnityEngine.Events;


public class buttonVR : MonoBehaviour
{
    public GameObject button;
    public UnityEvent onPress;
    public UnityEvent onRelease;
    GameObject presser;
    bool isPressed;
    public Animator animator2;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        isPressed = false;
    }

    private void OnTriggerEnter(Collider other)
    {
        if(!isPressed)
        {
            button.transform.localPosition = new Vector3(0, 0.003f, 0);
            presser = other.gameObject;
            onPress.Invoke();
            isPressed = true;
            TriggerDoorOpen();
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if(other == presser)
        {
            button.transform.localPosition = new Vector3(0, 0.015f, 0);
            onRelease.Invoke();
            isPressed = false;
        }
    }
    public void TriggerDoorOpen()
    {
        if(animator2 != null)
        {
            animator2.SetTrigger("CollisionComplete");
        }
    }
    // Update is called once per frame

}
