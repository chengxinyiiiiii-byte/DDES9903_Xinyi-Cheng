using UnityEngine;

public class HairClipPickup : MonoBehaviour
{
    public GameObject promptText;
    public GameObject handHairClip;
    public AudioSource hairClipNarration;

    private bool playerNearby = false;
    private bool pickedUp = false;

    void Start()
    {
        promptText.SetActive(false);
        handHairClip.SetActive(false);
    }

    void Update()
    {
        if (playerNearby && !pickedUp && Input.GetKeyDown(KeyCode.E))
        {
            pickedUp = true;

            promptText.SetActive(false);
            handHairClip.SetActive(true);

            hairClipNarration.Play();

            gameObject.SetActive(false);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && !pickedUp)
        {
            playerNearby = true;
            promptText.SetActive(true);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player") && !pickedUp)
        {
            playerNearby = false;
            promptText.SetActive(false);
        }
    }
}