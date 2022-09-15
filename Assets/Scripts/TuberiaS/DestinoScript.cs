using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestinoScript : MonoBehaviour
{

    SalidaTuberiaScript salida;
    public int idDestino = -1;

    //Delegate para comunicar a ManagerScript_PuzzleTuberias que ha llegado el líquido
    public delegate void delegateDestino(int id);
    public event delegateDestino delDestino;

    void Start()
    {
        salida = transform.GetComponentInChildren<SalidaTuberiaScript>();
        salida.delSalida += ConexionSalida;
        salida.delRecibir += LlegadaDestino;
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

    private void LlegadaDestino(int idSalida)
    {
        //Verificar al ManagerScript_PuzzleTuberias que el líquido ha llegado al destino
        if (delDestino != null)
            delDestino(idDestino);
    }
}
