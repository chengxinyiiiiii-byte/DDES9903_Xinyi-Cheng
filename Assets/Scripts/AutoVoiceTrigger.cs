using UnityEngine;

public class AutoVoiceTrigger : MonoBehaviour
{
    public AudioSource voiceAudio;

    private bool hasPlayed = false;

    private void OnTriggerEnter(Collider other)
    {
        if (hasPlayed) return;

        if (other.CompareTag("Player"))
        {
            hasPlayed = true;

            if (voiceAudio != null)
            {
                voiceAudio.Play();
            }
        }
    }
}