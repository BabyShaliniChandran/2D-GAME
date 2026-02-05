using UnityEngine;

public class LevelEnd : MonoBehaviour
{
    [SerializeField] private GameObject gameEndPanel;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            gameEndPanel.SetActive(true);
            Time.timeScale = 0f; // stop the game
        }
    }
}
