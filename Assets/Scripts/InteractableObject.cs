using UnityEngine;

public class InteractableObject : MonoBehaviour
{
    public string promptMessage = "Press E to inspect";
    public KeyCode interactKey = KeyCode.E;

    public AudioSource audioToPlay;

    public GameObject objectToHide;
    public GameObject objectToShow;

    public bool lockPlayerDuringAudio = false;
    public MonoBehaviour playerController;

    private bool hasInteracted = false;

    public string GetPrompt()
    {
        if (hasInteracted) return "";
        return promptMessage;
    }

    public KeyCode GetInteractKey()
    {
        return interactKey;
    }

    public void Interact()
    {
        if (hasInteracted) return;

        hasInteracted = true;

        if (objectToHide != null)
            objectToHide.SetActive(false);

        if (objectToShow != null)
            objectToShow.SetActive(true);

        if (lockPlayerDuringAudio && playerController != null)
            playerController.enabled = false;

        if (audioToPlay != null)
        {
            audioToPlay.Play();

            if (lockPlayerDuringAudio)
                Invoke(nameof(UnlockPlayer), audioToPlay.clip.length);
        }
        else
        {
            UnlockPlayer();
        }
    }

    void UnlockPlayer()
    {
        if (playerController != null)
            playerController.enabled = true;
    }
}