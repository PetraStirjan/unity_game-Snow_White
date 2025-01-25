using System;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class Move : MonoBehaviour
{
    public float moveSpeed = 5f;
    private Rigidbody2D rb;
    private Animator animator;
    private SpriteRenderer spriteRenderer;
    private bool isGrounded;
    public LogicScript logicScript;
    public bool tupkoIsAlive = true;
    public BackgroundMusicScript backgroundMusicScript;

    private void Awake()
    {
        animator = gameObject.GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        logicScript = GameObject.FindGameObjectWithTag("GameController").GetComponent<LogicScript>();
    }

    private void Update()
    {
        if (!logicScript.isGameActive || !tupkoIsAlive) // Provjera je li igra aktivna i igrač živ
            return;
        Jump();
    }

    private void FixedUpdate()
    {
        if (!logicScript.isGameActive || !tupkoIsAlive) // Provjera je li igra aktivna i igrač živ
            return;
        MoveCharachter();
    }

    private void Jump()
    {
        if (!tupkoIsAlive)
            return;
        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            rb.AddForce(Vector2.up * 7f, ForceMode2D.Impulse);
            animator.SetBool("Jump", true);
            isGrounded = false; 
        }
    }

    private void MoveCharachter()
    {
        if (!tupkoIsAlive)
            return;
        float horizontal = Input.GetAxisRaw("Horizontal");
        Vector3 movement = new Vector3(horizontal, 0f, 0f);
        float deltaMoveSpeed = moveSpeed * Time.deltaTime;
        transform.position += movement * deltaMoveSpeed;

        float clampedX = Mathf.Clamp(transform.position.x, -10f, 23.5f);
        transform.position = new Vector3(clampedX, transform.position.y, transform.position.z);

        animator.SetFloat("Move", Mathf.Abs(horizontal));

        if (Input.GetKey(KeyCode.LeftArrow))
        {
            spriteRenderer.flipX = true;
        }
        else if (Input.GetKey(KeyCode.RightArrow))
        {
            spriteRenderer.flipX = false;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        
        if (collision.gameObject.CompareTag("Ground"))
        {
            animator.SetBool("Jump", false); 
            animator.Play("Hodanje - Idle"); 
            isGrounded = true; 
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Collectable"))
        {
            backgroundMusicScript.PlayCoinSound();
            logicScript.addScore();
            Destroy(other.gameObject);
        }
        else if (other.gameObject.CompareTag("Enemy"))
        {
            logicScript.gameOver();
            tupkoIsAlive = false;
        }
    }
}
