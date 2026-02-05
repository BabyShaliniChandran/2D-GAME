using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    [SerializeField] private RectTransform arrow;
    [SerializeField] private RectTransform[] buttons;
    [SerializeField] private AudioClip changeSound;
    [SerializeField] private AudioClip interactSound;

    private int currentPosition;

    private void Awake()
    {
        Time.timeScale = 1f;
        AudioListener.pause = false;
        ChangePosition(0);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.UpArrow))
            ChangePosition(-1);
        else if (Input.GetKeyDown(KeyCode.DownArrow))
            ChangePosition(1);

        if (Input.GetKeyDown(KeyCode.KeypadEnter) || Input.GetButtonDown("Submit"))
            Interact();
    }

    // ---------------- NAVIGATION ----------------

    public void ChangePosition(int change)
    {
        if (change != 0 && MainMenuSoundManager.instance != null)
            MainMenuSoundManager.instance.PlaySound(changeSound);

        currentPosition += change;

        if (currentPosition < 0)
            currentPosition = buttons.Length - 1;
        else if (currentPosition >= buttons.Length)
            currentPosition = 0;

        AssignPosition();
    }

    private void AssignPosition()
    {
        arrow.position = new Vector3(
            arrow.position.x,
            buttons[currentPosition].position.y
        );
    }

    // ---------------- INPUT ----------------

    private void Interact()
    {

        if (currentPosition == 0)
            StartGame();
        else if (currentPosition == 1)
            QuitGame();
    }

    // ---------------- ACTIONS ----------------


    public void StartGame()
    {
        if (MainMenuSoundManager.instance != null)
            MainMenuSoundManager.instance.StopMusic();

        SceneManager.LoadScene("Level1");
    }
    public void QuitGame()
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
