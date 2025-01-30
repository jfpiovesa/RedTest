using System.Collections.Generic;
using UnityEngine;

public class SoundsEffectsCharacter : MonoBehaviour
{
    [SerializeField] List<SundsData> soundsList = new List<SundsData>();
    [SerializeField] AudioSource audioSource;   
    
    public void PlaySound(string name)
    {
        SundsData sundsData = soundsList.Find(x  => x.namesound.Equals(name));
        int value = Random.Range(0, sundsData.audioClips.Length);
        audioSource.PlayOneShot(sundsData.audioClips[value]);
    }
}


[System.Serializable]
public class SundsData
{
    public string namesound;
    public AudioClip[] audioClips;

}
