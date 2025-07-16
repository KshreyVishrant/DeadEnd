using UnityEngine;
using System.Collections;

public class MusicVolumeBooster : MonoBehaviour
{
    public AudioSource audioSource;
    public float intensifyAfter = 120f; // Test for 10 seconds instead of 120f (2 mins)
    public float targetVolume = 1f;  // Target volume (150%)
    public float fadeDuration = 5f;    // Smooth fade duration (adjust as needed)

    void Start()
    {
        // Start testing after 10 seconds
        Invoke("BeginFade", intensifyAfter);
    }

    void BeginFade()
    {
        StartCoroutine(GradualVolumeIncrease());
    }

    // Smooth volume increase over 'fadeDuration' seconds
    IEnumerator GradualVolumeIncrease()
    {
        float startVolume = audioSource.volume;
        float timer = 0f;

        Debug.Log("Volume boost started!"); // Optional: Verify in Console

        while (timer < fadeDuration)
        {
            timer += Time.deltaTime;
            audioSource.volume = Mathf.Lerp(startVolume, targetVolume, timer / fadeDuration);
            yield return null; // Wait for next frame
        }

        Debug.Log("Volume boost finished!"); // Optional
    }
}