using UnityEngine;

public class BoxCollisionChecker : MonoBehaviour
{
    public CollisionManagerComplete collisionManager;

    private void OnCollisionEnter(Collision collision)
    {
        collisionManager.OnBoxesCollided(this.gameObject, collision.gameObject);
    }
}
