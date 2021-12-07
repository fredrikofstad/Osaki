using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    AudioSource music;
    private void Start()
    {
        if (GameManager.instance.so.introCutscene)
        {
            gameObject.SetActive(false);
            return;
        }
        music = GetComponent<AudioSource>();
        music.Play();

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
