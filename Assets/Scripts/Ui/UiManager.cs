using UnityEngine;
using UnityEngine.SceneManagement;

public class UiManager : MonoBehaviour
{
    [Header("Game over")]
    [SerializeField] private GameObject gameOverScreen;
    [SerializeField] private AudioClip gameOverSound;

    [Header("Pause")]
    [SerializeField] private GameObject pauseScreen;


    void Start()
    {
        gameOverScreen.SetActive(false);
    }

    private void Awake()
    {
        gameOverScreen.SetActive(false);
        pauseScreen.SetActive(false);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (pauseScreen.activeInHierarchy)
                PauseGame(false);
            else
                PauseGame(true); 
        }
    }

    #region  Game Over
    //Activate game over screen
    public void GameOver()
    {
        gameOverScreen.SetActive(true);
        Time.timeScale = 0f;
        SoundManager.instance.PlaySound(gameOverSound);
    }

    //Game over functions
    public void Restart()
    {
        gameOverScreen.SetActive(false);
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);// Make sure the game is unpaused
        
    }


    public void MainMenu()
    {
        //CRITICAL RESETS
        Time.timeScale = 1f;
        AudioListener.pause = false;

        if (SoundManager.instance != null)
        {
            SoundManager.instance.musicSource.UnPause();
        }

        SceneManager.LoadScene("_MainMenu");
    }


    public void Quit() 
    {
        Application.Quit() ;
        #if UNITY_EDITOR// will execute only if in the editor
        UnityEditor.EditorApplication.isPlaying = false; // exiting the play mode directly
        #endif


    }
    #endregion

    #region Pause
    public void PauseGame(bool status)
    {
        pauseScreen.SetActive(status);

        if (status)
            Time.timeScale = 0;
        else
            Time.timeScale = 1;
         
    }

    public void SoundVolume()
    {
        SoundManager.instance.ChangeSoundVolume(0.2f);
    }

    public void MusicVolume()
    {
        SoundManager.instance.ChangeMusicVolume(0.2f);
    }

    #endregion
}
