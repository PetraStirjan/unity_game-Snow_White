using UnityEngine;

public class FlowerClick : MonoBehaviour
{
    void OnMouseDown()
    {

        Destroy(gameObject);
        FindObjectOfType<FlowerAndTimerTracker>().AddFlowerCut();

    }
}
