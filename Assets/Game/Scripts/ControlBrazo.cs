using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlBrazo : MonoBehaviour
{
    [SerializeField] private GameObject[] tuberias;
    [SerializeField] private Animator animBrazo;

    private Transform tuboRecoger;
    private Vector3 posActual;
    private int tuboActual;
    private int tubo;

	private void Start()
	{        
        animBrazo = GetComponent<Animator>();
        tubo = 0;
        CargarTubo();
    }

	public void AnimarBrazoDejar()
    {
        animBrazo.SetTrigger("ColocarTubo");
    }

	public void CargarTubo()
    {
        //momento en el que esta arriba el brazo y carga otro tubo aleatoriamente
        switch(tubo)
        {
            case 0:
                tuboActual = tubo;
                tubo = 1;
                print("caso 1");
                break;
            case 1:
                tuboActual = tubo;
                tubo = 2;
                print("caso 2");
                break;
            case 2:
                tuboActual = tubo;
                tubo = 3;
                print("caso 3");
                break;
            case 3:
                tuboActual = tubo;
                tubo = 1;
                print("caso 4");
                break;
        }
        for (int i=0; i<=3;i++)
        {
            tuberias[i].SetActive(false);
        }
        tuberias[tuboActual].SetActive(true);
    }

    public void TuboSuelto()
    {
        //momento en el que abre la mano y suelta el tubo
        posActual = tuberias[tuboActual].transform.position;
        Instantiate(tuberias[tuboActual], posActual, Quaternion.identity);
        tuberias[tuboActual].SetActive(false);

    }

	private void OnTriggerEnter(Collider other)
	{
        print("recogido el objeto: " + other);
        other.transform.SetParent(tuboRecoger);
	}

	public void liberar()
    {
        //Vector3 posicion_var = GetComponent<Transform>().getChild(0).GetComponent<Transform>().position;
        GameObject borrarTubo = GetComponentInChildren<GameObject>();
        Destroy(borrarTubo);
    }
}
