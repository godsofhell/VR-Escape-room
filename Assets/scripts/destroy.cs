using UnityEngine;

public class destroy : MonoBehaviour
{
    
    // Start is called before the first frame update
    
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("art"))
        {
            Destroy(gameObject);
            Debug.Log("target destroyed");
            
        }
    }
}