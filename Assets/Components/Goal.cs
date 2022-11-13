using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Goal : MonoBehaviour
{

    void OnTriggerStay(Collider other) {
        if(other.tag == "Collectible") {
            //Particle effects celebration coroutine
            StartCoroutine(Celebration());
        }
    }

    IEnumerator Celebration() {
        gameObject.GetComponent<ParticleSystem>().Play();
        //Play cutscene
        yield return StartCoroutine(LevelManager.instance.EndScene());
    }
}
