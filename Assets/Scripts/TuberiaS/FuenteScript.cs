using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FuenteScript : MonoBehaviour
{
    SalidaTuberiaScript salida;
    //List<TuberiaScript> listaTuberias;
    //public bool conectado;
    void Start()
    {
        salida = transform.GetComponentInChildren<SalidaTuberiaScript>();
        salida.delSalida += ConexionSalida;
        //listaTuberias = new List<TuberiaScript>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void ConexionSalida(int idSalida, bool conectado)
    {
        if (conectado)
        {
            Debug.Log("Conectado");
        }
        else
        {
            Debug.Log("Desconectado");
        }
    }

    public void IniciarLiquido()
    {
        Debug.Log("FUENTE SCRIPT IniciarLiquido()");
            salida.DarLiquido();
    }
}
