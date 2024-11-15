using UnityEngine;

public class DoorOpening : MonoBehaviour
{
    public Animator animator2;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private void OnTriggerEnter(Collider other)
    {

        animator2.SetBool("CollisionComplete", true);
        UnityEngine.Debug.Log("door opened");
    }
    private void OnTriggerExit(Collider other)
    {

        animator2.SetBool("CollisionComplete", false);
        UnityEngine.Debug.Log("door closed");
    }

}
