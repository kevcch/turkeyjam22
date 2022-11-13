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
    public GameObject post_death_objects;
    public GameObject dead_loaf;

    private void Start()
    {
        VFXSingleton.instance.fadeToAlpha();
       
        cm = gameObject.GetComponent<CutsceneManager>();
        cm.StartDialog();
    }

    IEnumerator deadLoafCutscene()
    {
        VFXSingleton.instance.flickerToBlack();
        yield return new WaitForSeconds(2f);
        vcam.LookAt = dead_loaf.transform;

        //AUDIO THUD
        //FindObjectOfType<AudioManager>().Play("THUD");
        yield return new WaitForSeconds(0.5f);
        //AUDIO SCREAM
        //FindObjectOfType<AudioManager>().Play("SCREAM");
        directional_light.SetActive(false);
        alive_loaf.SetActive(false);
        post_death_objects.SetActive(true);
        VFXSingleton.instance.fadeToAlpha();
        yield return new WaitForSeconds(1f);
        cm.StartDialog();

    }

    IEnumerator EndScene()
    {
        VFXSingleton.instance.fadeToBlack();
        yield return new WaitForSeconds(1f);
        SceneManager.LoadScene("Level2");
    }
}