using UnityEngine;

public class CameraMovementScript : MonoBehaviour
{
    public Transform player;
    public Vector3 offset;
    public float leftLimit = -10f; // Lijeva granica
    public float rightLimit = 24f; // Desna granica
    public float topLimit = 10f; // Gornja granica
    public float bottomLimit = -5f; // Donja granica
    

    void Update()
    {
        float clampedX = Mathf.Clamp(player.position.x + offset.x, leftLimit, rightLimit);
        float clampedY = Mathf.Clamp(player.position.y + offset.y, bottomLimit, topLimit);
        transform.position = new Vector3(clampedX, clampedY, offset.z);
    } 
}