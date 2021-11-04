using UnityEngine;
using UnityEngine.SceneManagement;

public class Warp : MonoBehaviour
{
    public string destination;
    public Vector3 newLocation;
    public Vector3 newRotation;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            Invoke("NewScene", 0.4f);
        }
    }
    private void NewScene()
    {
        GameManager.instance.GiveLocation(newLocation, newRotation);
        SceneManager.LoadScene(sceneName: destination);
    }
}
