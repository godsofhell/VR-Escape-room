using UnityEngine;

public class ColorComparer : MonoBehaviour
{
    public Color color1;
    public Color color2;
    public float similarityThreshold = 0.1f;
    public GameObject door;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void OnCollisionEnter(Collision collision)
    {
        
        


            // checking the function if the colors are kind of similar by the given Threshold value you can change the value later
            if (AreColorsSimilar(color1, color2, similarityThreshold) && collision.gameObject.CompareTag("Red"))
            {
                Debug.Log("welcome to 2nd level");
            Destroy(door, 3f);
            }
            else
            {
                Debug.Log("...");
            }
        }
    
    // this function returns true if the colors are kind of similar
    bool AreColorsSimilar(Color c1, Color c2, float threshold)
    {
        // checking difference of R,G,B of the two colors if the difference is less depending on the threshold then it returns true
        float rDiff = Mathf.Abs(c1.r - c2.r);
        float gDiff = Mathf.Abs(c1.g - c2.g);
        float bDiff = Mathf.Abs(c1.b - c2.b);

        // here it is checkin if the difference between the 2 colors of R,G,B is less than the 'similaritythreshold' if all values are less than that it returns true
        return (rDiff < threshold &&  gDiff < threshold && bDiff < threshold);
    }

    
}
