using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    [SerializeField] private RectTransform arrow;
    [SerializeField] private RectTransform[] buttons; // Size = 2 (Start, Quit)
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
        currentPosition += change;

        if (change != 0)
            SoundManager.instance.PlaySound(changeSound);

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

    // ---------------- KEYBOARD ----------------

    private void Interact()
    {
        SoundManager.instance.PlaySound(interactSound);

        if (currentPosition == 0)
        {
            StartGame();
        }
        else if (currentPosition == 1)
        {
            QuitGame();
        }
    }

    // ---------------- BUTTON OnClick ----------------

    public void StartGame()
    {
        SoundManager.instance.PlaySound(interactSound);
        SceneManager.LoadScene("Level1");
    }

    public void QuitGame()
    {
        SoundManager.instance.PlaySound(interactSound);
        Application.Quit();

#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#endif
    }
}
