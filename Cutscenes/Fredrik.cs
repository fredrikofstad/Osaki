using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.SceneManagement;

public class Fredrik : Cutscene
{
    [SerializeField] private PlayableDirector ending;
    [SerializeField] private GameObject presents;
    [SerializeField] private GameObject laptop;
    private RPGTalk talk;
    
    private bool fredrik;
    private int choice = 0;

    protected override void Setup()
    {
        director = ending;
        talk = GameObject.FindWithTag("Talk").GetComponent<RPGTalk>();
        talk.OnMadeChoice += OnMadeChoice;
        talk.OnEndTalk += OnEndTalk;
        if (GameManager.instance.so.ending)
            presents.SetActive(true);
        else
            gameObject.SetActive(false);  
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
            fredrik = true;
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player")
            fredrik = false;
    }
    private void OnMadeChoice(string questionID, int choiceID)
    {
        choice = choiceID;
    }
    private void OnEndTalk()
    {
        if (!fredrik)
            return;
        if(choice == 0)
        {
            director.gameObject.SetActive(true);
            PlayCutscene();
            presents.SetActive(true);
            laptop.SetActive(false);
            choice = 5;
        }

    }
    protected override void OnCutsceneEnd()
    {
        GameManager.instance.so.ending = true;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
    private void OnDestroy()
    {
        talk.OnEndTalk -= OnEndTalk;
        talk.OnMadeChoice -= OnMadeChoice;
    }
}
