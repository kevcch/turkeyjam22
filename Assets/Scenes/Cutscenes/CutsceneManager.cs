using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CutsceneManager : MonoBehaviour
{
    public int currentIndex = 0;

    public CutsceneEvent[] sequence;
    public GameObject blackScreen;


    public void Update()
    {
        
    }
    public void StartDialog()
    {
        sequence[currentIndex].dialog.GetComponent<Dialogue>().StartDialogue(gameObject);
    }

    public void NextDialog()
    {
        if (currentIndex < sequence.Length - 1)
        {
            Debug.Log(sequence[currentIndex].specialFunctionCall);

            if (!String.IsNullOrEmpty(sequence[currentIndex].specialFunctionCall))
            {
                string callback = sequence[currentIndex].specialFunctionCall;
                Debug.Log("ADSFADSF");
                currentIndex++;
                gameObject.SendMessage(callback);
            }
            else
            {
                currentIndex++;
                sequence[currentIndex].dialog.GetComponent<Dialogue>().StartDialogue(gameObject);
            }
        }
        else
        {
            if (!String.IsNullOrEmpty(sequence[currentIndex].specialFunctionCall))
            {
                string callback = sequence[currentIndex].specialFunctionCall;
                Debug.Log("ADSFADSF");
                currentIndex++;
                gameObject.SendMessage(callback);
            }else{
                //go to next scene
                gameObject.SendMessage("EndScene");
            }
        }
    }

}

[System.Serializable]
public class CutsceneEvent
{
    public GameObject dialog;
    public string specialFunctionCall;

    public CutsceneEvent(GameObject newDialog, string newSpecialFunctionCall)
    {
        dialog = newDialog;
        specialFunctionCall = newSpecialFunctionCall;
    }
}