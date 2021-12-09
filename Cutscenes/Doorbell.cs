using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Doorbell : MonoBehaviour
{
    [SerializeField] private GameObject package;
    private RPGTalk talk;
    private AudioSource sound; 
    private bool doorbell;

    void Start()
    {        
        talk = GameObject.FindWithTag("Talk").GetComponent<RPGTalk>();
        talk.OnEndTalk += OnEndTalk;
        talk.OnNewTalk += OnNewTalk;
        sound = GetComponent<AudioSource>();
        if (GameManager.instance.so.friendCount > 4 && !GameManager.instance.so.ending)
        {
            sound.Play();
        }
        else
        {
            Destroy(gameObject);
            return;
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
            doorbell = true;
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player")
            doorbell = false;
    }
    private void OnEndTalk()
    {
        if (doorbell)
        {
            StartCoroutine(Package());
        }
        doorbell = false;

    }
    private void OnNewTalk()
    {
        if (doorbell)
        {
            sound.Stop();
        }

    }
    IEnumerator Package()
    {
        GetComponent<BoxCollider>().enabled = false;
        GameManager.instance.transition.FadeIn();
        yield return new WaitForSeconds(1f);
        package.SetActive(true);
        GameManager.instance.transition.FadeOut();
        Destroy(gameObject);

    }
    private void OnDisable()
    {
        talk.OnEndTalk -= OnEndTalk;
        talk.OnEndTalk -= OnNewTalk;
    }
}
