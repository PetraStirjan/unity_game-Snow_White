using UnityEngine;
using TMPro;
using System.Collections;

public class ButtonChecker : MonoBehaviour
{
    public TMP_InputField inputFieldSolution;   
    public TMP_Text feedbackText;               
    public AudioSource audioSource;             
    public AudioClip wrongAnswerClip;          
    public AudioClip correctAnswerClip;        

    private string correctAnswer = "Vrijeme";   

    
    public void OnCheckAnswer()
    {
         
        if (inputFieldSolution == null || feedbackText == null || audioSource == null || wrongAnswerClip == null || correctAnswerClip == null)
        {
            Debug.LogError("Nekim varijablama nedostaju reference u Inspectoru.");
            return;
        }

        string userAnswer = inputFieldSolution.text.Trim();
        
        if (userAnswer.Equals(correctAnswer, System.StringComparison.OrdinalIgnoreCase))
        {
            feedbackText.text = "       Bravo!";
            feedbackText.color = Color.green;  
            
            audioSource.PlayOneShot(correctAnswerClip);
        }
        else
        {
            feedbackText.text = "Pokušaj ponovno!";
            feedbackText.color = Color.red;  

            audioSource.PlayOneShot(wrongAnswerClip);

            StartCoroutine(ClearFeedbackAfterDelay(2f));  
        }
    }
     
    IEnumerator ClearFeedbackAfterDelay(float delay)
    {
        yield return new WaitForSeconds(delay);
        if (feedbackText != null)
        {
            feedbackText.text = "";  
        }
    }
}
