using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FragmentoLiquido : MonoBehaviour
{
    public GameObject[] cilindros;
    public ParticleSystem[] derrames;

    //Para identificarlo en el orden de fragmentos 
    //public int posicionFragmento;

    public float escaladoMaximo = 1f;
    public float escalado;

    //Por si el fragmento empiza a la mitad del tubo
    public float escaladoInicial;
    public bool lleno;
    public bool derramandose;
    // Start is called before the first frame update

    //Delegate para notificar a LiquidoTuboScript que se ha alcanzado el tope de escalado
    public delegate void delegateTope();
    public event delegateTope delTope;
    void Start()
    {
        escalado = 0f;
        escaladoInicial = 0f;
        lleno = false;
        derramandose = false;

        if(cilindros != null && cilindros.Length > 0)
            foreach(GameObject cil in cilindros)
            {
                cil.transform.localScale += new Vector3(1, 0, 1);
                cil.GetComponent<MeshRenderer>().enabled = false;
            }

        if(derrames != null && derrames.Length > 0)
            foreach(ParticleSystem derr in derrames)
            {
                derr.Pause();
            }

    }

    public void EmpiezaLiquido(float actual, float tope)
    {
        if (cilindros != null && cilindros.Length > 0)
            foreach (GameObject cil in cilindros)
            {
                cil.GetComponent<MeshRenderer>().enabled = true;
            }

        escaladoInicial = actual;
        escalado = escaladoInicial;
        escaladoMaximo = tope;
    }
    
    
    public void ActualizaLiquido(float cantidad)
    {
        if (!lleno)
        {
            escalado = cantidad;
            if (cilindros != null && cilindros.Length > 0)
                foreach (GameObject cil in cilindros)
                {
                    cil.transform.localScale += new Vector3(1, escalado - escaladoInicial, 1);

                }

            //Si se llega al tope, delegate al LiquidoTuboScript
            if (escalado >= escaladoMaximo)
            {
                escalado = escaladoMaximo;
                lleno = true;
                if (delTope != null)
                {
                    delTope();
                }
            }
        }
    }

    public void ActivarDerrame()
    {
        if (derrames != null && derrames.Length > 0)
            foreach (ParticleSystem derr in derrames)
            {
                derr.Play();
            }
    }
}
