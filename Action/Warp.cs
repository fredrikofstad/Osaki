using UnityEngine;
using UnityEngine.SceneManagement;

public class Warp : MonoBehaviour
{
    public string destination;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            Invoke("NewScene", 0.4f);
        }
    }
    private void NewScene()
    {
        SceneManager.LoadScene(sceneName: destination);
    }
}
