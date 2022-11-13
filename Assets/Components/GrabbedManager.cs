using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrabbedManager : MonoBehaviour
{

    public bool grabbed;
    public GrabObjects grabbedObject;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.E)) {
            grabbed = false;
            grabbedObject.grabbed = false;
        }
    }
}
