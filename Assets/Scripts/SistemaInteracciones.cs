using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SistemaInteracciones : MonoBehaviour
{
    [SerializeField] private float distanciaInteraccion;
    Color color = Color.red;

    private Camera cam;
    private Transform interactuableActual;

    [SerializeField] private GameObject[] objetos;
    // Start is called before the first frame update
    void Start()
    {
        cam = Camera.main;
    }

    // Update is called once per frame
    void Update()
    {
        DeteccionInteractuable();
        
    }    
    private void DeteccionInteractuable()
    {
        if (Physics.Raycast(cam.transform.position, cam.transform.forward, out RaycastHit hitInfo, distanciaInteraccion))
        {

            if (hitInfo.transform.TryGetComponent(out CajaAmmo scriptCaja))
            {
                interactuableActual = scriptCaja.transform;
                interactuableActual.GetComponent<Outline>().enabled = true;

                if(Input.GetKeyDown(KeyCode.E))
                {
                    scriptCaja.AbrirCaja();
                }
            }
            else if (hitInfo.transform.TryGetComponent(out Maceta scriptMaceta))
            {
                interactuableActual = scriptMaceta.transform;
                interactuableActual.GetComponent<Outline>().enabled = true;

                if(Input.GetKeyDown(KeyCode.E) )
                {
                    scriptMaceta.PlantarFlor();
                }
            }
            else if (interactuableActual != null)
            {
                interactuableActual.GetComponent<Outline>().enabled = false;
                interactuableActual = null;
            }
        }
    }

    
}
