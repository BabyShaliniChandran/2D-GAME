using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelCompleteUI : MonoBehaviour
{
    public void ReturnToMainMenu()
    {
        Time.timeScale = 1f; // IMPORTANT: reset time
        SceneManager.LoadScene("_MainMenu");
    }

    public void ExitGame()
    {
        if (MainMenuSoundManager.instance != null)
            MainMenuSoundManager.instance.StopMusic();

#if UNITYWEBGL
        Debug.Log("Quit not supported in WebGL");
#else
        Application.Quit();
#endif

#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#endif
    }
}
