using UnityEngine;
using UnityEngine.SceneManagement;
using Cinemachine;

public class GameManager : MonoBehaviour
{
    //save
    public SaveObject so;
    public const int maxPanda = 6;
    public const int maxFriends = 5;

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
    public TextManager textManager;
    public GameObject player;
    public Player playerScript;
    public Animator playerAnim;
    public Camera mainCamera;
    public CinemachineVirtualCamera playerCam;
    public bl_AudioPlayer audioPlayer;
    public Joystick joystick;
    public GameObject touchGui;

    //bools
    public bool touchControls;
    public bool inCutscene;
    public bool music;
    
    //between scenes
    Vector3 playerLocation;
    Vector3 playerRotation;
    public int playerClothes = 0;

    private void Start()
    {
        touchGui.SetActive(touchControls);
    }

    private void OnSceneLoaded(Scene s, LoadSceneMode mode)
    {
        player = GameObject.FindWithTag("Player");
        playerScript = player.GetComponent<Player>();
        playerAnim = player.GetComponentInChildren<Animator>();
        mainCamera = Camera.main;
        playerCam = GameObject.FindWithTag("PlayerCam").GetComponent<CinemachineVirtualCamera>();
        if(playerLocation != Vector3.zero) player.transform.position = playerLocation;
        if (playerRotation != Vector3.zero) player.transform.rotation = Quaternion.Euler(playerRotation);
        playerLocation = Vector3.zero;
        playerRotation = Vector3.zero;
    }
    public void GiveLocation(Vector3 newLocation, Vector3 newRotation)
    {
        playerLocation = newLocation;
        playerRotation = newRotation;
    }

    public void DisplayText(string msg, float duration)
    {
        textManager.Show(msg, duration);
    }
    public void PauseMusic()
    {
        audioPlayer.Pause();
    }
    public void Save()
    {
        SaveManager.Save(so);
    }
    public void Quit()
    {
        Application.Quit();
    }


}
