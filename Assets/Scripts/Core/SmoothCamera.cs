using UnityEngine;

public class SmoothCamera : MonoBehaviour
{
    public Transform Player;
    public Vector3 offset = new Vector3(0.0f, 1.0f, -10.0f);
    [Range(0.0f,1.0f)] public float smoothness = 0.05f;

    Vector3 velocity;

    private void Update()
    {
        transform.position = Vector3.SmoothDamp(transform.position
            ,Player.position+offset,ref velocity,smoothness);
    }
}
