using UnityEngine;

public class ReachPoint : MonoBehaviour
{
    public ParticleController part;
    private MeshRenderer mesh;

    void Start()
    {
        mesh = GetComponent<MeshRenderer>();
        mesh.enabled = false;
    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            part.timer = 0;

        }
    }
}

