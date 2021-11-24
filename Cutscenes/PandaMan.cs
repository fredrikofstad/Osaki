using System.Collections;
using UnityEngine;

public class PandaMan : MonoBehaviour
{
    private AudioSource sound;
    private RPGTalk talk;
    private bool pandaTalk;
    void Start()
    {
        talk = GameObject.FindWithTag("Talk").GetComponent<RPGTalk>();
        sound = gameObject.GetComponent<AudioSource>();
        talk.OnEndTalk += OnEndTalk;

        if (GameManager.instance.so.pandaCount < 5)
            gameObject.SetActive(false);       
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
            pandaTalk = true;
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player")
            pandaTalk = false;
    }

    private void OnEndTalk()
    {
        if (pandaTalk && !GameManager.instance.so.pandas[(int)PandaCollect.PandaName.pandaStation])
            StartCoroutine(TaskComplete());
    }

    IEnumerator TaskComplete()
    {
        GameManager.instance.so.pandas[(int)PandaCollect.PandaName.pandaStation] = true;
        GameManager.instance.so.pandaCount++;

        yield return new WaitForSeconds(1f);

        GameManager.instance.DisplayText($"[{GameManager.instance.so.pandaCount}/{GameManager.maxPanda}] Pandas Found!", 6f);
        sound.Play();

        yield return new WaitForSeconds(6f);

        GameManager.instance.DisplayText("Panda costume unlocked! Got to your closet to try it on!", 6f);
    }
    private void OnDisable()
    {
        talk.OnEndTalk -= OnEndTalk;
    }
}
