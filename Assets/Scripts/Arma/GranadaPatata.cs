using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class GranadaPatata : MonoBehaviour
{
    Rigidbody rb;
    [SerializeField] private float fuerzaImpulse;
    [SerializeField] private float radioExplosion;
    [SerializeField] private GameObject explosion;
    [SerializeField] private LayerMask queEsExplotable;

    private Collider[] buffer = new Collider[100];
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.AddForce(transform.forward * 8, ForceMode.Impulse);
        rb.AddTorque(transform.forward * 1, ForceMode.Impulse);
        Destroy(gameObject, 5);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnDestroy()
    {
        Instantiate(explosion, transform.position, Quaternion.identity);
        int numColliderDetectados = Physics.OverlapSphereNonAlloc(transform.position, radioExplosion, buffer, queEsExplotable) ;
        if (numColliderDetectados > 0)
        {
            for (int i = 0; i < numColliderDetectados ; i++)
            {
                if (buffer[i].TryGetComponent(out ParteEnemigo scriptHueso))
                {
                    scriptHueso.Explotar();
                }
            }
        }

    }
}
