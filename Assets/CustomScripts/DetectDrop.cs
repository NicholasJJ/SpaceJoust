using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class DetectDrop : MonoBehaviour
{
    [SerializeField] Transform home;
    [SerializeField] float dropDist;
    [SerializeField] UnityEvent dropped;
    // Update is called once per frame
    void Update()
    {
        if (Vector3.SqrMagnitude(home.position - transform.position) > dropDist * dropDist) dropped.Invoke();
    }
}
