using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlourBar : MonoBehaviour
{
    public RectTransform rt;
    // Update is called once per frame
    void Update()
    {
        rt.sizeDelta = new Vector2(5f * FlourPointTracker.numFlourPoints, 20f);
    }
}
