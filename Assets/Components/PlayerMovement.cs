using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class PlayerMovement : MonoBehaviour
{
    public float jumpForce = 25.0f;
    public float moveForce = 2.0f;
    public bool isColliding;
    public bool isGrounded;

    private void Start()
    {
        isColliding = false;
        isGrounded = false;
    }
    void OnCollisionStay()
    {
        isColliding = true;
    }

    // Update is called once per frame
    void Update()
    {
        RaycastHit hit;
        float distance = 10f;
        if (Physics.Raycast(transform.position, Vector3.down, out hit, distance))
        {
            Debug.Log(transform.position.y - hit.point.y);
            if (transform.position.y-hit.point.y < 0.3)
                isGrounded = true;
        }


        if (Input.GetKey(KeyCode.W) && isGrounded && isColliding) {
            GetComponent<Rigidbody>().AddForce(new Vector3(moveForce, 0, 0), ForceMode.Impulse);
        }
        if (Input.GetKey(KeyCode.S) && isGrounded && isColliding) {
            GetComponent<Rigidbody>().AddForce(new Vector3(-moveForce, 0, 0), ForceMode.Impulse);
        }
        if (Input.GetKey(KeyCode.A) && isGrounded && isColliding) {
            GetComponent<Rigidbody>().AddForce(new Vector3(0, 0, moveForce), ForceMode.Impulse);
        }
        if (Input.GetKey(KeyCode.D) && isGrounded && isColliding) { 
            GetComponent<Rigidbody>().AddForce(new Vector3(0, 0, -moveForce), ForceMode.Impulse);
        }
        if (Input.GetKey(KeyCode.Space) && isGrounded && isColliding) {
            GetComponent<Rigidbody>().AddForce(new Vector3(0, 1, 0) * jumpForce, ForceMode.Impulse);
            isGrounded = false;
        }
    }
}
