using UnityEngine;

public class RestartGame : MonoBehaviour
{
    public void LoadCurrentScene()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene(UnityEngine.SceneManagement.SceneManager.GetActiveScene().name);
        Time.timeScale = 1;
    }
    public void LoadFirstScene()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("GameScene");
        Time.timeScale = 1;
    }
}
