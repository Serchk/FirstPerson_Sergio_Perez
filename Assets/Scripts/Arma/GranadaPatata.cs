using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GranadaPatata : MonoBehaviour
{
    Rigidbody rb;
    [SerializeField] private float fuerzaImpulse;
    [SerializeField] private GameObject explosion;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.AddForce(transform.forward * 8, ForceMode.Impulse);
        rb.AddTorque(transform.forward * 8, ForceMode.Impulse);
        Destroy(gameObject, 5);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnDestroy()
    {
        Instantiate(explosion, transform.position, Quaternion.identity);
    }
}
