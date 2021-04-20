using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    public Animator anim;
    public Rigidbody rigid;
    public Camera cam;
    public Joystick joystick;
    public bool isJump, inAir;

    private float inputX, inputZ;
    public float speed;
    public float velRotation;

    private Vector3 movimento;


    void Start()
    {
        cam = Camera.main;
        anim = GetComponent<Animator>();
        rigid = GetComponent<Rigidbody>();
    }

    void Update()
    {
        PlayerMoveRot();
        Jump();

    }

    public void PlayerMoveRot()
    {
        inputX = joystick.Horizontal + Input.GetAxisRaw("Horizontal");
        inputZ = joystick.Vertical + Input.GetAxisRaw("Vertical");

        movimento = cam.transform.forward * inputZ + cam.transform.right * inputX;
        movimento.Normalize();
        movimento *= speed * Time.deltaTime;

        rigid.velocity = new Vector3(movimento.x, rigid.velocity.y, movimento.z);

        if (movimento != Vector3.zero)
        {
            movimento.y = 0;
            Quaternion novaDir = Quaternion.LookRotation(movimento);
            transform.rotation = Quaternion.Slerp(transform.rotation, novaDir, 1 * velRotation);
         
        }
        if (movimento.magnitude != 0 && isJump)
        {
            anim.SetBool("Run", true);
        }
        else
        {
            anim.SetBool("Run", false);
        }
        if (Input.GetKeyDown(KeyCode.H))
        {
            rigid.AddForce(Vector3.forward * 100, ForceMode.Impulse);
        }
        
    }

    public void Jump()
    {
        if (Input.GetKeyDown(KeyCode.Space) && isJump)
        {
            anim.SetBool("Run", false);
            anim.SetBool("Jump", true);
            rigid.velocity = new Vector2(rigid.velocity.x, 5);
        }

        if (isJump == false)
        {
            anim.SetBool("Jump", false);
        }
        if (inAir)
        {
            anim.SetBool("InAir", true);
        }
        else
        {
            anim.SetBool("InAir", false);
        }
       
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.layer == 8)
        {
            isJump = true;
            inAir = false;
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.layer == 8)
        {
            isJump = false;
            inAir = true;
        }
    }

}