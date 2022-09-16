using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TuberiaScript : MonoBehaviour
{
    // Para recoger los delegates de las salidas
    List <SalidaTuberiaScript> salidas;

    public int entradaLiquido = -1;
    //public int salidaLiquido = -1;

    public float cantidadLiquido = 0f;
    public float velocidadLiquido = 100f;

    public bool inamovible;
    public bool llenandose; //La tuberia se est� llenando de l�quido
    private bool lleno; //La tuber�a est� definitivamente llena y con todas sus salidas dando l�quido
    public bool conectado;

    //public bool conectado;
    //public bool conectado_a_fuente;
    //public int posicion_fila;
    //private FuenteScript fuenteConectada;

    void Start()
    {
        inamovible = false;
        llenandose = false;
        lleno = false;
        conectado = false;
        //Recoger los delegates de las salidas
        salidas = new List<SalidaTuberiaScript>();
        
        int numChild = 0;
        //while(numChild <salidas.Length && transform.GetChild(numChild).GetComponent<SalidaTuberiaScript>() != null)
        for (int i = 0; i < transform.childCount; ++i)
        {
            if (transform.GetChild(i).GetComponent<SalidaTuberiaScript>() != null)
            {
                salidas.Add(transform.GetChild(i).GetComponent<SalidaTuberiaScript>());
                salidas[numChild].idSalida = numChild;
                salidas[numChild].delSalida += ConexionSalida;
                salidas[numChild].delRecibir += RellenarTuberia;

                numChild++;
            }
        }
        Debug.Log("Numero salidas: " + salidas.Count);

        //conectado_a_fuente = false;
        //posicion_fila = -1;
        
    }

    // Update is called once per frame
    void Update()
    {
        //Movimiento de la tuberia
        //if(inamovible) no se puede mover

        if (llenandose && !lleno && cantidadLiquido < 100f)
        {
            //cantidadLiquido += velocidadLiquido * Time.deltaTime;
            cantidadLiquido += 1;
            if(cantidadLiquido >= 100f)
            {
                cantidadLiquido = 100f;
                lleno = true;
                RellenarOtrasTuberias();
            }
        }
    }

    private void ConexionSalida(int idSalida, bool conect)
    {
        if(conect)
        {
            Debug.Log("Conectado");
            conectado = true;
            /*
            if(fuente != null)
            {
                fuenteConectada = fuente;
                fuenteConectada.PrimeraConexion(this);
            }
            else if(otraTuberia != null)
            {

            }*/


        }
        else
        {
            Debug.Log("Desconectado");
            conectado = false;
        }
    }

    private void RellenarTuberia(int idSalida)
    {
        entradaLiquido = idSalida;
        inamovible = true;
        llenandose = true;
    }

    private void RellenarOtrasTuberias()
    {
        for(int i=0; i<salidas.Count; i++)
        {
            if(i != entradaLiquido)
            {
                salidas[i].DarLiquido();
            }
        }

        lleno = true;
    }

    public bool EstaLleno()
    {
        //return llenandose && cantidadLiquido == 100f;
        return lleno;
    }
}
