using UnityEngine;
using UnityEngine.SceneManagement;

public class StartOfGame : MonoBehaviour
{
    // Start is called before the first frame update
    void Awake()
    {
        SceneManager.LoadScene("GUI", LoadSceneMode.Additive);
    }
}
