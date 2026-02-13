using UnityEngine;

public class MainMenuSoundManager : MonoBehaviour
{
    public static MainMenuSoundManager instance;

    [Header("Audio Sources")]
    [SerializeField] private AudioSource musicSource;
    [SerializeField] private AudioSource sfxSource;

    private void Awake()
    {
        instance = this;
    }

    private void Start()
    {
        PlayIntroMusic();
    }

    private void PlayIntroMusic()
    {
        musicSource.loop = false; 
        musicSource.Play();
    }

    public void PlaySound(AudioClip clip)
    { 
        sfxSource.PlayOneShot(clip);
    }

    public void StopMusic()
    {
        musicSource.Stop();
    }
}
