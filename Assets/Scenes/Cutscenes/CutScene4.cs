using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CutScene4 : MonoBehaviour
{
    CutsceneManager cm;
    public Cinemachine.CinemachineVirtualCamera vcam;
    public GameObject alive_loaf;
    public GameObject directional_light;
    public GameObject dead_loaf;

    private void Start()
    {
        VFXSingleton.instance.fadeToAlpha();
        cm = gameObject.GetComponent<CutsceneManager>();
        cm.StartDialog();

    }

    IEnumerator deadLoafCutscene()
    {
        yield return new WaitForSeconds(0.1f);
        //AUDIO THUD

        directional_light.SetActive(false);
        alive_loaf.SetActive(false);
        dead_loaf.SetActive(true);
        vcam.LookAt = dead_loaf.transform;
        yield return new WaitForSeconds(1.5f);
        cm.StartDialog();

    }

    IEnumerator EndScene()
    {
        VFXSingleton.instance.fadeToBlack();
        yield return new WaitForSeconds(1f);
        SceneManager.LoadScene("Level2");
    }
}