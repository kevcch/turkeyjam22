using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TextHintManager : MonoBehaviour
{
    public Transform grabbableObject;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float offset = 1;
        this.transform.rotation = Quaternion.Euler(0.0f, 45f, grabbableObject.rotation.z * -1.0f);
        Vector3 newPos = grabbableObject.position;
        newPos.y += offset;
        this.transform.position = newPos;
    }
}
