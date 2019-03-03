using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public void PlayEffect(AudioSource _sound)
    {
        _sound.Play();
    }
}