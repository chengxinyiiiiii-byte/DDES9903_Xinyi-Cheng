using UnityEngine;

public class HairClipPickup : MonoBehaviour
{
    [Header("Prompt")]
    public GameObject promptText;

    [Header("Hair Clip")]
    public GameObject hairClipWorld;
    public GameObject hairClipHand;

    [Header("Audio")]
    public AudioSource narrationAudio;

    private bool playerInside = false;
    private bool pickedUp = false;

    void Start()
    {
        if (promptText != null)
            promptText.SetActive(false);

        if (hairClipHand != null)
            hairClipHand.SetActive(false);
    }

    void Update()
    {
        if (playerInside && !pickedUp && Input.GetKeyDown(KeyCode.E))
        {
            PickUpHairClip();
        }
    }

    void PickUpHairClip()
    {
        pickedUp = true;

        if (promptText != null)
            promptText.SetActive(false);

        if (hairClipWorld != null)
            hairClipWorld.SetActive(false);

        if (hairClipHand != null)
            hairClipHand.SetActive(true);

        if (narrationAudio != null)
            narrationAudio.Play();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && !pickedUp)
        {
            playerInside = true;

            if (promptText != null)
                promptText.SetActive(true);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player") && !pickedUp)
        {
            playerInside = false;

            if (promptText != null)
                promptText.SetActive(false);
        }
    }
}