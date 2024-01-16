using UnityEngine;

public class Test_Mouse_Look : MonoBehaviour
{
    [SerializeField] float mouseSensitivity;
    [SerializeField] Transform playerBody;
    float xRotation;

    private void Start()
    {
        // hide cursor during start (test mode)
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }
    void Update()
    {
        float mouseX = Input.GetAxis("Mouse X") * (mouseSensitivity * 2) * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * (mouseSensitivity * 2) * Time.deltaTime;

        // store data for xRotation
        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -45f, 65f);

        // rotate object (playerBody)
        transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);
        playerBody.Rotate(Vector3.up * mouseX);
    }
}
