using UnityEngine;

public class KnifeCursor : MonoBehaviour
{
    private RectTransform knifeImage;
    public AudioClip clickSound;  
    public AudioSource audioSource;

    void Start()
    { 
        knifeImage = GetComponent<RectTransform>();
        Cursor.visible = false;  

    }

    void Update()
    { 
        Vector3 mousePosition = Input.mousePosition;
        knifeImage.position = mousePosition;
         
        if (Input.GetMouseButtonDown(0))  
        {
            PlayClickSound();
        }
    }

    private void PlayClickSound()
    {
        if (clickSound != null)
        {
            audioSource.PlayOneShot(clickSound);
        }
        else
        {
            Debug.LogWarning("Click sound nije postavljen!");
        }
    }
}
