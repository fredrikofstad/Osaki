using UnityEngine;
using UnityEngine.SceneManagement;

public class IncludeGUI : MonoBehaviour
{
    private void Awake()
    {
        if (GameManager.instance != null)
            return;
        if (!SceneManager.GetSceneByName("GUI").isLoaded)
        {
            SceneManager.LoadScene("GUI", LoadSceneMode.Additive);
        }
    }

}
