using UnityEngine;
using System.Collections;

public class IntroManager : MonoBehaviour
{
    public AudioSource broadcast;
    public AudioSource narration;

    public MonoBehaviour playerController;

    // Drag your BGMManager here
    public BGMManager bgmManager;

    void Start()
    {
        // Disable player movement
        playerController.enabled = false;

        // Play the park announcement
        broadcast.Play();

        StartCoroutine(IntroSequence());
    }

    IEnumerator IntroSequence()
    {
        // Wait for the broadcast to finish
        yield return new WaitForSeconds(broadcast.clip.length);

        // Play the player's narration
        narration.Play();

        // Wait for the narration (9 seconds)
        yield return new WaitForSeconds(9f);

        // Enable player movement
        playerController.enabled = true;

        // Start BGM 1 (Searching Music)
        if (bgmManager != null)
        {
            bgmManager.PlayBGM1();
        }
    }
}