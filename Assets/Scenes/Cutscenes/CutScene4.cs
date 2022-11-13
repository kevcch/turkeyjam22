using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CutScene4 : MonoBehaviour
{
    CutsceneManager cm;

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

    IEnumerator EndScene()
    {
        VFXSingleton.instance.fadeToBlack();
        yield return new WaitForSeconds(1f);
        SceneManager.LoadScene("Level4");
    }
}
