using UnityEngine;

public class Collectscript : MonoBehaviour
{
    public int points = 1; // النقاط اللي هتتزود لما اللاعب يلمس الـ PickUp

    [Header("Audio")]
    public AudioSource backgroundMusic;  // اربط صوت الخلفية من Inspector
    public AudioSource collectSound;     // اربط صوت جمع الكوين من Inspector

    void Start()
    {
        // تشغيل الخلفية مرة واحدة عند بداية اللعبة
        if (backgroundMusic != null && !backgroundMusic.isPlaying)
        {
            backgroundMusic.loop = true;
            backgroundMusic.Play();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("PickUp"))
        {
            // قفل الـ Object
            other.gameObject.SetActive(false);

            // زود النقاط
            FindObjectOfType<ScoreManager>().CollectPoint(points);

            // شغل صوت جمع الكوين
            if (collectSound != null)
            {
                collectSound.Play();
            }
        }
    }
}
