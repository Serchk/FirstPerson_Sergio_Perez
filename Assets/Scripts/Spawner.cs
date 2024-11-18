using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class Spawner : MonoBehaviour
{
    [SerializeField] private GameObject enemigoPrefab;
    [SerializeField] private Transform[] puntosSpawn;
    [SerializeField] private int numeroNiveles;   
    [SerializeField] private int rondasPorNiveles;
    [SerializeField] private int spawnsPorRonda;
    [SerializeField] private float esperaEntreSpawns;
    [SerializeField] private float esperaEntreRondas;
    [SerializeField] private float esperaEntreNiveles;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(Spawnear());
        // Quaternion.identity: Rotación (0, 0, 0)
        //Instantiate(enemigoPrefab, puntosSpawn[Random.Range(0, puntosSpawn.Length)].position, Quaternion.identity);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    IEnumerator Spawnear()
    {
        for (int i = 0; i < numeroNiveles; i++)
        {
            for (int j = 0; j < rondasPorNiveles; j++)
            {
                for (int k = 0; k < spawnsPorRonda; k++)
                {
                    int indiciceAleatoriedad = Random.Range(0, puntosSpawn.Length);
                    Instantiate(enemigoPrefab, puntosSpawn[indiciceAleatoriedad].position, Quaternion.identity);
                    yield return new WaitForSeconds(esperaEntreSpawns);
                }
                //Actualizar texto de ronda
                yield return new WaitForSeconds(esperaEntreRondas);
            }
            //Actualizar texto de Nivel
            yield return new WaitForSeconds(esperaEntreNiveles);
        }
    }
}
