using UnityEngine;
using UnityEngine.Playables;

public class Cutscene : MonoBehaviour
{
    private PlayableDirector director;
    private bool hasRun;
    private Player player;
    protected void Start()
    {
        director = GetComponentInChildren<PlayableDirector>();
        player = GameManager.instance.playerScript;
        Setup();
    }
    protected virtual void Setup()
    {
        //overwritable
    }
    protected void PlayCutscene()
    {
        player.Disable();
        GameManager.instance.touchGui.SetActive(false);
        hasRun = true;
        director.Play();
        GameManager.instance.inCutscene = true;
    }
    protected void Update()
    {
        if (director.state != PlayState.Playing && hasRun) //unity plz... event would be nice
        {
            hasRun = false;
            GameManager.instance.inCutscene = false;
            OnCutsceneEnd();
            player.Enable();
            GameManager.instance.touchGui.SetActive(GameManager.instance.touchControls);
        }
    }
    protected virtual void OnCutsceneEnd()
    {
        //overridable
    }
}
