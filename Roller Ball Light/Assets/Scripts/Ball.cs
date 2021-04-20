using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    public static Ball instance;

    public Rigidbody rigid;
    public bool camLookat, isGround;
    public float force, movimento;
    public Camera cam;

    public Vector3 camRotation;

    public new AudioSource audio;
    public AudioClip[] doReMi;
    public byte contador;

    public void Awake()
    {
        instance = this;
        
    }

    void Start()
    {
        cam = Camera.main;
        rigid = GetComponent<Rigidbody>();
        audio = GetComponent<AudioSource>();
    }

    
    void Update()
    {
        if (camLookat)
        {
            cam.transform.LookAt(gameObject.transform.position);
        }
        else
        {
            cam.transform.rotation = Quaternion.Euler(camRotation);
        }

        Move();
        
        if (Input.GetKeyDown(KeyCode.Space) && isGround)
        {
            rigid.AddForce(Vector3.up * force, ForceMode.Impulse);
        }
    }

    public void Move()
    {
        float inputX = Input.GetAxis("Vertical") + Input.acceleration.y;
        float inputZ = Input.GetAxis("Horizontal") + Input.acceleration.x;

        Vector3 move = inputX * cam.transform.forward + inputZ * cam.transform.right;
        move.Normalize();
        move *= movimento;

        if (move != Vector3.zero)
        {
            move.y = 0;
            Quaternion novaDir = Quaternion.LookRotation(move);
            transform.rotation = Quaternion.Slerp(transform.rotation, novaDir, 1 * 1);

        }

        rigid.velocity = new Vector3(move.x, rigid.velocity.y, move.z);
    }

    public void Jump()
    {
        if (isGround)
        {
            rigid.AddForce(Vector3.up * force, ForceMode.Impulse);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.layer == 8)
        {
            isGround = true;

            contador++;

            if (contador > 2)
            {
                contador = 0;
            }

            if (contador == 0)
            {
                audio.clip = doReMi[0];
                audio.Play();
            }
            else if (contador == 1)
            {
                audio.clip = doReMi[1];
                audio.Play();
            }
            else
            {
                audio.clip = doReMi[2];
                audio.Play();
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.layer == 8)
        {
            isGround = false;
        }
    }
}
