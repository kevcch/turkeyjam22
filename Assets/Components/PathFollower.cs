using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PathFollower : MonoBehaviour
{

    public Vector3[] path = new Vector3[0];
    public float speed = 1;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(FollowPath());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator FollowPath() {
        foreach(Vector3 point in path) {
            while(Vector3.Distance(transform.position, point) > 0.1f) {
                transform.position = Vector3.MoveTowards(transform.position, point, Time.deltaTime * speed);
                yield return new WaitForEndOfFrame();
            }
        }
        System.Array.Reverse(path);
        yield return StartCoroutine(FollowPath());
    }
}
