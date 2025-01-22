using UnityEngine;
using TMPro;

public class FlowerAndTimerTracker : MonoBehaviour
{
    public TMP_Text timerText;           
    public TMP_Text flowersCutText;    
    public float levelTime = 9f;        
    public int totalFlowers = 6;        

    private float currentTime;          
    private int flowersCut = 0;        
    private bool isTimerRunning = true;  

    public GameObject gameOverUI;       
    public GameObject levelCompleteUI;   

    public AudioSource audioSource;        
    public AudioClip gameOverClip;          
    public AudioClip levelCompleteClip;      

    void Start()
    {
        currentTime = levelTime;  
        UpdateUI();               
    }

    void Update()
    {
        if (isTimerRunning)
        {
            currentTime -= Time.deltaTime;  
            if (currentTime <= 0f)
            {
                currentTime = 0f;
               
                isTimerRunning = false;
                
                GameOver();  
            }
            UpdateUI(); 
        }
    }

    public void AddFlowerCut()
    {
        flowersCut++; 
        UpdateUI();   

        if (flowersCut >= totalFlowers)
        {
            Debug.Log("Svi cvjetovi posjeæeni!");
            LevelComplete();
        }
    }

    void UpdateUI()
    {
       if (Mathf.CeilToInt(currentTime)>9) timerText.text = "BODOVI: 00:" + Mathf.CeilToInt(currentTime);
        else
        {
            timerText.text = "BODOVI: 00:0" + Mathf.CeilToInt(currentTime);
        }
        flowersCutText.text = flowersCut + "/" + totalFlowers;
    }

    void GameOver()
    {
        Debug.Log("Game Over! Vrijeme je isteklo.");
        audioSource.PlayOneShot(gameOverClip);
        gameOverUI.SetActive(true);
       
       
    }

    void LevelComplete()
    {
        Debug.Log("Level Complete! Svi cvjetovi posjeæeni.");
        isTimerRunning = false; 
        levelCompleteUI.SetActive(true);
        Time.timeScale = 0f;
         
        if (audioSource != null && levelCompleteClip != null)
        {
            audioSource.PlayOneShot(levelCompleteClip);
        }
    }
}
