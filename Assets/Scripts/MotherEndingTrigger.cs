using UnityEngine;
using System.Collections;

public class MotherEndingTrigger : MonoBehaviour
{
    public AudioSource motherDialogue;

    public GameObject stella;
    public GameObject mother;
    public GameObject endingText;

    public float delayAfterDialogue = 2f;

    private bool hasPlayed = false;

    void Start()
    {
        if (endingText != null)
            endingText.SetActive(false);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (hasPlayed) return;

        if (other.CompareTag("Player"))
        {
            hasPlayed = true;
            StartCoroutine(EndingSequence());
        }
    }

    IEnumerator EndingSequence()
    {
        if (motherDialogue != null)
        {
            motherDialogue.Play();
            yield return new WaitForSeconds(motherDialogue.clip.length);
        }

        yield return new WaitForSeconds(delayAfterDialogue);

        if (stella != null)
            stella.SetActive(false);

        if (mother != null)
            mother.SetActive(false);

        if (endingText != null)
            endingText.SetActive(true);
    }
}