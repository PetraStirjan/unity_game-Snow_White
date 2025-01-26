using UnityEngine;

public class ObjectSpawner : MonoBehaviour
{
    public GameObject[] objectsToSpawn;  
    public float spawnInterval = 1f;  
    public float spawnRangeX = 8f;  
    private float spawnHeight; 

    void Start()
    {
        Camera mainCamera = Camera.main;
        if (mainCamera != null)
        {
            spawnHeight = mainCamera.orthographicSize + 1f;  
        }
        InvokeRepeating("SpawnObject", 1f, spawnInterval);
    }

    void SpawnObject()
    {
        int randomIndex = Random.Range(0, objectsToSpawn.Length);
        GameObject obj = Instantiate(objectsToSpawn[randomIndex]);

        float randomX = Random.Range(-spawnRangeX, spawnRangeX);
        obj.transform.position = new Vector2(randomX, spawnHeight);

        if (!obj.TryGetComponent<Rigidbody2D>(out _))
        {
            Rigidbody2D rb = obj.AddComponent<Rigidbody2D>();
            rb.gravityScale = 10f;
        }
    }
}
