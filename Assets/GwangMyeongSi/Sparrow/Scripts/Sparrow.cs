using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sparrow : MonoBehaviour
{
    private Animator sparrow;
    public float gravity = 1.0f;
    private Vector3 moveDirection = Vector3.zero;
    CharacterController characterController;
    // Start is called before the first frame update
    void Start()
    {
        sparrow = GetComponent<Animator>();
        characterController = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        characterController.Move(moveDirection * Time.deltaTime);
        moveDirection.y = gravity * Time.deltaTime;
        if (sparrow.GetCurrentAnimatorStateInfo(0).IsName("idle1"))
        {
            sparrow.SetBool("preen", false);
            sparrow.SetBool("peck", false);
            sparrow.SetBool("fallin", false);
            sparrow.SetBool("fly", false);
            sparrow.SetBool("hop", false);
        }
        if (sparrow.GetCurrentAnimatorStateInfo(0).IsName("idle2"))
        {
            sparrow.SetBool("preen", false);
            sparrow.SetBool("peck", false);
        }
        if (sparrow.GetCurrentAnimatorStateInfo(0).IsName("fly"))
        {
            sparrow.SetBool("takeoff", false);
            sparrow.SetBool("landing", false);
            sparrow.SetBool("hop", false);
            sparrow.SetBool("hopleft", false);
            sparrow.SetBool("hopright", false);
        }
        if (Input.GetKeyDown(KeyCode.R))
        {
            sparrow.SetBool("preen", true);
            sparrow.SetBool("idle1", false);
            sparrow.SetBool("idle2", false);
        }
        if (Input.GetKeyDown(KeyCode.F))
        {
            sparrow.SetBool("peck", true);
            sparrow.SetBool("idle1", false);
            sparrow.SetBool("idle2", false);
        }
        if (Input.GetKeyDown(KeyCode.W))
        {
            sparrow.SetBool("hop", true);
            sparrow.SetBool("idle1", false);
            sparrow.SetBool("idle2", false);
        }
        if (Input.GetKeyUp(KeyCode.W))
        {
            sparrow.SetBool("idle1", true);
            sparrow.SetBool("hop", false);
        }
        if (Input.GetKeyDown(KeyCode.A))
        {
            sparrow.SetBool("hopleft", true);
            sparrow.SetBool("hop", false);
            sparrow.SetBool("idle1", false);
            sparrow.SetBool("flyleft", true);
            sparrow.SetBool("fly", false);
        }
        if (Input.GetKeyUp(KeyCode.A))
        {
            sparrow.SetBool("hop", true);
            sparrow.SetBool("hopleft", false);
            sparrow.SetBool("idle1", true);
            sparrow.SetBool("fly", true);
            sparrow.SetBool("flyleft", false);
        }
        if (Input.GetKeyDown(KeyCode.D))
        {
            sparrow.SetBool("hopright", true);
            sparrow.SetBool("hop", false);
            sparrow.SetBool("idle1", false);
            sparrow.SetBool("flyright", true);
            sparrow.SetBool("fly", false);
        }
        if (Input.GetKeyUp(KeyCode.D))
        {
            sparrow.SetBool("hop", true);
            sparrow.SetBool("hopright", false);
            sparrow.SetBool("idle1", true);
            sparrow.SetBool("fly", true);
            sparrow.SetBool("flyright", false);
        }
        if (Input.GetKeyDown(KeyCode.Space))
        {
            sparrow.SetBool("takeoff", true);
            sparrow.SetBool("idle1", false);
            sparrow.SetBool("idle2", false);
        }
        if (Input.GetKeyDown(KeyCode.Space))
        {
            sparrow.SetBool("fly", false);
            sparrow.SetBool("landing", true);
        }
        if (Input.GetKeyDown(KeyCode.E))
        {
            sparrow.SetBool("fallin", true);
            sparrow.SetBool("fly", false);
        }
        if (Input.GetKeyUp(KeyCode.E))
        {
            sparrow.SetBool("fly", true);
            sparrow.SetBool("fallin", false);
        }
    }
}
