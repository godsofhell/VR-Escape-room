using UnityEngine;

public class ParticleController : MonoBehaviour
{
    // Start is called before the first frame update
    public ParticleSystem[] particleSystems;
    

    // Update is called once per frame

    public void OnTriggerEnter(Collider other)
    {
        foreach(ParticleSystem p in particleSystems)
        {
            p.Play();
        }
        
         
        }
    }
