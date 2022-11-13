using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CutScene0 : MonoBehaviour
{
    CutsceneManager cm;
    public Cinemachine.CinemachineVirtualCamera vcam;
    public Transform milk_trans;
    public Transform mixing_bowl_trans;

    private void Start()
    {
        VFXSingleton.instance.fadeToAlpha();
        cm = gameObject.GetComponent<CutsceneManager>();
        cm.StartDialog();

    }

    IEnumerator tryMe()
    {
        Debug.Log("YESSS I WORKSKSKDF:DSLKFLDSK:LDSFK:LDSK:LDsf:Ldsk:LFK");
        //VFXSingleton.instance.fadeToAlpha();

        yield return new WaitForSeconds(1f);
        cm.StartDialog();
    }

    IEnumerator panToMilk()
    {
        vcam.LookAt = milk_trans;
        yield return new WaitForSeconds(1.5f);
        cm.StartDialog();

    }

    IEnumerator panToMixingBowl()
    {
        Debug.Log("PAN TO MIX");
        vcam.LookAt = mixing_bowl_trans;
        yield return new WaitForSeconds(1.5f);
        StartCoroutine("EndScene");
    }


    IEnumerator EndScene()
    {
        VFXSingleton.instance.fadeToBlack();
        yield return new WaitForSeconds(1f);
        SceneManager.LoadScene("Level0");
    }
}
