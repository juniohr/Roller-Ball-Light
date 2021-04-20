using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AdvancedCamera : MonoBehaviour
{
    public Transform segueObj;
    public float limiteAng = 65;
    public float inputSensit = 155;
    public float joyAngX, joyAngY;
    public float rotY, rotX;
    public Vector3 rot;
    private Quaternion localRot;
    public FixedTouchField touchField;
    private Vector2 lookAxis;

    void Start()
    {
        Init();
    }


    void FixedUpdate()
    {
        lookAxis = touchField.TouchDist;

        joyAngX = lookAxis.x;
        joyAngY = lookAxis.y;

        rotY += joyAngX * inputSensit * Time.deltaTime;
        rotX += joyAngY * inputSensit * Time.deltaTime;

        rotX = Mathf.Clamp(rotX, -limiteAng, limiteAng);
        localRot = Quaternion.Euler(-rotX, rotY, 0);
        transform.rotation = localRot;
    }

    private void LateUpdate()
    {
        transform.position = Vector3.Lerp(transform.position, segueObj.transform.position, 0.1f);
    }

    public void Init()
    {
        rot = transform.localRotation.eulerAngles;
        rotY = rot.y;
        rotX = rot.x;
    }
}
