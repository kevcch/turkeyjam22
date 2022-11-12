using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cutscene0 : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        GameObject.Find("Dialogue").GetComponent<Dialogue>().StartDialogue(Dialogue.DialogueType.INTRO);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
