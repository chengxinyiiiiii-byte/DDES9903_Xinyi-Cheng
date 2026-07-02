using UnityEngine;
using System.Collections;

public class IntroManager : MonoBehaviour
{
    public AudioSource broadcast;
    public AudioSource narration;

    // Drag your invisible wall here
    public GameObject invisibleWall;

    // Drag your BGMManager here
    public BGMManager bgmManager;

    void Start()
    {
        // Make sure the wall is active
        if (invisibleWall != null)
        {
            invisibleWall.SetActive(true);
        }

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

        // Wait for the narration
        yield return new WaitForSeconds(9f);

        // Remove the invisible wall
        if (invisibleWall != null)
        {
            invisibleWall.SetActive(false);
        }

        // Start searching BGM
        if (bgmManager != null)
        {
            bgmManager.PlayBGM1();
        }
    }
}