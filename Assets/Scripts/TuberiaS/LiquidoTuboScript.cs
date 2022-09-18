using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LiquidoTuboScript : MonoBehaviour
{
    
    public FragmentoLiquido [] fragmentos;
    private int fragmentoActual;

    void Start()
    {
        fragmentoActual = 1;

        if(fragmentos != null && fragmentos.Length > 0)
            foreach(FragmentoLiquido frag in fragmentos)
            {
                frag.delTope += FragmentoAlTope;
            }
    }

    public void ActualizarLiquido(float cantidadLiquido)
    {

    }

    private void FragmentoAlTope()
    {

    }
}
