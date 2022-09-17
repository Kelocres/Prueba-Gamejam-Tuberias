using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FragmentoLiquido : MonoBehaviour
{
    public GameObject[] cilindros;
    public ParticleSystem[] derrames;
    // Start is called before the first frame update
    void Start()
    {
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

    // Update is called once per frame
    void Update()
    {
        
    }
}
