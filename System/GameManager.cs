using UnityEngine;
using UnityEngine.SceneManagement;
using Cinemachine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    private void Awake()
    {
        if (GameManager.instance != null)
        {
            Destroy(gameObject);
            return;
        }
        instance = this;
        SceneManager.sceneLoaded += OnSceneLoaded;
    }
    //references
    public PauseManager pause;
    public GameObject player;
    public Player playerScript;
    public Animator playerAnim;
    public Camera mainCamera;
    public CinemachineVirtualCamera playerCam;

    //bools
    public bool inCutscene;

    private void OnSceneLoaded(Scene s, LoadSceneMode mode)
    {
        player = GameObject.FindWithTag("Player");
        playerScript = player.GetComponent<Player>();
        playerAnim = player.GetComponentInChildren<Animator>();
        mainCamera = Camera.main;
        playerCam = GameObject.FindWithTag("PlayerCam").GetComponent<CinemachineVirtualCamera>();
    }



}
