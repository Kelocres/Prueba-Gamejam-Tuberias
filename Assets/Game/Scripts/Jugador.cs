using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;


public class Jugador : MonoBehaviour
{
    [SerializeField] private float speedNormal;
    [SerializeField] private float playerRotation;
    [SerializeField] private float speedRotation;
    [SerializeField] private Animator anim;
    
    //Seleccion de herramienta
    [SerializeField] private string herramientaActual;
    [SerializeField] private TMP_Text herramientaTxt;
    
    //Herramientas para equipar
    [SerializeField] private GameObject martilloEquip, soldadorEquip, selladorEquip;

    private Rigidbody rB;
    private float movH;
    private float movV;

    private bool retardoAccion = true;

	private void Awake()
	{
        herramientaTxt = GameObject.FindGameObjectWithTag("HerramientaTxt").GetComponent<TMP_Text>();
    }

	void Start()
    {
        rB = GetComponent<Rigidbody>();
        anim = GetComponent<Animator>();
        herramientaActual = "Martillo";        
        martilloEquip.SetActive(true);
    }

	private void Update()
	{
        if (Input.GetMouseButtonDown(0))
        {
            if(herramientaActual == "Martillo")
            {
                LanzarMartillo();
			}
            if (herramientaActual == "Soldador")
            {
                Soldar();
            }
            if (herramientaActual == "Sellador")
            {
                LanzarGancho();
            }            
        }
        herramientaTxt.text = herramientaActual;
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

    private void Soldar()
    {
        if (retardoAccion)
        {
            anim.SetTrigger("Soldar");
            retardoAccion = false;
            StartCoroutine(Retraso(5));
        }
    }

    IEnumerator Retraso(float time)
    {
        yield return new WaitForSeconds(time);
        retardoAccion = true;
    }

	private void OnTriggerEnter(Collider other)
	{
        //verificar colision
        if(other.CompareTag("Martillo"))
        {
            print("seleccionar martillo");
            soldadorEquip.SetActive(false);
            selladorEquip.SetActive(false);
            martilloEquip.SetActive(true);
            herramientaActual = "Martillo";
        }

        if (other.CompareTag("Soldador"))
        {
            print("seleccionar Soldador");
            selladorEquip.SetActive(false);
            martilloEquip.SetActive(false);
            soldadorEquip.SetActive(true);
            herramientaActual = "Soldador";
        }

        if (other.CompareTag("Sellador"))
        {
            print("seleccionar Sellador");            
            martilloEquip.SetActive(false);
            soldadorEquip.SetActive(false);
            selladorEquip.SetActive(true);
            herramientaActual = "Sellador";
        }

    }
}
