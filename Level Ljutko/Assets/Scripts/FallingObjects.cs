using UnityEngine;

public class FallingObject : MonoBehaviour
{
    private void Start()
    {
       
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.CompareTag("Ground"))
        {
            Debug.Log("Entered Trigger Ground!");
            Destroy(gameObject);
        }

        if (collision.CompareTag("Player"))
        {           
            if (gameObject.CompareTag("Gljiva"))
            {
                GameManager.instance.AddPoints(1);
            }
            else if (gameObject.CompareTag("Ogledalo") || gameObject.CompareTag("Jabuka"))
            {
                GameManager.instance.AddPoints(-1); 
            }
            else if (gameObject.CompareTag("Kovceg"))
            {
                GameManager.instance.EndGame(); 
            }
            Destroy(gameObject);
        }
    }
}
