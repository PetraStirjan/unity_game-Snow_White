using UnityEngine;
using UnityEngine.SceneManagement;

public class LogicManagerScript : MonoBehaviour
{
    
    public void LoadNextScene()
    {
        SceneManager.LoadScene("levelTupko");
    }
}
