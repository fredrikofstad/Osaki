using UnityEngine;
using UnityEngine.SceneManagement;

public class IncludeGUI : MonoBehaviour
{
    private void Awake()
    {
        if (!GameManager.instance.so.introCutscene)
            SceneManager.LoadScene("GUI", LoadSceneMode.Additive);
    }

}
