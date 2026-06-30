using UnityEngine;

public class InteractableObject : MonoBehaviour
{
    public string promptMessage = "Press E to inspect";
    public AudioSource audioToPlay;
    public GameObject objectToHide;
    public GameObject objectToShow;

    private bool hasInteracted = false;

    public void Interact()
    {
        if (hasInteracted) return;

        hasInteracted = true;

        if (audioToPlay != null)
        {
            audioToPlay.Play();
        }

        if (objectToHide != null)
        {
            objectToHide.SetActive(false);
        }

        if (objectToShow != null)
        {
            objectToShow.SetActive(true);
        }
    }

    public string GetPrompt()
    {
        if (hasInteracted) return "";
        return promptMessage;
    }
}