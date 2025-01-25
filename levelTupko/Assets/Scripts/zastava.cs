using UnityEngine;

public class zastava : MonoBehaviour
{
    public LogicScript logicManager; // Referenca na Logic Manager

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player") && logicManager.playerScore!=4) // Provjera je li igrač ušao u zastavicu
        {
            Debug.Log("Player reached the flag!");
            logicManager.ShowPopup(); // Poziv metode iz Logic Managera
        }
        else if (other.CompareTag("Player") && logicManager.playerScore == 4)
        {
            logicManager.nextLevel();
        }
    }
    
    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player") && logicManager.isPlayerTouchingFlag) // Provjera napuštanja dodira
        {
            logicManager.ClosePopup();
        }
    }
}
