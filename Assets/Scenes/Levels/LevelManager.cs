using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    public static LevelManager instance;

    public string nextScene;

    void Awake() {
        instance = this;
    }

    public IEnumerator Start()
    {
        VFXSingleton.instance.fadeToAlpha();
        yield return new WaitForSeconds(1f);
        //StartCoroutine("EndScene");

    }

    public IEnumerator EndScene()
    {
        //Debug.Log("asdfasdf");
        VFXSingleton.instance.fadeToBlack();
        yield return new WaitForSeconds(1f);
        SceneManager.LoadScene(nextScene);
        if (SceneManager.GetActiveScene().name == "Cutscene2")
        {
            FindObjectOfType<AudioManager>().Stop("happyMusic");
            FindObjectOfType<AudioManager>().Play("sadMusic");
        }
        else if (SceneManager.GetActiveScene().name == "Cutscene4")
        {
            FindObjectOfType<AudioManager>().Stop("sadMusic");
            FindObjectOfType<AudioManager>().Play("deathWind");

        }
        else if (SceneManager.GetActiveScene().name == "Cutscene0")
        {
            FindObjectOfType<AudioManager>().Stop("deathWind");
            FindObjectOfType<AudioManager>().Play("happyMusic");
        }
    }

    public IEnumerator RestartScene()
    {
        VFXSingleton.instance.fadeToBlack();
        yield return new WaitForSeconds(1f);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

}