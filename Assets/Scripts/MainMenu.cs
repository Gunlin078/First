using UnityEngine.SceneManagement;
using UnityEngine.InputSystem;
using UnityEngine;

public class MainMenu : MonoBehaviour
{
    public GameObject mainMenu;
    public GameObject levelSelect;
    public void LoadLevel(string levelName){
        SceneManager.LoadScene(levelName);
    }
    void Update() {
        if (Keyboard.current != null && Keyboard.current.escapeKey.wasPressedThisFrame){
            mainMenu.SetActive(true);
            levelSelect.SetActive(false);
        }
    }
    public void OpenLevelSelect() { 
        mainMenu.SetActive(false);
        levelSelect.SetActive(true);
    }
    public void StartGame(){
        SceneManager.LoadScene("GameScene");
    }
    public void QuitGame(){
        Application.Quit();
    }
}
