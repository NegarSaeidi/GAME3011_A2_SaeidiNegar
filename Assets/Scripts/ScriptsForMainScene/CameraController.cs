using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{

    public float mouseSensivity = 100.0f;
    public Transform playerBody;
    public float XRotation = 0.0f;

    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }
    private void FixedUpdate()
    {
        float mouseX = Input.GetAxis("Mouse X") * mouseSensivity;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensivity;

        // XRotation -= mouseY;
        XRotation = Mathf.Clamp(XRotation, -90.0f, 90.0f);
        transform.localRotation = Quaternion.Euler(XRotation, 0.0f, 0.0f);
        playerBody.Rotate(Vector3.up * mouseX);
    }
    // Update is called once per frame
   
}