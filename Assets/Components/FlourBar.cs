using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FlourBar : MonoBehaviour
{
    public RectTransform rt;
    // Update is called once per frame
    void Update()
    {
        rt.sizeDelta = new Vector2(5f * FlourPointTracker.numFlourPoints, 20f);
        if(FlourPointTracker.numFlourPoints <= 0) {
            StartCoroutine(Death());
        }
    }

    IEnumerator Death() {
        yield return new WaitForSeconds(1f);
        FlourPointTracker.numFlourPoints = 100;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
