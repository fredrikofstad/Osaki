using UnityEngine.SceneManagement;

public class StartOfGame : Cutscene
{
    private void Awake()
    {
        SceneManager.LoadScene("GUI", LoadSceneMode.Additive); //remove this after making main menu
        Invoke("PlayCutscene", 0.1f);
    }


}
