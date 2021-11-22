using System.Collections;
using UnityEngine;

public class Train : MonoBehaviour
{
    private bool isOpen;
    private float originalZ;
    private bool playerOnbaord;

    [SerializeField]
    private WorkCutscene workcutscene;

    public delegate void TrainHandler();
    public event TrainHandler ReadyToBoard;
    public event TrainHandler ReadyToDisembark;

    private void Start()
    {
        originalZ = transform.position.z;
        StartCoroutine(Choochoo());
    }

    private void Bye()
    {
        LeanTween.moveZ(gameObject, -20, 5f).setEase(LeanTweenType.easeInQuad);
    }

    private void Arrive()
    {
        transform.position = new Vector3(transform.position.x, transform.position.y, 125);
        LeanTween.moveZ(gameObject, originalZ, 5f).setEase(LeanTweenType.easeOutQuad);
    }
    void OnTriggerEnter(Collider other)
    {
        other.transform.parent = this.transform;
        if (other.gameObject.tag == "Player")
            playerOnbaord = true;
    }
    void OnTriggerExit(Collider other)
    {
        other.transform.parent = null;
        if (other.gameObject.tag == "Player")
            playerOnbaord = false;
    }

    IEnumerator Choochoo()
    {
        //japanese trains always on time man
        ReadyToBoard.Invoke();

        yield return new WaitForSeconds(15);

        ReadyToDisembark.Invoke();

        yield return new WaitForSeconds(8);

        Bye();

        yield return new WaitForSeconds(10);

        Arrive();
        if (playerOnbaord)
        {
            Time.timeScale = 0;
            workcutscene.PlayCS();
        }

        yield return new WaitForSeconds(5);
        //inception
        StartCoroutine(Choochoo());
    }




}
