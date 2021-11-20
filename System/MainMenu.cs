using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    private void Start()
    {
        if (GameManager.instance.so.introCutscene)
        {
            gameObject.SetActive(false);
        }
    }
    public void NewGame()
    {
        PlayerPrefs.DeleteAll();
        SceneManager.LoadScene("Room");
        Disable();
    }
    public void LoadGame()
    {
        if (SaveManager.SaveFileExists())
        {
            GameManager.instance.so = SaveManager.Load();
            GameManager.instance.inCutscene = false;
            SceneManager.LoadScene("Room");
            Disable();
        }        
    }
    public void QuitGame()
    {
        Debug.Log("Quit Game");
        Application.Quit();
    }
    private void Disable()
    {
        gameObject.SetActive(false);
    }
}
