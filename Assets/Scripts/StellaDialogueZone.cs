using UnityEngine;
using System.Collections;

public class StellaDialogueZone : MonoBehaviour
{
    public GameObject talkPrompt;      // Press C to talk
    public GameObject carryPrompt;     // Press V to help Stella

    public AudioSource dialogueAudio;

    public GameObject stellaWorld;
    public GameObject stellaCarry;

    private bool playerInside = false;
    private bool dialogueFinished = false;
    private bool hasTalked = false;

    void Start()
    {
        talkPrompt.SetActive(false);
        carryPrompt.SetActive(false);

        stellaCarry.SetActive(false);
    }

    void Update()
    {
        // 开始对话
        if (playerInside && !hasTalked && Input.GetKeyDown(KeyCode.C))
        {
            hasTalked = true;

            talkPrompt.SetActive(false);

            StartCoroutine(PlayDialogue());
        }

        // 抱起 Stella
        if (dialogueFinished && Input.GetKeyDown(KeyCode.V))
        {
            carryPrompt.SetActive(false);

            stellaWorld.SetActive(false);
            stellaCarry.SetActive(true);

            dialogueFinished = false;
        }
    }

    IEnumerator PlayDialogue()
    {
        dialogueAudio.Play();

        yield return new WaitForSeconds(dialogueAudio.clip.length);

        dialogueFinished = true;
        carryPrompt.SetActive(true);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && !hasTalked)
        {
            playerInside = true;
            talkPrompt.SetActive(true);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player") && !hasTalked)
        {
            playerInside = false;
            talkPrompt.SetActive(false);
        }
    }
}