using UnityEngine;

public class MainMenuSoundManager : MonoBehaviour
{
    public static MainMenuSoundManager instance;

    [Header("Audio Sources")]
    [SerializeField] private AudioSource musicSource;
    [SerializeField] private AudioSource sfxSource;

    [Header("Menu Music")]
    [SerializeField] private AudioClip introMusic;

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
        if (musicSource == null || introMusic == null) return;

        musicSource.clip = introMusic;
        musicSource.loop = false;   // plays ONCE
        musicSource.Play();
    }

    public void PlaySound(AudioClip clip)
    {
        if (clip == null || sfxSource == null) return;
        sfxSource.PlayOneShot(clip);
    }

    public void StopMusic()
    {
        if (musicSource != null)
            musicSource.Stop();
    }
}
