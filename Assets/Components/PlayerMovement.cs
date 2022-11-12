using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class PlayerMovement : MonoBehaviour
{
    public float jumpForce = 2.0f;
    public float moveForce = 0.1f;
    public bool isGrounded;

    void OnCollisionStay()
    {
        isGrounded = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.W) && isGrounded) {
            GetComponent<Rigidbody>().AddForce(new Vector3(moveForce, 0, moveForce) * jumpForce, ForceMode.Impulse);
        }
        if (Input.GetKey(KeyCode.S) && isGrounded) {
            GetComponent<Rigidbody>().AddForce(new Vector3(-moveForce, 0, -moveForce) * jumpForce, ForceMode.Impulse);
        }
        if (Input.GetKey(KeyCode.A) && isGrounded) {
            GetComponent<Rigidbody>().AddForce(new Vector3(-moveForce, 0, moveForce) * jumpForce, ForceMode.Impulse);
        }
        if (Input.GetKey(KeyCode.D) && isGrounded) { 
            GetComponent<Rigidbody>().AddForce(new Vector3(moveForce, 0, -moveForce) * jumpForce, ForceMode.Impulse);
        }
        if (Input.GetKey(KeyCode.Space) && isGrounded) {
            GetComponent<Rigidbody>().AddForce(new Vector3(0, 1, 0) * jumpForce, ForceMode.Impulse);
            isGrounded = false;
        }
    }
}
