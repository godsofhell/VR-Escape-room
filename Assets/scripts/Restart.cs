using UnityEngine;
using UnityEngine.Rendering;

public class Restart : MonoBehaviour
{
    public Transform player, destination;
    public GameObject playerg;

    public ButtonPush push;
    private MeshRenderer mr;
     void Start()
    {
         mr = GetComponent<MeshRenderer>();
        mr.enabled = false;
    }
     void Update()
    {
        if (push != null && push.isPushCalled)
        {
            mr.enabled = true;
        }

    }
    public void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            playerg.SetActive(false);
            player.position = destination.position;
            Debug.Log("teleport");
            playerg.SetActive(true);
        }
    }
    
}
