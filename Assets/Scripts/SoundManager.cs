using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public AudioClip good;
    public AudioClip bad;
    public AudioSource audioSource;
    public void PlayGood()
    {
        audioSource.PlayOneShot(good);
    }
    public void PlayBad()
    {
        audioSource.PlayOneShot(bad);
    }
}
