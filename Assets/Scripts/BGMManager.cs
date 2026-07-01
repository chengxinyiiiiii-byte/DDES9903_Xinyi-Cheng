using UnityEngine;
using System.Collections;

public class BGMManager : MonoBehaviour
{
    public AudioSource bgm1;
    public AudioSource bgm2;

    public float fadeDuration = 2f;

    void Start()
    {
        if (bgm1 != null)
            bgm1.volume = 0f;

        if (bgm2 != null)
            bgm2.volume = 0f;
    }

    public void PlayBGM1()
    {
        if (bgm1 == null) return;

        bgm1.loop = true;
        bgm1.Play();
        StartCoroutine(FadeIn(bgm1));
    }

    public void SwitchToBGM2()
    {
        StartCoroutine(SwitchMusic());
    }

    IEnumerator SwitchMusic()
    {
        if (bgm1 != null)
            yield return StartCoroutine(FadeOut(bgm1));

        if (bgm2 != null)
        {
            bgm2.loop = true;
            bgm2.Play();
            yield return StartCoroutine(FadeIn(bgm2));
        }
    }

    IEnumerator FadeIn(AudioSource audio)
    {
        float time = 0f;

        while (time < fadeDuration)
        {
            time += Time.deltaTime;
            audio.volume = Mathf.Lerp(0f, 1f, time / fadeDuration);
            yield return null;
        }

        audio.volume = 1f;
    }

    IEnumerator FadeOut(AudioSource audio)
    {
        float startVolume = audio.volume;
        float time = 0f;

        while (time < fadeDuration)
        {
            time += Time.deltaTime;
            audio.volume = Mathf.Lerp(startVolume, 0f, time / fadeDuration);
            yield return null;
        }

        audio.volume = 0f;
        audio.Stop();
    }
}