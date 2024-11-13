using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CajaAmmo : MonoBehaviour
{
    private Animator anim;
    private void Start()
    {
        anim = GetComponent<Animator>();
    }
    public void AbrirCaja()
    {
        anim.SetTrigger("Abrir");
    }
}
