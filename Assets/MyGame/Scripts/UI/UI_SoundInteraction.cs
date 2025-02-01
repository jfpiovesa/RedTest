using UnityEngine;
using UnityEngine.EventSystems;

public class UI_SoundInteraction : MonoBehaviour,IPointerClickHandler, IPointerEnterHandler, IPointerDownHandler
{
    private AudioSource audioSource;
    public AudioClip clickSound;
    public AudioClip hoverSound;
    public AudioClip pressSound;

    private void Awake()
    {
        // Obtém o AudioSource do AppManager
        if (ApplicationManager.Instance  != null)
        {
            audioSource = ApplicationManager.Instance.GetAudioSource_UI_VFX();
        }
    }
    public void OnPointerClick(PointerEventData eventData)
    {

        PlaySound(clickSound);
    }
    public void OnPointerEnter(PointerEventData eventData)
    {

        PlaySound(hoverSound);
    }
    public void OnPointerDown(PointerEventData eventData)
    {

        PlaySound(pressSound);
    }
    private void PlaySound(AudioClip clip)
    {
        if (clip != null && audioSource != null)
        {
            audioSource.PlayOneShot(clip);
        }
    }
}