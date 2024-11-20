using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponChanger : MonoBehaviour
{
    [SerializeField] private GameObject[] armas;

    private int indiceArmaActual;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        CambiarArmaConTeclado();

        CambiarArmaConRaton();

    }

    private void CambiarArmaConRaton()
    {
        float scrollWheel = Input.GetAxis("Mouse ScrollWheel");

        if (scrollWheel > 0)
        {
            CambiarArma(indiceArmaActual + 1);
        }
        if (scrollWheel < 0)
        {
            CambiarArma(indiceArmaActual - 1);
        }
    }

    private void CambiarArmaConTeclado()
    {
        if (Input.GetKeyUp(KeyCode.Alpha1) || Input.GetKeyUp(KeyCode.Keypad1))
        {
            CambiarArma(0);
        }
        if (Input.GetKeyUp(KeyCode.Alpha2) || Input.GetKeyUp(KeyCode.Keypad2))
        {
            CambiarArma(1);
        }
        if (Input.GetKeyUp(KeyCode.Alpha3) || Input.GetKeyUp(KeyCode.Keypad3))
        {
            CambiarArma(2);
        }
        if (Input.GetKeyUp(KeyCode.Alpha4) || Input.GetKeyUp(KeyCode.Keypad3))
        {
            CambiarArma(3);
        }
    }

    private void CambiarArma(int indiceNuevaArma)
    {
        armas[indiceArmaActual].SetActive(false); 
        
        if(indiceNuevaArma < 0)
        {
            indiceNuevaArma = armas.Length - 1;
        }
        if (indiceNuevaArma > armas.Length)
        {
            indiceNuevaArma = 0;
        }  

        armas[indiceNuevaArma].SetActive(true);
        indiceArmaActual = indiceNuevaArma;
    }
}
