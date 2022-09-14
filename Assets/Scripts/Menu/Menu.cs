using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Menu:MonoBehaviour
{
    [SerializeField]
    private string menuName;

    [SerializeField]
    private bool open;
 

    public string MenuName { get => menuName; set => menuName = value; }
    public bool OpenM { get => open; set => open = value; }

    public void Open( )
    {
        OpenM = true;
        gameObject.SetActive(true);
    }

    public void Close( )
    {
        OpenM = false;
        gameObject.SetActive(false);
    }
}


 