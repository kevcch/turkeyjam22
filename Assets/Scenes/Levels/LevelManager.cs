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
        
    }

    public void StartRestartCoroutine() {
        StartCoroutine(RestartScene());
    }

    public IEnumerator RestartScene()
    {
        VFXSingleton.instance.fadeToBlack();
        yield return new WaitForSeconds(1f);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

}