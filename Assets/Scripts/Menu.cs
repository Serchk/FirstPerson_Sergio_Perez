using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    [SerializeField] private float distanciaInteraccion = 10f;
    private Camera cam;
    private Transform interactuableActual;

    //[SerializeField] private GameObject[] objetos;
    Maceta scriptAbsFlor;

    void Start()
    {
        cam = Camera.main; // Obt�n la c�mara principal
    }

    void Update()
    {
        DeteccionInteractuable();
    }

    private void DeteccionInteractuable()
    {
        // Generar un rayo desde el cursor del mouse
        Ray ray = cam.ScreenPointToRay(Input.mousePosition);

        // Informaci�n del objeto impactado por el raycast
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
                    SceneManager.LoadScene(1);
                }
            }
            else if (hitInfo.transform.TryGetComponent(out Maceta2 scriptMaceta2))
            {
                interactuableActual = scriptMaceta2.transform;
                interactuableActual.GetComponent<Outline>().enabled = true;
                scriptMaceta2.PlantarFlor();
                if (Input.GetMouseButton(0))
                {
                    Application.Quit();
                    Debug.Log("Saliendo...");
                }
            }
            else if (hitInfo.transform.TryGetComponent(out Maceta3 scriptMaceta3))
            {
                interactuableActual = scriptMaceta3.transform;
                interactuableActual.GetComponent<Outline>().enabled = true;
                scriptMaceta3.PlantarFlor();
                if (Input.GetMouseButton(0))
                {
                    SceneManager.LoadScene(2);
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
            // Si no se detecta ning�n objeto, desactivar resaltado
            
            interactuableActual.GetComponent<Outline>().enabled = false;
            interactuableActual = null;
        }
    }

}
