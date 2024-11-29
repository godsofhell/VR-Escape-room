using UnityEngine;

public class Restart2 : MonoBehaviour
{
    public Transform player, destination;
    public GameObject playerg;
    //public GameObject tile;
    MeshRenderer mr = new MeshRenderer();
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private void Start()
    {
        mr = GetComponent<MeshRenderer>();
        mr.enabled = false;
    }
    public void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            playerg.SetActive(false);
            player.position = destination.position;
            Debug.Log("teleport");
            playerg.SetActive(true);
            //tile.SetActive(false);
        }
    }
}
