using UnityEngine;
using UnityEngine.UI;

public class InstagramApp : MonoBehaviour
{
    private SaveObject so;
    [SerializeField] private GameObject[] posts;
    [SerializeField] private Transform container;
    [SerializeField] private ScrollRect scroll;
    private bool initialized;

    [SerializeField] private bool[] posted;
    [SerializeField] private bool[] unlocked;

    private void Start()
    {
        initialized = true;
        posted = new bool[posts.Length];
        unlocked = new bool[posts.Length];
        so = GameManager.instance.so;
        //starting posts automatically unlocked
        for (int i = 5; i < unlocked.Length; i++)
        {
            unlocked[i] = true;
        }
    }

    private void OnEnable()
    {
        if (!initialized)
            return;
        scroll.verticalNormalizedPosition = 1f;
        so = GameManager.instance.so;
        Unlock();
        Post();
        ChangeOrder();
    }

    private void Post()
    {
        for (int i = 0; i < posts.Length; i++)
        {
            if (!posted[i] && unlocked[i])
            {
                Instantiate(posts[i], container);
                posted[i] = true;
            }
        }
    }

    private void ChangeOrder()
    {
        for (int i = 0; i < posts.Length; i++)
        {
            if (unlocked[i])
            {
                posts[i].GetComponent<RectTransform>().SetAsLastSibling();
            }
        }
    }
    private void Unlock()
    {
        if (so.friends.akane)
            unlocked[0] = true;
        if (so.friends.iroha)
            unlocked[1] = true;
        if (so.friends.rikako)
            unlocked[2] = true;
        if (so.friends.mariya)
            unlocked[3] = true;
        if (so.friends.kanari)
            unlocked[4] = true;
    }
}
