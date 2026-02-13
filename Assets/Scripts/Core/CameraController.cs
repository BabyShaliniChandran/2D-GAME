using UnityEngine;
using UnityEngine.SceneManagement;

public class CameraController : MonoBehaviour
{
    //Room position
    private float currentPosX;
    private Vector3 velocity = Vector3.zero;
    //Player ref
    [SerializeField] private Transform player;

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

        //Reset to Room1
        GameObject startRoom = GameObject.FindWithTag("Room1");
        if (startRoom != null)
        {
            currentPosX = startRoom.transform.position.x;

            // no delay
            transform.position = new Vector3(
                currentPosX,
                transform.position.y,
                transform.position.z
            );
        }

        velocity = Vector3.zero;
    }

    public void MoveToNewRoom(Transform _newRoom)
    {
        currentPosX = _newRoom.position.x;
    }
}
