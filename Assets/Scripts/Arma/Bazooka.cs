using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bazooka : MonoBehaviour
{
    [SerializeField] private GameObject granadaPrefab;
    [SerializeField] private Transform spawnPoint;

    private Animator anim;
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        Disparar();
        Recargar();
    }

    private void Disparar()
    {
        if (Input.GetMouseButtonDown(0))
        {
            GameObject granadaCopy = Instantiate(granadaPrefab, spawnPoint.position, transform.rotation);

        }
    }

    private void Recargar()
    {
        if(Input.GetKeyDown(KeyCode.R))
        {
            anim.SetTrigger("Recargar");
        }
    }
}
