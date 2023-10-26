using UnityEngine;
using System.Collections;

public class Pierisrapae : MonoBehaviour {
    Animator pieris;
    private IEnumerator coroutine;
	// Use this for initialization
	void Start () {
        pieris = GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKey(KeyCode.S))
        {
            pieris.SetBool("idle", true);
            pieris.SetBool("walk", false);
            pieris.SetBool("fly", false);
        }
        if (Input.GetKey(KeyCode.W))
        {
            pieris.SetBool("walk", true);
            pieris.SetBool("idle", false);
            pieris.SetBool("fly", false);
        }
        if (Input.GetKey(KeyCode.A))
        {
            pieris.SetBool("turnleft", true);
            pieris.SetBool("walk", false);
            pieris.SetBool("idle", false);
            StartCoroutine("idle");
        }
        if (Input.GetKey(KeyCode.D))
        {
            pieris.SetBool("turnright", true);
            pieris.SetBool("walk", false);
            pieris.SetBool("idle", false);
            StartCoroutine("idle");
        }
        if (Input.GetKey(KeyCode.Space))
        {
            pieris.SetBool("takeoff", true);
            pieris.SetBool("idle", false);
            StartCoroutine("fly");
        }
        if (Input.GetKey(KeyCode.Space))
        {
            pieris.SetBool("landing", true);
            pieris.SetBool("fly", false);
            StartCoroutine("idle");
        }
	}
    IEnumerator idle()
    {
        yield return new WaitForSeconds(0.5f);
        pieris.SetBool("idle", true);
        pieris.SetBool("turnleft", false);
        pieris.SetBool("turnright", false);
        pieris.SetBool("walk", false);
        pieris.SetBool("landing", false);
        pieris.SetBool("fly", false);
    }
    IEnumerator fly()
    {
        yield return new WaitForSeconds(0.6f);
        pieris.SetBool("fly", true);
        pieris.SetBool("takeoff", false);
    }
}
