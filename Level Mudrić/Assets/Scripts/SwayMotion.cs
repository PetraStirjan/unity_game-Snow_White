using UnityEngine;

public class SwayMotion : MonoBehaviour
{
    public float swayAmount = 0.5f;  
    public float swaySpeed = 1.5f;   
    private Vector3 startPosition;

    void Start()
    {
        startPosition = transform.position;
    }
    void Update()
    {
        float sway = Mathf.Sin(Time.time * swaySpeed) * swayAmount;
        transform.position = new Vector3(startPosition.x + sway, startPosition.y, startPosition.z);
    }
}
