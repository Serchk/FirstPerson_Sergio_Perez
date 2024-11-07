using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemigo : MonoBehaviour
{
    [SerializeField] Transform puntoAtaque;
    [SerializeField] private float radioAtaque;
    [SerializeField] private LayerMask queEsDanhable;
    [SerializeField] private ArmaSO misDatos;

    private bool puedoDanhar = true;

    private NavMeshAgent agent;
    private FirstPerson player;
    Animator animator;

    [SerializeField] private float danhoEnemigo;

    private bool ventanaAbierta;

    Rigidbody[] huesos;
    // Start is called before the first frame update
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        player = GameObject.FindObjectOfType<FirstPerson>();

        huesos = GetComponentsInChildren<Rigidbody>();

        for(int i = 0; i < huesos.Length; i++)
        {
            huesos[i].isKinematic = true;
        }
    }


    // Update is called once per frame
    void Update()
    {
        agent.SetDestination(player.gameObject.transform.position);
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
