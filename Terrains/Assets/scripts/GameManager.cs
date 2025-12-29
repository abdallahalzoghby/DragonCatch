using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    void Update()
    {
        // فتح المنيو عند الضغط على زر ESC
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            GoToMenu();
        }
    }

    public void GoToMenu()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("button");   // اكتب اسم Scene بتاع المنيو
    }

    public void RestartGame()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
