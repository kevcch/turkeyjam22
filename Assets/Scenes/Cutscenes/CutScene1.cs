using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CutScene1 : MonoBehaviour
{
    CutsceneManager cm;
    public Cinemachine.CinemachineVirtualCamera vcam;
    public Transform yeast_trans;
    //public Transform mixing_bowl_trans;

    private void Start()
    {
        VFXSingleton.instance.fadeToAlpha();
        cm = gameObject.GetComponent<CutsceneManager>();
        cm.StartDialog();
    }

    IEnumerator panToYeast()
    {
        vcam.LookAt = yeast_trans;
        yield return new WaitForSeconds(1.5f);
        cm.StartDialog();

    }

    /*
    IEnumerator panToMixingBowl()
    {
        Debug.Log("PAN TO MIX");
        vcam.LookAt = mixing_bowl_trans;
        yield return new WaitForSeconds(1.5f);
        StartCoroutine("EndScene");
    }*/


    IEnumerator EndScene()
    {
        VFXSingleton.instance.fadeToBlack();
        yield return new WaitForSeconds(1f);
        SceneManager.LoadScene("Level1");
    }
}
