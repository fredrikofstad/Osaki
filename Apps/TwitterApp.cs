using UnityEngine;
using UnityEngine.UI;

public class TwitterApp : MonoBehaviour
{
    //consider enum
    private SaveObject so;
    [SerializeField] private TwitterPost[] posts;
    [SerializeField] private GameObject prefab;
    [SerializeField] private Transform container;
    [SerializeField] private ScrollRect scroll;
    private bool initialized; //cause wtf unity?

    [SerializeField] private bool[] posted;
    [SerializeField] private bool[] unlocked;

    private void Start()
    {
        initialized = true;
        posted = new bool[posts.Length];
        unlocked = new bool[posts.Length];
        so = GameManager.instance.so;
        //starting posts automatically unlocked
        for (int i = 6; i < unlocked.Length; i++)
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

        for (int i = 0; i < posts.Length; i++)
        {
            if (!posted[i] && unlocked[i])
            {
                prefab.GetComponent<TwitterDisplay>().post = posts[i];
                Instantiate(prefab, container);
                prefab.transform.SetAsLastSibling();
                posted[i] = true;
            }   
        }
    }

    private void Unlock()
    {
        if (so.pandaCount > 4)
            unlocked[0] = true; //pandaMan Active
        if(so.cafe)
            unlocked[4] = true; //starbucks2
        if (so.exercise)
            unlocked[5] = true; //musk2
        if (so.work)
            unlocked[1] = true; //musk3
        if (so.groceries)
            unlocked[2] = true; //starbucks3
        if (so.friendCount > 3)
            unlocked[3] = true; //anoncar
    }
}
