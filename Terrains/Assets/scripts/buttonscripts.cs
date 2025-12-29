using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement; // لازم تضيف المكتبة دي علشان تبدل بين الـ Scenes
using UnityEngine.UI; // لو هتستخدم UI elements زي الأزرار
public class ButtonScripts : MonoBehaviour
{
    public GameObject panel; // لو عندك بانيل عايز تخفيه أو تظهره
    public Slider loadingBar; // لو عندك سلايدر للتحميل
    public Text Text; // لو عندك تيكست عايز تعرض فيه معلومات

    // دي هتتربط بزرار Start
    public void LoadLevel(string sceneName)
    {
        // يفتح الـ Scene اللي اسمه "Terrains"
        StartCoroutine(LoadLevelAsync(sceneName));
    }

    IEnumerator LoadLevelAsync(string sceneName) // Fixed return type to IEnumerator
    {
        AsyncOperation operation = SceneManager.LoadSceneAsync(sceneName);
        panel.gameObject.SetActive(true); // يظهر البانيل لو عندك واحد

        while (!operation.isDone)
        {
            float progress = Mathf.Clamp01(operation.progress / 0.9f); // Normalize the progress to a range of 0 to 1
            loadingBar.value = progress; // يحدث قيمة السلايدر
            Text.text = progress*100+"%";
            yield return null; // يستنى لحد ما الـ Scene تخلص تحميل
        }
        panel.gameObject.SetActive(false);
    }

    // دي هتتربط بزرار Quit
    public void QuitGame()
    {
        Debug.Log("Quit Game!");

#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false; // يوقف البلاي مود في الـ Editor
#else
        Application.Quit(); // يقفل اللعبة في الـ Build
#endif
    }
}
