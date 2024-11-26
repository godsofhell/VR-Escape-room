using UnityEngine;

public class Restart : MonoBehaviour
{
    public Transform player, destination;
    public GameObject playerg;
    
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
