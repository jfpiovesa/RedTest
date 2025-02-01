using UnityEngine;
using UnityEngine.Audio;

public class ApplicationManager : MonoBehaviour
{

    public static ApplicationManager Instance { get; private set; }

    [Header("Vfx")]
    public GameObject vfX_Player;
    public GameObject projectil;

    [Header("UI")]
    public UI_FadeTransition uI_FadeTransition;


    [Header("Audio")] 
    [SerializeField] private AudioSource aS_UI_vfx;
    [SerializeField] private AudioSource aS_Music;

    private void Awake()
    {

        if (Instance  != null)
        {
            Destroy(this.gameObject);
        }
        else
        {
            Instance  = this;
        }
        DontDestroyOnLoad(this.gameObject);

    }


    // refaturar para um script que gerencie os audios  do game
    public AudioSource GetAudioSource_UI_VFX()
    {
        return aS_UI_vfx;
    }
    public AudioSource GetAudioSource_Musci()
    {
        return aS_Music;
    }
}
