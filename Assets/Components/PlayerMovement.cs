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
    private bool canJump = true;

    public float maxSpeedHorizontal = 25f;
    public float maxSpeedVertical = 25f;

    private Rigidbody rb;

    private void Start()
    {
        isColliding = false;
        isGrounded = false;
        rb = GetComponent<Rigidbody>();
    }

    private void reenableJump()
    {
        canJump = true;
    }
    void OnCollisionStay()
    {
        isColliding = true;
    }

    // Update is called once per frame
    void Update()
    {
        RaycastHit hit;
        float distance = 0.3f;
        if (Physics.Raycast(transform.position, Vector3.down, out hit, distance))
        {
            Debug.DrawRay(transform.position, Vector3.down, Color.green, 2);
            //Debug.Log(transform.position.y - hit.point.y);
            //if (transform.position.y-hit.point.y < 0.3) {
                isGrounded = true;
            //}
        }


        if (Input.GetKey(KeyCode.W)/* && isGrounded && isColliding*/) {
            rb.AddForce(new Vector3(moveForce, 0, 0), ForceMode.Impulse);
        }
        if (Input.GetKey(KeyCode.S) /*&& isGrounded && isColliding*/) {
            rb.AddForce(new Vector3(-moveForce, 0, 0), ForceMode.Impulse);
        }
        if (Input.GetKey(KeyCode.A) /*&& isGrounded && isColliding*/) {
            rb.AddForce(new Vector3(0, 0, moveForce), ForceMode.Impulse);
        }
        if (Input.GetKey(KeyCode.D) /*&& isGrounded && isColliding*/) { 
            rb.AddForce(new Vector3(0, 0, -moveForce), ForceMode.Impulse);
        }
        if (Input.GetKey(KeyCode.Space) && isGrounded && isColliding && canJump) {
            rb.AddForce(new Vector3(0, 1, 0) * jumpForce, ForceMode.Impulse);
            isGrounded = false;
            canJump = false;
            Invoke("reenableJump", 1);
        }

        Vector3 newVel = rb.velocity;
        if(Mathf.Abs(rb.velocity.y) > maxSpeedVertical) {
            newVel.y = Mathf.Sign(rb.velocity.y) * maxSpeedVertical;
        }

        float horizontalVelMag = Vector3.Magnitude(new Vector3(rb.velocity.x, 0, rb.velocity.z));
        if(horizontalVelMag > maxSpeedHorizontal) {
            newVel.x = rb.velocity.x/horizontalVelMag * maxSpeedHorizontal;
            newVel.z = rb.velocity.z/horizontalVelMag * maxSpeedHorizontal;
        }

        rb.velocity = newVel;

    }
}
