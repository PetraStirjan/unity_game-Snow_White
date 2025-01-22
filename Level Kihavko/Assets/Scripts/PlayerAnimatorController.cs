using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerAnimationController : MonoBehaviour
{
    private Animator animator;
    public AudioSource audioSource;        
    public AudioClip sneezeClip;           
    public GameObject gameOverUI;          
    public AudioClip gameOverClip;         
    void Start()
    {
        animator = GetComponent<Animator>();
        if (animator == null)
        {
            Debug.LogError("Animator nije pronaðen na ovom objektu.");
        }

        if (audioSource == null)
        {
            Debug.LogError("AudioSource nije povezan u Inspectoru.");
        }
        animator.SetBool("IsWalking", true);  
    }

    void Update()
    {
        if (!animator.GetBool("IsSneezing"))
        {
            animator.SetBool("IsWalking", true);
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Flower"))
        {
            TriggerSneeze();
        }
    }

    void TriggerSneeze()
    {
        animator.SetBool("IsWalking", false);
        animator.SetBool("IsSneezing", true);

        if (audioSource != null && sneezeClip != null)
        {
            audioSource.PlayOneShot(sneezeClip);
        }
        Invoke(nameof(GameOver), 1.5f); 
    }

    void GameOver()
    {
        animator.SetBool("IsSneezing", false);

        Time.timeScale = 0f;
        if (audioSource != null && gameOverClip != null)
        {
            audioSource.PlayOneShot(gameOverClip);
        }
        if (gameOverUI != null)
        {
            gameOverUI.SetActive(true);
        }
        else
        {
            Debug.LogError("GameOverUI nije postavljen u Inspectoru.");
        }
    }
    public void RestartLevel()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
