using UnityEngine.SceneManagement;
public class MenuCutscene : Cutscene
{
    protected override void Setup()
    {
        if (!GameManager.instance.so.introCutscene)
        {
            PlayCutscene();
        }
            

    }

}
