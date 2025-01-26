using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement; 

public class GameManager : MonoBehaviour
{
    public static GameManager instance; 

    public int score = 0;  
    public TextMeshProUGUI scoreText; 
    public GameObject levelCompletedUI;  
    public GameObject gameOverUI;  
    public GameObject restartButton;  
    public AudioClip goodSound;  
    public AudioClip badSound;
    public AudioClip gameOverSound;

    private AudioSource audioSource;
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        UpdateScoreUI();
        audioSource = gameObject.AddComponent<AudioSource>();
    }
     
    public void AddPoints(int points)
    {
       if (points>0) PlaySound(goodSound);
        if (points < 0) PlaySound(badSound);
        score += points;
        UpdateScoreUI();

        if (score >= 5)
        {
            LevelCompleted();
        }
        else if (score < 0)
        {
            PlaySound(gameOverSound);
            GameOver();

        }
    } 
    private void UpdateScoreUI()
    {
        scoreText.text = "" + score;
    } 
    private void LevelCompleted()
    {
        levelCompletedUI.SetActive(true);
        Time.timeScale = 0; 
    } 
    public void GameOver()
    {
        PlaySound(gameOverSound);
        gameOverUI.SetActive(true);
        restartButton.SetActive(true);
        Time.timeScale = 0;  
    }
     
    public void RestartGame()
    {
        Time.timeScale = 1; 
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
     
    public void EndGame()
    {
        GameOver();
    }
     
    private void PlaySound(AudioClip clip)
    {
        if (clip != null)
        {
            audioSource.PlayOneShot(clip);
        }
    }
}
