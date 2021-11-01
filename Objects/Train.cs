using System.Collections;
using UnityEngine;

public class Train : MonoBehaviour
{
    private bool isOpen;
    private float originalZ;

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
    void OnTriggerExit(Collider other)
    {
        other.transform.parent = null;
    }
    void OnTriggerEnter(Collider other)
    {
        other.transform.parent = this.transform;
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

        yield return new WaitForSeconds(5);
        //inception
        StartCoroutine(Choochoo());
    }




}
