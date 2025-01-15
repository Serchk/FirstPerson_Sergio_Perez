using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Menu : MonoBehaviour
{
    [SerializeField] private float distanciaInteraccion = 10f;
    private Camera cam;
    private Transform interactuableActual;

    [SerializeField] private GameObject[] objetos;
    Maceta scriptAbsFlor;

    void Start()
    {
        cam = Camera.main; // Obtén la cámara principal
    }

    void Update()
    {
        DeteccionInteractuable();
    }

    private void DeteccionInteractuable()
    {
        // Generar un rayo desde el cursor del mouse
        Ray ray = cam.ScreenPointToRay(Input.mousePosition);

        // Información del objeto impactado por el raycast
        if (Physics.Raycast(ray, out RaycastHit hitInfo, distanciaInteraccion))
        {
            
            // Verificar si el objeto tiene un script interactuable como Maceta
            if (hitInfo.transform.TryGetComponent(out Maceta scriptMaceta))
            {
                interactuableActual = scriptMaceta.transform;
                interactuableActual.GetComponent<Outline>().enabled = true;
                scriptMaceta.PlantarFlor();
                if (Input.GetMouseButton(0))
                {
                    
                }
            }
            else if (interactuableActual != null)
            {
                //scriptAbsFlor.AbsorberFlor();
                // Desactivar resaltado si ya no hay un objeto interactuable
                interactuableActual.GetComponent<Outline>().enabled = false;
                interactuableActual = null;
            }
        }
        else if (interactuableActual != null)
        {
            // Si no se detecta ningún objeto, desactivar resaltado
            
            interactuableActual.GetComponent<Outline>().enabled = false;
            interactuableActual = null;
        }
    }

}
