using UnityEngine;
using System.Collections;

public class StellaDialogueZone : MonoBehaviour
{
    public GameObject talkPrompt;
    public GameObject carryPrompt;

    public AudioSource dialogueAudio;

    public GameObject stellaWorld;
    public GameObject stellaCarry;

    public BGMManager bgmManager;

    private bool playerInside = false;
    private bool hasTalked = false;
    private bool canCarry = false;
    private bool hasCarried = false;

    void Start()
    {
        if (talkPrompt != null)
            talkPrompt.SetActive(false);

        if (carryPrompt != null)
            carryPrompt.SetActive(false);

        if (stellaCarry != null)
            stellaCarry.SetActive(false);
    }

    void Update()
    {
        if (playerInside && !hasTalked && Input.GetKeyDown(KeyCode.C))
        {
            hasTalked = true;
            StartCoroutine(PlayDialogue());
        }

        if (canCarry && !hasCarried && Input.GetKeyDown(KeyCode.V))
        {
            CarryStella();
        }
    }

    IEnumerator PlayDialogue()
    {
        if (talkPrompt != null)
            talkPrompt.SetActive(false);

        // Switch from BGM1 to BGM2
        if (bgmManager != null)
        {
            Debug.Log("Switching to BGM2");
            bgmManager.SwitchToBGM2();
        }
        else
        {
            Debug.Log("BGM Manager is missing");
        }

        if (dialogueAudio != null)
        {
            dialogueAudio.Play();
            yield return new WaitForSeconds(dialogueAudio.clip.length);
        }

        canCarry = true;

        if (carryPrompt != null)
            carryPrompt.SetActive(true);
    }

    void CarryStella()
    {
        hasCarried = true;
        canCarry = false;

        if (carryPrompt != null)
            carryPrompt.SetActive(false);

        if (stellaWorld != null)
            stellaWorld.SetActive(false);

        if (stellaCarry != null)
            stellaCarry.SetActive(true);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && !hasTalked)
        {
            playerInside = true;

            if (talkPrompt != null)
                talkPrompt.SetActive(true);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player") && !hasTalked)
        {
            playerInside = false;

            if (talkPrompt != null)
                talkPrompt.SetActive(false);
        }
    }
}