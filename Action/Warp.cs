using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Warp : MonoBehaviour
{
    public string destination;
    public Vector3 newLocation;
    public Vector3 newRotation;
    public string msg = "";

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            StartCoroutine(NewScene());
        }
    }

    IEnumerator NewScene()
    {
        GameManager.instance.transition.FadeIn(msg);
        yield return new WaitForSeconds(0.5f);
        GameManager.instance.GiveLocation(newLocation, newRotation);
        SceneManager.LoadScene(sceneName: destination);
    }
}
