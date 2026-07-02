using UnityEngine;
using System.Collections;

public class EndingSequence : MonoBehaviour
{
    public GameObject stella;
    public GameObject mother;
    public GameObject endingText;

    public float delay = 2f;

    void Start()
    {
        if (endingText != null)
            endingText.SetActive(false);
    }

    public void PlayEnding()
    {
        StartCoroutine(EndingCoroutine());
    }

    IEnumerator EndingCoroutine()
    {
        yield return new WaitForSeconds(delay);

        if (stella != null)
            stella.SetActive(false);

        if (mother != null)
            mother.SetActive(false);

        if (endingText != null)
            endingText.SetActive(true);
    }
}