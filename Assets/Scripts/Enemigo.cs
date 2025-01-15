using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.Video;

public class Enemigo : MonoBehaviour
{
    [SerializeField] float vidas;
    [SerializeField] Transform puntoAtaque;
    [SerializeField] private float radioAtaque;
    [SerializeField] private LayerMask queEsDanhable;
    [SerializeField] private ArmaSO misDatos;

    
    private bool puedoDanhar = true;

    private NavMeshAgent agent;
    private FirstPerson player;
    Animator anim;

    [SerializeField] private float danhoEnemigo;

    //private bool ventanaAbierta;

    [SerializeField] Rigidbody[] huesos;

    public float Vidas { get => vidas; set => vidas = value; }

    // Start is called before the first frame update
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        anim = GetComponent<Animator>();
        player = GameObject.FindObjectOfType<FirstPerson>();

        huesos = GetComponentsInChildren<Rigidbody>();
        CambiarEstadoHuesos(true);
    }

    
    // Update is called once per frame
    void Update()
    {
        if(agent.enabled)
        {
            Perseguir();
        }   
        //agent.SetDestination(player.gameObject.transform.position);
        //if(ventanaAbierta && puedoDanhar)
        //{
        //    RobarFlores();
        //}

    }
    private void Perseguir()
    {
        agent.SetDestination(player.gameObject.transform.position);

        if (!agent.pathPending && agent.remainingDistance <= agent.stoppingDistance)
        {
            agent.isStopped = true;
            anim.SetBool("Attack", true);
            EnfocarObjetivo();
        }
        else if(!agent.pathPending && agent.remainingDistance >= agent.stoppingDistance)
        {
            agent.isStopped = false;
            anim.SetBool("Attack", false);
            EnfocarObjetivo();
        }
    }

    private void EnfocarObjetivo()
    {
        Vector3 direccionAObjetivo = (player.transform.position - transform.position).normalized;

        direccionAObjetivo.y = 0;
        Quaternion rotacionAObjetivo = Quaternion.LookRotation(direccionAObjetivo);

        transform.rotation = rotacionAObjetivo;
    }

    private void FinAtaque()
    {
        agent.isStopped = false;
        anim.SetBool("Attack", false);
        puedoDanhar = true;
    }

    //private void AbrirVentanaAtaque()
    //{
    //    ventanaAbierta = true;
    //}
    //private void CerrarVentanaAtaque()
    //{
    //    ventanaAbierta = false;
    //}
    //private void RobarFlores()
    //{
    //    Collider[] collsDetectatos = Physics.OverlapSphere(puntoAtaque.position, radioAtaque, queEsDanhable);

    //    if(collsDetectatos.Length > 0)
    //    {
    //        for(int i = 0; i < collsDetectatos.Length; i++)
    //        {
    //            collsDetectatos[i].GetComponent<FirstPerson>().RecibirDanho(danhoEnemigo);
    //        }
    //        puedoDanhar = false;
    //    }
    //}

    private void CambiarEstadoHuesos(bool estado)
    {   
            for (int i = 0; i < huesos.Length; i++)
            {
                huesos[i].isKinematic = estado;
            }
    }
    private void RecibirDanho(float danhoRecibido)
    {
        vidas -= danhoRecibido;

        if (vidas <= 0)
        {
            Destroy(this.gameObject);
        }
    }

    public void Morir()
    {
        CambiarEstadoHuesos(false);
        anim.enabled = false;
        agent.enabled = false;
    }

    //private void DetectarImpacto()
    //{
    //    Collider[] collsDetectados = Physics.OverlapSphere(puntoAtaque.position, radioAtaque, queEsDanhable);
    //    for (int i = 0; i < collsDetectados.Length; i++)
    //    {
    //        collsDetectados[i].GetComponent<FirstPerson>().RecibirDanho(danhoEnemigo);
    //    }
    //}
}
