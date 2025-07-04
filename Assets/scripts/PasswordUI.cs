using UnityEngine;

public class PasswordUI : MonoBehaviour
{
    public GameObject Keyboard;
    public AudioSource audi;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        audi = GetComponent<AudioSource>();
        Keyboard.SetActive(false);
        MeshRenderer mesh = GetComponent<MeshRenderer>();
        mesh.enabled = false;
    }

    // Update is called once per frame
    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("card"))
        {
            audi.Play();
            Keyboard.SetActive(true);
        }
    }
}
