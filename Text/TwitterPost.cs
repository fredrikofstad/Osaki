using UnityEngine;

[CreateAssetMenu(fileName = "Post", menuName = "Twitter")]

public class TwitterPost : ScriptableObject
{
    public new string name;
    public string body;
    public Sprite avatar;
}
