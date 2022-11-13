using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;

public class VFXSingleton : MonoBehaviour
{
    public static VFXSingleton instance;


    void Awake()
    {

        DontDestroyOnLoad(gameObject);

        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
            return;
        }

    }

    public void fadeToBlack()
    {
        transform.Find("Panel").GetComponent<Image>().DOColor(Color.black, .6f).SetEase(Ease.InQuad);
    }

    public void flickerToBlack()
    {
        transform.Find("Panel").GetComponent<Image>().DOColor(Color.black, .1f).SetEase(Ease.InOutBounce).SetLoops(7, LoopType.Yoyo);
    }
    public void fadeToAlpha()
    {
        transform.Find("Panel").GetComponent<Image>().DOColor(Color.clear, .6f).SetEase(Ease.InQuad);
    }
}
