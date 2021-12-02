using UnityEngine;
using TMPro;

public class Transition : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI text;
    [SerializeField] private CanvasGroup transition;

    public void FadeIn(string msg = "")
    {
        transition.gameObject.SetActive(true);
        text.text = msg;
        LeanTween.alphaCanvas(transition, 1f, 0.5f);
    }
    public void FadeOut()
    {
        if (!gameObject.activeSelf)
            return;

        LeanTween.alphaCanvas(transition, 0f, 2f).setOnComplete(Deactivate);
    }
    private void Deactivate() => transition.gameObject.SetActive(false);
}
