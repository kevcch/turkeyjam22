using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Goal : MonoBehaviour
{

    void OnTriggerStay(Collider other) {
        if(other.tag == "Collectible") {
            //Particle effects celebration coroutine?

            //Play cutscene
            StartCoroutine(LevelManager.instance.EndScene());
        }
    }
}
