using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Healthbar : MonoBehaviour
{
    [SerializeField] private Health playerHealth;
    [SerializeField] private Image totalhealthBar;
    [SerializeField] private Image currenthealthBar;

    private void OnEnable()
    {
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    private void OnDisable()
    {
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }

    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        // ✅ Find ONLY the Player's Health
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        if (player != null)
            playerHealth = player.GetComponent<Health>();
    }

    private void Start()
    {
        if (playerHealth != null)
            totalhealthBar.fillAmount = playerHealth.currentHealth / 10;
    }

    private void Update()
    {
        if (playerHealth == null) return;

        currenthealthBar.fillAmount = playerHealth.currentHealth / 10;
    }
}
