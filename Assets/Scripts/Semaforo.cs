using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Semaforo : MonoBehaviour
{
    private bool yaEjecutado = false;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(EjemploSemaforo());
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && yaEjecutado == false)
        {
            yaEjecutado=true;
            StartCoroutine(EjemploSemaforo());
        }
    }
    IEnumerator EjemploSemaforo()
    {
        while(true)
        {
            Debug.Log("Verde");
            yield return new WaitForSeconds(2);
            Debug.Log("Amarillo");
            yield return new WaitForSeconds(2);
            Debug.Log("Rojo");
            yield return new WaitForSeconds(2);
            
        }
    }
}
