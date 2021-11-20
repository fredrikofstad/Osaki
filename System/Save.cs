using UnityEngine;

public class Save : MonoBehaviour
{

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.K))
        {
            SaveManager.Save(GameManager.instance.so);
        }
        if (Input.GetKeyDown(KeyCode.L))
        {
            GameManager.instance.so = SaveManager.Load();
        }

    }
}
