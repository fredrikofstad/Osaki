using UnityEngine;
using System.Collections;

[RequireComponent(typeof(AudioSource))]
public class LifeMusic : MonoBehaviour
{
    AudioSource[] sources;
    void Start()
    {
        GameManager.instance.PauseMusic();
        sources = GetComponents<AudioSource>();
        sources[0].Play();
        StartCoroutine(PlayNext());
    }

    IEnumerator PlayNext()
    {
        yield return Unscaled.WaitForRealSeconds(sources[0].clip.length);
        sources[1].Play();
        yield return Unscaled.WaitForRealSeconds(sources[1].clip.length);
        StartCoroutine(PlayNext());
    }
}