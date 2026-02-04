using UnityEngine;
using UnityEngine.SceneManagement;

public class CameraController : MonoBehaviour
{
    // Room camera
    [SerializeField] private float speed;
    private float currentPosX;
    private Vector3 velocity = Vector3.zero;

    // Follow player
    [SerializeField] private Transform player;
    [SerializeField] private float aheadDistance;
    [SerializeField] private float cameraSpeed;
    private float lookAhead;

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
        // Reattach player
        GameObject playerObj = GameObject.FindGameObjectWithTag("Player");
        if (playerObj != null)
            player = playerObj.transform;

        // 🔑 Reset camera to Room 1
        GameObject startRoom = GameObject.FindWithTag("Room1");
        if (startRoom != null)
        {
            currentPosX = startRoom.transform.position.x;

            // snap instantly (no smooth delay)
            transform.position = new Vector3(
                currentPosX,
                transform.position.y,
                transform.position.z
            );
        }

        velocity = Vector3.zero;
    }

    private void Update()
    {
        transform.position = Vector3.SmoothDamp(
            transform.position,
            new Vector3(currentPosX, transform.position.y, transform.position.z),
            ref velocity,
            speed
        );
    }

    public void MoveToNewRoom(Transform _newRoom)
    {
        currentPosX = _newRoom.position.x;
    }
}
