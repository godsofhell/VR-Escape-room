using UnityEngine;

public class CubeCornerPlacer : MonoBehaviour
{
    [SerializeField] private GameObject[] cubes; // Assign 4 cubes in the inspector
    [SerializeField] private Vector3[] cornerPositions; // Define 4 corners of the room

    void Start()
    {
        if (cubes.Length != 4 || cornerPositions.Length != 4)
        {
            Debug.LogError("Make sure to assign exactly 4 cubes and 4 corner positions.");
            return;
        }

        // Create a list of corner positions for shuffling
        var availableCorners = new System.Collections.Generic.List<Vector3>(cornerPositions);

        foreach (GameObject cube in cubes)
        {
            // Pick a random corner
            int randomIndex = Random.Range(0, availableCorners.Count);
            Vector3 chosenCorner = availableCorners[randomIndex];

            // Place the cube at the chosen corner
            cube.transform.position = chosenCorner;

            // Remove the used corner to prevent duplicates
            availableCorners.RemoveAt(randomIndex);
        }
    }
}
