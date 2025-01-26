using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed = 5f;  
    private float moveInput;

    private Animator animator;  
    private SpriteRenderer spriteRenderer;  

    void Start()
    {
        animator = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    void Update()
    { 
        moveInput = Input.GetAxis("Horizontal");
        transform.Translate(new Vector3(moveInput, 0, 0) * moveSpeed * Time.deltaTime);
         
        animator.SetBool("isWalking", Mathf.Abs(moveInput) > 0);
         
        if (moveInput > 0)
        {
            spriteRenderer.flipX = false;  
        }
        else if (moveInput < 0)
        {
            spriteRenderer.flipX = true;  
        }
    }
}
