using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;

public class UI_Puzzle : MonoBehaviour
{
    //Para poder utilizar los TextMeshPro_Text:
    //https://learn.unity.com/tutorial/working-with-textmesh-pro#

    public TMP_Text estadoTuberias;
    public TMP_Text estadoDestinos;
    public TMP_Text puzzleCompletado;
    public TMP_Text puzzleFallido;

    TuberiaScript[] tuberias;
    ManagerScript_PuzzleTuberias manager;
    public Button iniciar;
    void Start()
    {
        iniciar = GameObject.FindGameObjectWithTag("btnIniciar").GetComponent<Button>();
        iniciar.interactable = true;

        tuberias = FindObjectsOfType<TuberiaScript>();
        manager = FindObjectOfType<ManagerScript_PuzzleTuberias>();

        if (puzzleFallido != null)
            puzzleFallido.enabled = false;
        if (puzzleCompletado != null)
            puzzleCompletado.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        
        //Debug.Log("UI_PUZZLE if (manager.puzzleIniciado) -> ");
        if (manager.puzzleIniciado)
        {
            //Debug.Log("true");
            //Debug.Log("UI_PUZZLE if (iniciar != null) -> ");
            if (iniciar != null)
            {
                //Debug.Log("true");
                iniciar.interactable = false;
            }
            //Debug.Log("if (estadoTuberias != null)");
            if (estadoTuberias != null)
            {
                //Debug.Log("true");
                estadoTuberias.text = "";
                string texto = "ESTADO TUBERIAS: \n";
                string linea;
                for (int i = 0; i < tuberias.Length; i++)
                {
                    linea = "Tuberia " + i + ": " + tuberias[i].cantidadLiquido + "\n";
                    texto = texto + linea;
                }
                estadoTuberias.text = texto;
            }

            //Debug.Log("if (estadoDestinos != null)");
            if (estadoDestinos != null)
            {
                //Debug.Log("true");
                estadoDestinos.text = "";
                string texto = "ESTADO DESTINOS: \n";
                string linea;
                foreach (bool destino in manager.destinosLlenados)
                {
                    if (destino) linea = "O  ";
                    else linea = "X  ";

                    texto = texto + linea;
                }
                estadoDestinos.text = texto;
            }

        }

        if(manager.puzzleFallido && puzzleFallido!= null)
        {
            puzzleFallido.enabled = true;
        }
        else if(manager.puzzleCompletado && puzzleCompletado!= null)
        {
            puzzleCompletado.enabled = true;
        }



    }
}
