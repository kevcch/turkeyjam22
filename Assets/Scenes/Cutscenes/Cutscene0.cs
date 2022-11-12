using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cutscene0 : MonoBehaviour
{
    // Start is called before the first frame update


    public int currentIndex = 0;

    private string[] sequence = {
        "Dialogue0",
        "Dialogue1",
        "*tryMe"
    };


    void Start()
    {
        GameObject.Find(sequence[0]).GetComponent<Dialogue>().StartDialogue(Dialogue.DialogueType.INTRO, gameObject);
    }

    public void HandleEndDialogue()
    {
        if (currentIndex < sequence.Length - 1)
        {
            currentIndex++;
            if (sequence[currentIndex].StartsWith("*"))
            {
                Invoke(sequence[currentIndex].Substring(1),0f);
            }
            else
            {
                GameObject.Find(sequence[currentIndex]).GetComponent<Dialogue>().StartDialogue(Dialogue.DialogueType.INTRO, gameObject);
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void tryMe()
    {
        Debug.Log("YESSS I WORKSKSKDF:DSLKFLDSK:LDSFK:LDSK:LDsf:Ldsk:LFK");
    }
}
