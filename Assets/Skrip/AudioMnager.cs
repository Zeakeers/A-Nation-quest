using UnityEngine;

public class AudioMnager : MonoBehaviour
{
    [Header("---------- Audio Clip ----------")]
    [SerializeField] AudioSource musicSource;
    [SerializeField] AudioSource SFXSource;

    [Header("---------- Audio Clip ----------")]
    public AudioClip backgraound;
    public AudioClip walk;
    public AudioClip run;
    public AudioClip kunci;


    private void Start()
    {
        musicSource.clip = backgraound;
        musicSource.Play();
    }
    public void PlaySFX(AudioClip clip)
    {
        SFXSource.PlayOneShot(clip);
    }
    
}

