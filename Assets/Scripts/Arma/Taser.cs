using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.VirtualTexturing;

public class Taser : MonoBehaviour
{
    [SerializeField] private ParticleSystem system;
    private Animator anim;
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButton(0))
        {
            system.Play();
            anim.SetBool("Attack", true);        
        }
        else
        {
            anim.SetBool("Attack", false);
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
