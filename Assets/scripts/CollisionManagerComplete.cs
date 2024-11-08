using System.Collections;
using UnityEngine;

public class CollisionManagerComplete : MonoBehaviour
{
    
    public Animator animator;
    //public GameObject smallRedBox, smallGreenBox, smallBlueBox;

    //public GameObject largeRedBox, largeGreenBox, largeBlueBox;
    private int collidedCount;
    private bool hasCollided1, hasCollided2, hasCollided3;

    void CheckAllMatched()
    {

        if (hasCollided1 && hasCollided2 && hasCollided3)
        {
            StartCoroutine(Complete());
            
        }

        else
        {
            Debug.Log("...");
        }
    }
    IEnumerator Complete()
    {
        animator.SetBool("CollisionComplete", true);
        UnityEngine.Debug.Log("all pairs matched");
        yield return new WaitForSeconds(5.5f);
        animator.SetBool("CollisionComplete", false);
    }

    public void OnBoxesCollided(GameObject collided, GameObject boxCollider)
    {
        if (!hasCollided1 && collided.CompareTag("RedBig") && boxCollider.CompareTag("RedSmall"))
        {
            UnityEngine.Debug.Log("small red box collided with red box");
            hasCollided1 = true;
            CheckAllMatched();

        }
        else if (!hasCollided2 && collided.CompareTag("GreenBig") && boxCollider.CompareTag("GreenSmall"))
        {
            UnityEngine.Debug.Log("small green box collided with green box");
            hasCollided2 = true;
            CheckAllMatched();

        }
        else if (!hasCollided3 && collided.CompareTag("BlueBig") && boxCollider.CompareTag("BlueSmall"))
        {
            UnityEngine.Debug.Log("small blue box collided with blue box");
            hasCollided3 = true;
            CheckAllMatched();

        }
    }

}
