using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameraController : MonoBehaviour
{
    public float movementTime;
    public float movementSpeed;
    public Vector3 newPosition;
    public float rotationAmount;
    public Quaternion newRotation; //quaternions are used to represent rotations

    // Start is called before the first frame update
    void Start()
    {
        newPosition = transform.position;
        newRotation = transform.rotation;
    }

    // Update is called once per frame
    void Update()
    {
        movementInput();
    }

    void movementInput()
    {
        if (Input.GetKey(KeyCode.W)) //if Wpressed then camera will move forward
        {
            newPosition += (transform.forward * movementSpeed);
        }
         
        if (Input.GetKey(KeyCode.S)) //if Spressed camera will move backwards
        {
            newPosition += (transform.forward * -movementSpeed);
        }

        if (Input.GetKey(KeyCode.A)) //if Apressed then camera will move left
        {
            newPosition += (transform.right * -movementSpeed);
        }

        if (Input.GetKey(KeyCode.D)) //if Dpressed then camera will move right
        {
            newPosition += (transform.right * movementSpeed);
        }

        if (Input.GetKey(KeyCode.Q))
        {
            newRotation *= Quaternion.Euler(Vector3.up * rotationAmount); //returns a rotation
        }

        if (Input.GetKey(KeyCode.E))
        {
            newRotation *= Quaternion.Euler(Vector3.up * -rotationAmount); //returns a rotation
        }

        transform.position = Vector3.Lerp(transform.position, newPosition, Time.deltaTime * movementTime); //lerp makes the camera smoother
        transform.rotation = Quaternion.Lerp(transform.rotation, newRotation, Time.deltaTime * movementTime); //lerp increases smoothness
    }    
}
