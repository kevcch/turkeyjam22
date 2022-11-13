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
    public GameObject hint;

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
        if(grabbed) {
            gameObject.GetComponent<Collider>().enabled = false;
        } else {
            gameObject.GetComponent<Collider>().enabled = true;
        }
    }

    void OnCollisionStay(Collision collision) {
        if(collision.gameObject.tag == "Player" && !grabManager.grabbed && !grabbed) {
            hint.SetActive(true);
            hint.GetComponent<TextHintManager>().grabbableObject = transform;
            if (Input.GetKey(KeyCode.E)) {
                hint.SetActive(false);
                grabbed = true;
                offset = transform.position - collision.transform.position;
                if (gameObject.tag == "Collectible")
                {
                    FindObjectOfType<AudioManager>().Play("collectiblePickup");
                }
                else
                {
                    FindObjectOfType<AudioManager>().Play("propPickup");
                }
                StartCoroutine(GrabDelay());
            }
        }
    }

    void OnCollisionExit() {
        hint.SetActive(false);
    }

    IEnumerator GrabDelay() {
        yield return new WaitForSeconds(0.5f);
        grabManager.grabbed = true;
        grabManager.grabbedObject = this;
    }
}
