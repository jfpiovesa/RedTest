using UnityEngine;

public class TImeDestroy : MonoBehaviour
{
    public float destroyTime = 5f; // Tempo em segundos antes da destruição
    private void OnEnable()
    {
        Destroy(gameObject, destroyTime);
    }
}
