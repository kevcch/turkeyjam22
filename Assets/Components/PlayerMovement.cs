using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class PlayerMovement : MonoBehaviour
{
    public float jumpForce = 30.0f;
    public float moveForce = 3.0f;
    public bool isColliding;
    public bool IsGrounded
    {
        get { return isGrounded; }
        set
        {
            if (isGrounded == value)
                return;
            isGrounded = value;
            if (OnIsGroundedChange != null)
                OnIsGroundedChange(isGrounded);
        }
    }
    private bool isGrounded = true;
    public delegate void OnIsGroundedChangeDelegate(bool isGrounded);
    public event OnIsGroundedChangeDelegate OnIsGroundedChange;
    private bool canJump = true;
    public bool fourty_five_mode = false;

    public float maxSpeedHorizontal = 25f;
    public float maxSpeedVertical = 25f;

    private Rigidbody rb;

    public bool EnteredTrigger;
    private float stepTimer = 0;
    private float baseStepPeriod = 3f;
    private float stepPeriod = 1f;
    private float minStepRate = 0.3f;
    private float maxStepRate = 3f;
    private float minMovementSoundSpeed = .5f;
    private float landVelocity;

    public void OnTriggerEnter(Collider other)
    {
        //Debug.Log(other.tag);
        if (other.tag == "FlourPointRestore")
            EnteredTrigger = true;
    }

    private void Start()
    {
        isColliding = false;
        isGrounded = false;
        rb = GetComponent<Rigidbody>();
        OnIsGroundedChange += OnIsGroundedChangeHandler;
    }

    private void OnIsGroundedChangeHandler(bool isGrounded)
    {
        if (isGrounded)
        {
            FindObjectOfType<AudioManager>().PlayWithNewVolume("playerLand", landVelocity);
        }
        else
        {
            FindObjectOfType<AudioManager>().PlayPitchRandom("playerJump", .7f, .8f);
        }
    }

    void Update()
    {
        stepTimer += Time.deltaTime;
        stepPeriod = Mathf.Clamp(baseStepPeriod - rb.velocity.magnitude, minStepRate, maxStepRate);
        if (stepTimer > stepPeriod && isGrounded && rb.velocity.magnitude > minMovementSoundSpeed)
        {
            FindObjectOfType<AudioManager>().PlayGroupRandomPitch("movement");
            stepTimer = 0f;
        }

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
    void FixedUpdate()
    {
        RaycastHit hit;
        float distance = 0.15f;
        if (Physics.Raycast(transform.position, Vector3.down, out hit, distance))
        {
            Debug.DrawRay(transform.position, Vector3.down, Color.green, 2);
            //Debug.Log(transform.position.y - hit.point.y);
            //if (transform.position.y-hit.point.y < 0.3) {
            landVelocity = Mathf.Clamp(Mathf.Abs(rb.velocity.y * .2f), .5f, 1f);
            IsGrounded = true;
            //}
        }
        //Debug.Log(isGrounded);
        if (Input.GetKeyDown(KeyCode.T)) {
            fourty_five_mode = !fourty_five_mode;
        }
        if (Input.GetKey(KeyCode.W)/* && isGrounded && isColliding*/) {
            rb.AddForce(new Vector3(moveForce, 0, fourty_five_mode ? 0 : moveForce), ForceMode.Impulse);
        }
        if (Input.GetKey(KeyCode.S) /*&& isGrounded && isColliding*/) {
            rb.AddForce(new Vector3(-moveForce, 0, fourty_five_mode ? 0 : -moveForce), ForceMode.Impulse);
        }
        if (Input.GetKey(KeyCode.A) /*&& isGrounded && isColliding*/) {
            rb.AddForce(new Vector3(fourty_five_mode ? 0 : -moveForce, 0, moveForce), ForceMode.Impulse);
        }
        if (Input.GetKey(KeyCode.D) /*&& isGrounded && isColliding*/) {
            rb.AddForce(new Vector3(fourty_five_mode ? 0 : moveForce, 0, -moveForce), ForceMode.Impulse);
        }
        if (Input.GetKey(KeyCode.Space) && isGrounded && isColliding && canJump) {
            rb.AddForce(new Vector3(0, 1, 0) * jumpForce, ForceMode.Impulse);
            IsGrounded = false;
            canJump = false;
            Invoke("reenableJump", 1);
        }

        // Velocity Cap
        Vector3 newVel = rb.velocity;
        if (Mathf.Abs(rb.velocity.y) > maxSpeedVertical) {
            newVel.y = Mathf.Sign(rb.velocity.y) * maxSpeedVertical;
        }

        float horizontalVelMag = Vector3.Magnitude(new Vector3(rb.velocity.x, 0, rb.velocity.z));
        if (horizontalVelMag > maxSpeedHorizontal) {
            newVel.x = rb.velocity.x / horizontalVelMag * maxSpeedHorizontal;
            newVel.z = rb.velocity.z / horizontalVelMag * maxSpeedHorizontal;
        }

        rb.velocity = newVel;

        // Flour Points
        if (rb.velocity.magnitude * FlourPointTracker.point_multiplier >= 0.01) {
            FlourPointTracker.numFlourPoints -= rb.velocity.magnitude * FlourPointTracker.point_multiplier;
        }
    }
}
