using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class POV : MonoBehaviour
{

    public float mouseSensitivity = 100f;
    // this is the assigned value for mouse sensitivity, this can be considered as how fast the player can rotate the POV

    public Transform playerBody;
    // this gives us the ability the manipulate an object such as by moving and rotating it etc

    float xRotation = 0f; //this is our default x axis orientation
    // Start is called before the first frame update
  

    // Update is called once per frame
    void Update()
    {
        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime;

        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -90f, 90f);

        transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);
        playerBody.Rotate(Vector3.up * mouseX);
        if (Input.GetKeyDown("q"))
        {
            Cursor.lockState = CursorLockMode.Locked;
            // cursor gets concealed when 'q' is pressed
        }
        if (Input.GetKeyDown("e"))
        {
            Cursor.lockState = CursorLockMode.None;
            // cursor gets revealed when 'e' is clicked
        }
    }
}
