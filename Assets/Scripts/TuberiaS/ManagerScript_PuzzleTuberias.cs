using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ManagerScript_PuzzleTuberias : MonoBehaviour
{
    //Arrays de las fuentes y de los destinos
    private FuenteScript[] fuentes;
    private DestinoScript[] destinos;

    //Para comprobar y mostrar si los destinos están o no llenados
    public bool[] destinosLlenados;
    public int destinos_por_llenar;

    public bool puzzleIniciado;
    public bool puzzleFallido;
    public bool puzzleCompletado;

    void Start()
    {
        fuentes = FindObjectsOfType<FuenteScript>();
        destinos = FindObjectsOfType<DestinoScript>();

        for(int i=0; i<destinos.Length; i++)
        {
            destinos[i].idDestino = i;
            destinos[i].delDestino += LlegadaDestino;
        }

        destinosLlenados = new bool[destinos.Length];
        destinos_por_llenar = destinos.Length;

        puzzleIniciado = false;
        puzzleFallido = false;
        puzzleCompletado = false;
    }


    public void IniciarPuzzle()
    {
        if (!puzzleIniciado)
        {
            puzzleIniciado = true;
            foreach (FuenteScript fuente in fuentes)
                fuente.IniciarLiquido();
        }
    }

    private void LlegadaDestino(int idDestino)
    {
        destinosLlenados[idDestino] = true;
        destinos_por_llenar--;

        if (destinos_por_llenar == 0)
            PuzzleCompletado();
    }

    private void PuzzleCompletado()
    {
        if(!puzzleFallido)
        {
            Debug.Log("PUZZLE COMPLETADO");
            puzzleCompletado = true;
            
        }
    }

    public void PuzzleFallido()
    {
        Debug.Log("PUZZLE FALLIDO");
        puzzleFallido = true;
        Time.timeScale = 0;
    }
}
