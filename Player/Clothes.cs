using UnityEngine;

public class Clothes : MonoBehaviour
{
    [SerializeField] private GameObject headphones;
    [SerializeField] private GameObject phone;
    [SerializeField] private AniController aniController;


    public GameObject[] clothes;
    public int clothesNumber = 0;

    private bool music; //might not be needed, make gamemanager var?

    void Start()
    {
        GameManager.instance.pause.Paused += OnPause;
        GameManager.instance.pause.Resumed += OnResume;
        aniController = GetComponent<AniController>();
        ChangeClothes(clothesNumber);
        if (GameManager.instance.music)
        {
            headphones.SetActive(true);
        }
        else
        {
            headphones.SetActive(false);
        }
    }

    public void SetHeadphones(bool music)
    {
        if (music)
        {
            headphones.SetActive(true);
        }
        else
        {
            headphones.SetActive(false);
        }
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.R) && headphones != null) //turn into bool for music
        {

            if (music)
            {
                headphones.SetActive(true);
            }
            else
            {
                headphones.SetActive(false);
            }
            music = !music;
        }
    }

    public void ChangeClothes(int cloth)
    {
        //making active before deactivating Model prefab
        if(phone != null)
            phone.SetActive(true);
        if (headphones != null)
            headphones.SetActive(true);
        //clothes change
        for (int i = 0; i < clothes.Length; i++)
        {
            if(i == cloth)
            {
                clothes[i].SetActive(true);
            }
            else
            {
                clothes[i].SetActive(false);
            }
        }
        //regetting references
        foreach (GameObject obj in FindObjectsOfType(typeof(GameObject))) //er dette kronglete?
        {
            if (obj.transform.IsChildOf(transform) && obj.CompareTag("Headphones")) headphones = obj;
            if (obj.transform.IsChildOf(transform) && obj.CompareTag("Phone")) phone = obj;
        }
        phone.SetActive(false);
        aniController.GetReferences();

    }

    //should this be here?
    private void OnPause()
    {
        aniController.OnPause();
        phone.SetActive(true);
    }
    private void OnResume()
    {
        aniController.OnResume();
        phone.SetActive(false);
    }
    private void OnDestroy()
    {
        GameManager.instance.pause.Paused -= OnPause;
        GameManager.instance.pause.Resumed -= OnResume;
    }

}
