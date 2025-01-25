using System;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LogicScript : MonoBehaviour
{
    public int playerScore;
    public Text scoreText;
    public GameObject gameOverScreen;
    public GameObject nextLevelScreen;

    public GameObject popupPanel; // Referenca na pop-up panel
    public Transform flagPosition; // Referenca na zastavicu

    public bool isPlayerTouchingFlag = false; // Provjera dodira igrača sa zastavicom
    public bool isGameActive = true; // Praćenje stanja igre

    public void addScore()
    {
        playerScore++;
        scoreText.text = playerScore.ToString();
    }

    public void resetGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void gameOver()
    {
        isGameActive = false; // Onemogući kontrolu igrača
        gameOverScreen.SetActive(true);
    }

    public void nextLevel()
    {
        if (playerScore == 4)
        {
            isGameActive = false; // Onemogući kontrolu igrača
            nextLevelScreen.SetActive(true);
        }
        else
        {
            ShowPopup();
        }
    }


    public void ShowPopup()
    {
        popupPanel.SetActive(true);
        isPlayerTouchingFlag = true;

        // Postavi poziciju panela iznad zastavice
        Vector3 screenPosition = Camera.main.WorldToScreenPoint(flagPosition.position);
        popupPanel.transform.position = screenPosition + new Vector3(0, 100, 0);
    }

    public void ClosePopup()
    {
        popupPanel.SetActive(false);
        isPlayerTouchingFlag = false;
    }
    
}