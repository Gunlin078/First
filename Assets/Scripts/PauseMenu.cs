using System.ComponentModel;
using UnityEngine;
using UnityEngine.InputSystem;

public class PauseMenu : MonoBehaviour
{
    public GameObject container;

    private bool IsStopped = false;
    void Update(){
        if (Keyboard.current != null && Keyboard.current.escapeKey.wasPressedThisFrame){
            if (!IsStopped) { PauseGame();  } 
            else            { ResumeGame(); }
        }  
    }

    public void PauseGame() {
        container.SetActive(true);
        Time.timeScale = 0;
        IsStopped = true;
    }
    public void ResumeGame() {
        container.SetActive(false);
        Time.timeScale = 1;
        IsStopped = false;
    }

    public void MainMenu() {
        UnityEngine.SceneManagement.SceneManager.LoadScene("MainMenu");
    }
}
