using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponChanger : MonoBehaviour
{
    [SerializeField] private GameObject[] objetos;

    private int indiceObjetoActual;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        CambiarObjetoConTeclado();

        //CambiarArmaConRaton();

    }

    //private void CambiarArmaConRaton()
    //{
    //    float scrollWheel = Input.GetAxis("Mouse ScrollWheel");

    //    if (scrollWheel > 0)
    //    {
    //        CambiarArma(indiceArmaActual + 1);
    //    }
    //    if (scrollWheel < 0)
    //    {
    //        CambiarArma(indiceArmaActual - 1);
    //    }
    //}

    private void CambiarObjetoConTeclado()
    {
        if (Input.GetKeyUp(KeyCode.Alpha1) || Input.GetKeyUp(KeyCode.Keypad1))
        {
            CambiarObjeto(0);
        }
        if (Input.GetKeyUp(KeyCode.Alpha2) || Input.GetKeyUp(KeyCode.Keypad2))
        {
            CambiarObjeto(1);
        }
        if (Input.GetKeyUp(KeyCode.Alpha3) || Input.GetKeyUp(KeyCode.Keypad3))
        {
            CambiarObjeto(2);
        }
        if (Input.GetKeyUp(KeyCode.Alpha4) || Input.GetKeyUp(KeyCode.Keypad4))
        {
            CambiarObjeto(3);
        }
        if (Input.GetKeyUp(KeyCode.Alpha5) || Input.GetKeyUp(KeyCode.Keypad5))
        {
            CambiarObjeto(4);
        }

    }

    private void CambiarObjeto(int indiceNuevaArma)
    {
        objetos[indiceObjetoActual].SetActive(false); 
        
        if(indiceNuevaArma < 0)
        {
            indiceNuevaArma = objetos.Length - 1;
        }
        if (indiceNuevaArma > objetos.Length)
        {
            indiceNuevaArma = 0;
        }  

        objetos[indiceNuevaArma].SetActive(true);
        indiceObjetoActual = indiceNuevaArma;
    }
}
