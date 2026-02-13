using UnityEngine;

public class InstructionUI : MonoBehaviour
{
    [SerializeField] private GameObject instructionPanel;

    private void Start()
    {
        instructionPanel.SetActive(false);
    }

    private void Update()
    {
        // Close instruction panel when ESC is pressed
        if (instructionPanel.activeSelf && Input.GetKeyDown(KeyCode.Escape))
        {
            CloseInstructions();
        }
    }

    public void OpenInstructions()
    {
        instructionPanel.SetActive(true);
    }

    public void CloseInstructions()
    {
        instructionPanel.SetActive(false);
    }
}
