using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MatchLocal : MonoBehaviour
{
    [SerializeField] Transform target;
    [SerializeField] bool mX;
    [SerializeField] bool mY;
    [SerializeField] bool mZ;
    // Update is called once per frame
    void Update()
    {
        float x = mX ? target.localPosition.x : transform.localPosition.x;
        float y = mY ? target.localPosition.y : transform.localPosition.y;
        float z = mZ ? target.localPosition.z : transform.localPosition.z;
        transform.localPosition = new Vector3(x,y,z);
    }
}
