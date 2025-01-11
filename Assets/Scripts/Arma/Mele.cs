using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.VirtualTexturing;

public class Mele : MonoBehaviour
{
    private Animator anim;
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            anim.SetTrigger("Atacar");
        }
    }
    private void FinAtaque()
    {

    }
    private void AbrirVentana()
    {

    }
    private void CerrarVentana()
    {

    }
}
