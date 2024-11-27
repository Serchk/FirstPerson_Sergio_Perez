using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.VirtualTexturing;

public class ArmaAutomatica : MonoBehaviour
{
    [SerializeField] private ParticleSystem system;
    [SerializeField] private ArmaSO misDatos;

    private Camera cam;

    private float timer;
    // Start is called before the first frame update
    void Start()
    {
        cam = Camera.main;

        timer = misDatos.cadencia;
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;

        if (Input.GetMouseButton(0) && timer >= misDatos.cadencia)
        {
            system.Play();
            if (Physics.Raycast(cam.transform.position, cam.transform.forward, out RaycastHit hitInfo, misDatos.distanciaAtaque))
            {
                if (hitInfo.transform.TryGetComponent(out ParteEnemigo scriptEnemigo))
                {
                    //hitInfo.transform.GetComponent<ParteEnemigo>.RecibirDanho(misDatos.danhoAtaque);
                    //Debug.Log(hitInfo.transform.name);
                    scriptEnemigo.RecibirDanho(misDatos.danhoAtaque);
                }
            }
            timer = 0;
        }
    }
}
