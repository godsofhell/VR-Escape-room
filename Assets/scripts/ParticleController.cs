using System.Collections;
using UnityEngine;

public class ParticleController : MonoBehaviour
{
    // Start is called before the first frame update
    public ParticleSystem[] particleSystems;

    public float timer = 5.0f;
    public GameObject player;
    private float targetPos = -6.1f;
    private bool IsTimeRunning = false;
    public AudioSource trip;
    private MeshRenderer invisible;
    // Update is called once per frame

    private void Start()
    {
        trip = GetComponent<AudioSource>(); 
        invisible = GetComponent<MeshRenderer>();
        invisible.enabled = false;
    }
    public void OnTriggerEnter(Collider other)
    {
        trip.Play();
        foreach (ParticleSystem p in particleSystems)
        {
            p.Play();

            if (!IsTimeRunning)
            {
                StartCoroutine(StartTimer());
                IsTimeRunning = true;
            }
        }
    }
    private IEnumerator StartTimer()
    {
        while(timer > 0)
        {
            timer -= Time.deltaTime;
            if (player.transform.position.x == targetPos)
            {
                timer = 0;

            }
            yield return null;
            
        }
        
         
        }
    }
