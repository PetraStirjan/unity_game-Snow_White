using UnityEngine;

public class TreeSway : MonoBehaviour
{
    public float swayAmount = 10f;  
    public float swaySpeed = 3f; 

    private Vector3 startRotation;

    void Start()
    {
        startRotation = transform.localRotation.eulerAngles;
    }

    void Update()
    {
        float sway = Mathf.Sin(Time.time * swaySpeed) * swayAmount;
        transform.localRotation = Quaternion.Euler(startRotation.x + sway, startRotation.y, startRotation.z);
    }
}
