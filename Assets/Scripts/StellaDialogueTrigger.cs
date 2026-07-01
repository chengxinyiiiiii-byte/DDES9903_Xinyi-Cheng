using UnityEngine;

public class StellaDialogueTrigger : MonoBehaviour
{
    public GameObject promptText;
    public AudioSource dialogueAudio;
    public MonoBehaviour playerController;

    private bool playerNearby = false;
    private bool hasTalked = false;

    void Start()
    {
        promptText.SetActive(false);
    }

    void Update()
    {
        if (playerNearby && !hasTalked && Input.GetKeyDown(KeyCode.O))
        {
            StartDialogue();
        }
    }

    void StartDialogue()
    {
        hasTalked = true;

        promptText.SetActive(false);

        // Lock player movement
        playerController.enabled = false;

        // Play full dialogue
        dialogueAudio.Play();

        // Unlock player after dialogue finishes
        Invoke(nameof(UnlockPlayer), dialogueAudio.clip.length);
    }

    void UnlockPlayer()
    {
        playerController.enabled = true;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && !hasTalked)
        {
            playerNearby = true;
            promptText.SetActive(true);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player") && !hasTalked)
        {
            playerNearby = false;
            promptText.SetActive(false);
        }
    }
}