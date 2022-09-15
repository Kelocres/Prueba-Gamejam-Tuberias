using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jugador : MonoBehaviour
{
    [SerializeField] private float speedNormal;
    [SerializeField] private float playerRotation;
    [SerializeField] private float speedRotation;
    [SerializeField] private Animator anim;

    private Rigidbody rB;
    private float movH;
    private float movV;
    private bool retardoAccion = true;

    void Start()
    {
        rB = GetComponent<Rigidbody>();
        anim = GetComponent<Animator>();
    }

    void FixedUpdate()
    {
        movH = Input.GetAxisRaw("Horizontal");
        movV = Input.GetAxisRaw("Vertical");

        if (movH != 0)
        {
            PlayerMov();
        }
        else
        {
            movH = 0;
        }

        if (movV > 0)
        {
            PlayerMov();
            anim.SetInteger("Adelante", 1);
        }
        else if (movV == 0)
        {
            movV = 0;
            anim.SetInteger("Adelante", 0);
        }

        if (movV < 0)
        {
            PlayerMov();
            anim.SetInteger("Atras", 1);
        }
        else if (movV == 0)
        {
            movV = 0;
            anim.SetInteger("Atras", 0);
        }

        if (Input.GetMouseButtonDown(0))
        {
            LanzarGancho();
            LanzarMartillo();
        }        
    }

    private void PlayerMov()
    {
        float typeMov = speedNormal;
        rB.velocity = transform.forward * typeMov * movV + new Vector3(0, rB.velocity.y, 0);
        transform.rotation *= Quaternion.Euler(0, movH * speedRotation, 0);
    }

    private void LanzarGancho()
    {
        if (retardoAccion)
        {
           anim.SetTrigger("LanzarGancho");
            retardoAccion = false;
            StartCoroutine(Retraso(5));
        }        
    }

    private void LanzarMartillo()
    {
        if (retardoAccion)
        {
            anim.SetTrigger("LanzarMartillo");
            retardoAccion = false;
            StartCoroutine(Retraso(5));
        }
    }

    IEnumerator Retraso(float time)
    {
        yield return new WaitForSeconds(time);
        retardoAccion = true;
    }
}
