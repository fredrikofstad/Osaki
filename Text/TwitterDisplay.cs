using UnityEngine;
using UnityEngine.UI;
public class TwitterDisplay : MonoBehaviour
{
    public TwitterPost post;
    [SerializeField] private Text nameText;
    [SerializeField] private Text body;
    [SerializeField] private Image avatar;
    void Start()
    {
        nameText.text = post.name;
        body.text = post.body;
        avatar.sprite = post.avatar;
    }
}
