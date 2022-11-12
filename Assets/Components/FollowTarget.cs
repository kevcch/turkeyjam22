using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowTarget : MonoBehaviour
{
    public Transform target;

    // Update is called once per frame
    void Update()
    {
        transform.localPosition = target.position;
    }
}
