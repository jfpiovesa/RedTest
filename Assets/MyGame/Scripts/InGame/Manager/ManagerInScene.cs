using UnityEngine;

public class ManagerInScene : MonoBehaviour
{

    [SerializeField] private PlayerControler prefabPlayer;
    [SerializeField] private Transform startingLocate;

    
    void Start()
    {
        SpawnPlayer();
    }


    public void SpawnPlayer()
    {

        PlayerControler player = Instantiate<PlayerControler>(prefabPlayer);

        player.transform.SetPositionAndRotation(startingLocate.position, startingLocate.rotation);
        player.Teleportation(startingLocate.position, startingLocate.rotation,() => ActionSpawn(player));

    }

    void ActionSpawn(PlayerControler playerControler)
    {
        ApplicationManager.Instance .uI_FadeTransition.PlayAnimationFinish("Fad_Out", () => playerControler.StopActions(false));
    }

}
