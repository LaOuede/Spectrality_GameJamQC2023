using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    public Camera MainCamera;

    public SpectreController SpectreObject;

    public GameObject PoisonObject;
    public GameObject PotionIcon;
    public GameObject ToolTip;

    public PostProcessControl PostProcessControl;
    public AudioManager AudioManager;
    public AudioClip SpecterMusic;
    public AudioClip NormalMusic;
    public SFX SFX;
    
    private void Awake()
    {
        if (Instance == null)
            Instance = this;
        else
            Destroy(gameObject);
    }

    private void Start()
    {
        AudioManager.ChangeBGM(NormalMusic);
        PotionIcon.SetActive(false);
        MainCamera = Camera.main;
        PostProcessControl.SetNormalProcess();
    }

}
