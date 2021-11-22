using UnityEngine.SceneManagement;

public class OpeningCutscene : Cutscene
{
    protected override void Setup()
    {
        if (!GameManager.instance.so.introCutscene)
        {
            PlayCutscene();
        }
    }
    protected override void OnCutsceneEnd()
    {
        GameManager.instance.so.introCutscene = true;
    }


}
