using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraPlayer : MonoBehaviour
{
    public Transform characterHead;
    public Transform posCam;
    private RaycastHit hit;
    public float velRot, rotacao; 


    void Update()
    {
        RotacaoCam();
    }

    private void LateUpdate()
    {
        transform.LookAt(characterHead);
        if (! Physics.Linecast(transform.position, posCam.position))
        {
            transform.position = Vector3.Lerp(transform.position, posCam.position, 0.06f);
        }
        else if (Physics.Linecast(characterHead.position, posCam.position, out hit))
        {
            transform.position = Vector3.Lerp(transform.position, hit.point, 0.06f);
        }
    }

    void RotacaoCam()
    {
        rotacao = Input.GetAxis("Mouse X") * velRot;
        rotacao *= Time.deltaTime;
        characterHead.Rotate(0,rotacao,0);
    }
}
