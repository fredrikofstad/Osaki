using UnityEngine;
using UnityEngine.UI;

public class SelectButton : MonoBehaviour
{
    private Button button;
    void Start()
    {
        button = GetComponent<Button>();
        button.Select();
    }
}