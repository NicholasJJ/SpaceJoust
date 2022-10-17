using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fly2 : MonoBehaviour
{
    public float speed;
    //public float strafeSpeed;
    public float rotationSpeed;
    public Transform head;
    [SerializeField] Transform throttleHand;
    [SerializeField] float throttleZeroAngle;
    private Rigidbody rbody;
    // Start is called before the first frame update
    void Start()
    {
        rbody = gameObject.GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        //find rotation
        Vector3 cameraRot = head.localEulerAngles;
        cameraRot = new Vector3(EulerRemap(cameraRot.x), EulerRemap(cameraRot.y), EulerRemap(cameraRot.z));
        transform.Rotate(rotationSpeed * Time.deltaTime * cameraRot,Space.Self);

        float angle = EulerRemap(throttleHand.localEulerAngles.x);
        angle -= throttleZeroAngle;
        angle = Mathf.Abs(angle);
        var currentSpeed = Mathf.Lerp(speed, 0, angle / 90);

        rbody.velocity = transform.forward * currentSpeed;

        //Keep velocity at 0
        //rbody.velocity = Vector3.zero;
        rbody.angularVelocity = Vector3.zero;
    }

    private static float EulerRemap(float n) => ((n + 180) % 360) - 180;
}
