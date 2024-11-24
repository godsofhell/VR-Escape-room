using System.Collections.Generic;
using System.Linq.Expressions;
using UnityEngine;

public class ProceduralGeneration : MonoBehaviour
{
    

    public GameObject objectToSpawn;
    // no of objects to spawn
    public int NumberOfObjects = 10;

    public Vector3 areaSize = new Vector3(20, 0, 20);

    private List<GameObject> SpawnedObjects = new List<GameObject>();

    public void Start()
    {
        GenerateObject();
    }

    public void GenerateObject()
    {
        foreach (GameObject obj in SpawnedObjects)
        {
            // to destroy previously spawned gameobjects 
            Destroy(obj);
        }
        for(int i =0;i<NumberOfObjects;i++)
        {
            // to spawn objects at random position using Vector 3 
            Vector3 randomPos = new Vector3(Random.Range(-areaSize.x / 2, areaSize.x / 2), Random.Range(-areaSize.y / 2, areaSize.y / 2), Random.Range(-areaSize.z / 2, areaSize.z / 2));
            GameObject spawned = Instantiate(objectToSpawn, randomPos + new Vector3(-12,0.15f,0), Quaternion.identity);
            // to add gameobjects to the list
            SpawnedObjects.Add(spawned);
        }
    }

}
