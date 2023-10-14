using UnityEngine.SceneManagement;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public void GoPlay(){
        SceneManager.LoadScene("InGame");
    }
    public void GoMenu(){
        Time.timeScale = 1f;
        SceneManager.LoadScene("Menu");
    }
    public virtual void ExitGame(){
        Application.Quit();
        #if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
        #endif
    }
    public virtual void GamePause(){
        Time.timeScale = 0f;
    }
}
