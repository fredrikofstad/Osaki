using UnityEngine;
using System.Collections;

[RequireComponent(typeof(AudioSource))]
public class LifeMusic : MonoBehaviour
{
    private AudioSource source;
    public AudioClip track1;
    public AudioClip track2;
    void Start()
    {
        GameManager.instance.PauseMusic();
        source = GetComponent<AudioSource>();
        source.clip = track1;
        source.Play();
        StartCoroutine(PlayNext());
    }

    IEnumerator PlayNext()
    {
        yield return Unscaled.WaitForRealSeconds(source.clip.length);
        source.clip = track2;
        source.Play();
        yield return Unscaled.WaitForRealSeconds(source.clip.length);
        StartCoroutine(PlayNext());
    }
}