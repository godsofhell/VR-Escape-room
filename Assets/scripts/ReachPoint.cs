using UnityEngine;

public class ReachPoint : MonoBehaviour
{
    public ParticleController part;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            part.timer = 0;

        }
    }
}

