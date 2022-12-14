using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Dialogue : MonoBehaviour
{
    //Holds the lines currently used
    public Line[] lines;
    
    public GameObject dialogueBox;
    public Text dialogueText;

    //Array of chars for text
    private char[] sentenceArray;

    //public GameObject nameBox;
    public Text nameText;

    public Image portrait;


    //Check if the dialogue manager is active
    public bool dialogueActive;

    //Record which line you are on
    public int lineCounter;

    public float scrollInterval = 0.02f;
    //detect when you are on the last line so you can end dialogue
    public bool lastLine;

    //force player to wait until the character is finished talking
    public bool canContinue = true;

    private GameObject callbackObject; //Object for DialogueManager to notify via BroadcastMessage that dialogue is over

    void Start(){
        //StartDialogue(DialogueType.INTRO); //DEBUG only
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0) && canContinue && dialogueActive)
        {
            if (lastLine)
            {
                EndDialogue();
            }
            else
            {
                StartCoroutine(NextSentence());
                //Debug.Log("Continue Dialogue");
            }
        }
    }

    public void StartDialogue(GameObject myCallbackObject=null, string myCallbackFunction=null)
    {
        canContinue = true;

        callbackObject = myCallbackObject;

        dialogueActive = true;
        dialogueBox.SetActive(true);
        //nameBox.SetActive(true);
        nameText.gameObject.SetActive(true);
        portrait.gameObject.SetActive(true);
        StartCoroutine(NextSentence());
    }

    void EndDialogue()
    {
        dialogueBox.SetActive(false);
        //nameBox.SetActive(false);
        nameText.gameObject.SetActive(false);
        portrait.gameObject.SetActive(false);
        dialogueActive = false;
        lineCounter = 0;
        lastLine = false;
        //gameObject.SetActive(false);
        if(callbackObject){
            callbackObject.BroadcastMessage("NextDialog");
        }
    }

    IEnumerator NextSentence()
    {
        canContinue = false;
        dialogueText.text = lines[lineCounter].text;
        dialogueText.text = "";
        nameText.text = lines[lineCounter].name;
        portrait.sprite = lines[lineCounter].portrait;

        sentenceArray = lines[lineCounter].text.ToCharArray();

        for (int i = 0; i < lines[lineCounter].text.Length; i++)
        {
            dialogueText.text += sentenceArray[i];
            //FindObjectOfType<AudioManager>().Play("TextScrollBlip");
            yield return new WaitForSeconds(scrollInterval);
            //FindObjectOfType<AudioManager>().GetComponent<AudioManager>().Stop("TextScrollBlip");
        }

        
        
        lineCounter += 1;
        if(lineCounter == lines.Length)
        {
            lastLine = true;
        }
        canContinue = true;

    }
}

[System.Serializable]
public class Line
{
    [TextArea(2, 5)]
    public string text;
    public Sprite portrait;
    public string name;

    public Line(string newtext, Sprite newportrait, string newname)
    {
        text = newtext;
        portrait = newportrait;
        name = newname;
    }
}
