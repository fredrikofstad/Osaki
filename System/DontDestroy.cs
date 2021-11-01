using UnityEngine;

public class DontDestroy : MonoBehaviour
{
    private void Awake()
    {
    #if UNITY_EDITOR
        if (Application.isPlaying)
            UnityEditor.SceneVisibilityManager.instance.Show(gameObject, false);
    #endif
        DontDestroyOnLoad(gameObject);
    }
}

