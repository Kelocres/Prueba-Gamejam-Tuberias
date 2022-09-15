using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SalidaTuberiaScript : MonoBehaviour
{
    public int idSalida = -1;
    public bool conectado;

    //Delegate para comunicar a TuberiaScript la conexión o desconexión
    public delegate void delegateSalida(int id, bool conectado);
    public event delegateSalida delSalida;

    //Delegate para comunicar a TuberiaScript que se está llenando de líquido
    public delegate void delegateRecibir(int id);
    public event delegateRecibir delRecibir;


    //Para identificar si la conexión es a una tubería o a la fuente
    private SalidaTuberiaScript salidaConectada;

    void Start()
    {
        conectado = false;
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.GetComponent<SalidaTuberiaScript>() != null)
        {
            conectado = true;
            salidaConectada = other.GetComponent<SalidaTuberiaScript>();
            if (delSalida != null)
            {
                delSalida(idSalida, conectado);
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.GetComponent<SalidaTuberiaScript>() != null)
        {
            conectado = false;
            salidaConectada = null;
            if (delSalida != null)
            {
                delSalida(idSalida, conectado);
            }
        }
    }

    public void DarLiquido()
    {
        Debug.Log("SALIDA TUBERIA SCRIPT DarLiquido()");
        if (salidaConectada != null)
        {
            Debug.Log("SALIDA TUBERIA SCRIPT se va a dar liquido a la salida conectada");
            salidaConectada.RecibirLiquido();
        }
        else //Nivel errado
            FindObjectOfType<ManagerScript_PuzzleTuberias>().PuzzleFallido();
    }
    
    public void RecibirLiquido()
    {
        Debug.Log("SALIDA TUBERIA SCRIPT RecibirLiquido()");
        if (delRecibir != null)
        {
            Debug.Log("SALIDA TUBERIA SCRIPT Se va a recibir liquido en la tuberia/destino");
            delRecibir(idSalida);
        }
    }
}
