using Unity.Cinemachine;
using UnityEngine;

public class CameraSettings : MonoBehaviour
{
    CinemachineCamera cinemachineCamera;

    private void Awake()
    {
        if (cinemachineCamera == null)
        {
            cinemachineCamera = GetComponent<CinemachineCamera>();
        }
    }
    private void OnEnable()
    {
        OS_PlayerInGame.A_targetCam += SetTarger;
    }
    private void OnDisable()
    {
        OS_PlayerInGame.A_targetCam -= SetTarger;
    }


    public void SetTarger(Transform target)
    {
        cinemachineCamera.Target.TrackingTarget = target;
    }
}
