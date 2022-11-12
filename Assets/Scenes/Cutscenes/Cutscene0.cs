using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cutscene0 : MonoBehaviour
{
    CutsceneManager cm;

    private void Start()
    {
        cm = gameObject.GetComponent<CutsceneManager>();
        cm.StartDialog();
    }

    IEnumerator tryMe()
    {
        Debug.Log("YESSS I WORKSKSKDF:DSLKFLDSK:LDSFK:LDSK:LDsf:Ldsk:LFK");
        VFXSingleton.instance.fadeToAlpha();

        yield return new WaitForSeconds(1f);
        cm.StartDialog();
    }
}
