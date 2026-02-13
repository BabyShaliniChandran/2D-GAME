using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    [Header("Audio")]
    [SerializeField] private AudioClip interactSound;

    [Header("Instructions")]
    [SerializeField] private GameObject instructionPanel;

    private bool isInstructionOpen;

    private void Awake()
    {
        Time.timeScale = 1f;
        AudioListener.pause = false;

        instructionPanel.SetActive(false);
        isInstructionOpen = false;
    }

    private void Update()
    {
        // Allow ESC to close instructions
        if (isInstructionOpen && Input.GetKeyDown(KeyCode.Escape))
        {
            CloseInstructions();
        }
    }

    public void StartGame()
    {
        if (MainMenuSoundManager.instance != null)
            MainMenuSoundManager.instance.PlaySound(interactSound);

        SceneManager.LoadScene("Level1");
    }

    public void OpenInstructions()
    {
        if (MainMenuSoundManager.instance != null)
            MainMenuSoundManager.instance.PlaySound(interactSound);

        instructionPanel.SetActive(true);
        isInstructionOpen = true;
    }

    public void CloseInstructions()
    {
        instructionPanel.SetActive(false);
        isInstructionOpen = false;
    }

    public void QuitGame()
    {
        if (MainMenuSoundManager.instance != null)
            MainMenuSoundManager.instance.PlaySound(interactSound);

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
