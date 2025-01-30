using UnityEngine;

public class ApplicationManager : MonoBehaviour
{

    public static ApplicationManager instance;

    public GameObject vfX_Player;
    public GameObject projectil;
    public UI_FadeTransition uI_FadeTransition;
    
    private void Awake()
    {

        if (instance != null)
        {
            Destroy(this.gameObject);
        }
        else
        {
            instance = this;
        }
        DontDestroyOnLoad(this.gameObject);
    }
}
