using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrabObjects : MonoBehaviour
{
    //private Transform playerParent;
    private Transform player;
    private Vector3 offset;
    private GrabbedManager grabManager;
    public bool grabbed;

    void Start()
    {
        player = GameObject.FindWithTag("Player").transform;
        //player = playerParent.transform.GetChild(0);
        grabManager = player.GetComponent<GrabbedManager>();
        
    }

    void Update() {
        if(grabManager.grabbed && grabbed) {
            transform.position = player.position + offset;
        }
    }

    void OnCollisionEnter(Collision collision) {
        if(collision.gameObject.tag == "Player" && !grabManager.grabbed && !grabbed) {
            grabbed = true;
            grabManager.grabbed = true;
            grabManager.grabbedObject = this;
            offset = transform.position - collision.transform.position;
        }
    }
}
