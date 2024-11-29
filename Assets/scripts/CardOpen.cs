using UnityEngine;

public class CardOpen : MonoBehaviour
{
    public GameObject Digit2;
    public Animator animator2;
    public AudioSource audio;

    private void Start()
    {
        audio = GetComponent<AudioSource>();
        Digit2.SetActive(false);
    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.CompareTag("card"))
        {
            animator2.SetBool("CollisionComplete", true);
            UnityEngine.Debug.Log("door opened");
            Digit2.SetActive(true);
            audio.Play();
        }
    }

    // Update is called once per frame
    
}
