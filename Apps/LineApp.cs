using UnityEngine;
using TMPro;

public class LineApp : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI playerName;
    [SerializeField] private GameObject[] conversations;
    void Start()
    {
        playerName.text = GameManager.instance.so.playerName;
        foreach (GameObject convo in conversations)
            convo.SetActive(false);
    }

}
