using UnityEngine;

public class KihavkoMovement : MonoBehaviour
{
    public float moveSpeed = 2f;

    void Update()
    { 
        transform.Translate(Vector2.right * moveSpeed * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Flower"))
        {
            moveSpeed = 0f;
        }
    }

}
