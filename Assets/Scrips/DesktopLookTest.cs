using UnityEngine;

public class DesktopLookTest : MonoBehaviour
{
    public float sensitivity = 2f;
    float yaw;
    float pitch;

    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;

        Vector3 e = transform.eulerAngles;
        yaw = e.y;
        pitch = e.x;
    }

    void Update()
    {
        yaw += Input.GetAxis("Mouse X") * sensitivity;
        pitch -= Input.GetAxis("Mouse Y") * sensitivity;
        pitch = Mathf.Clamp(pitch, -80f, 80f);

        transform.rotation = Quaternion.Euler(pitch, yaw, 0f);

        // Escape to release mouse
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
        }
    }
}