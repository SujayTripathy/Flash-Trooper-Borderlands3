using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flash_Trooper : MonoBehaviour
{

    Rigidbody rb;
    public float speed = 100;
    private Renderer[] mat;
    float time = 0;
    public Material flashmat;
    Animator ani;
    public Material normal;
    Vector3 zero = Vector3.zero;
    // Start is called before the first frame update
    void Start()
    {
        ani = GetComponent<Animator>();
        time = Time.time;
        rb = GetComponent<Rigidbody>();
        rb.AddForce(transform.forward * speed, ForceMode.Force);
        mat = GetComponentsInChildren<Renderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.time - time>5)
        {
            time = Time.time;
            StartCoroutine("Flash");
        }

    }

    IEnumerator Flash() {
        Debug.Log("Called");
        ani.enabled = false;
        foreach (Renderer r in mat) {
            r.material = flashmat;
        }
        rb.velocity = Vector3.zero;
        rb.AddForce(transform.forward * speed/5, ForceMode.VelocityChange);
        Debug.Log("Why?");
        yield return new WaitForSeconds(0.7f);
        rb.velocity = Vector3.zero;
        rb.AddForce(transform.forward * speed, ForceMode.Force);
        //transform.Translate(Vector3.zero);
        ani.enabled = true;
        foreach (Renderer r in mat)
        {
            r.material = normal;
        }
        //time = 0;
    }

    
}
