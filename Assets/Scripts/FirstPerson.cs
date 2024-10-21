using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirstPerson : MonoBehaviour
{
    [SerializeField] private float velocidadMovimiento;
    CharacterController controller;
    // Start is called before the first frame update
    void Start()
    {
        controller = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        MoverTRotar();
    }
    void MoverTRotar()
    {
        float h = Input.GetAxisRaw("Horizontal");
        float v = Input.GetAxisRaw("Vertical");

        
        Vector2 input = new Vector2(h, v).normalized;

        //Calculo el ángulo al que tengo que rotarme en función de los inputs y cámara
        float angulo = Mathf.Atan2(input.x, input.y) * Mathf.Rad2Deg + Camera.main.transform.rotation.eulerAngles.y;

            transform.eulerAngles = new Vector3(0, angulo, 0);

        if (input.magnitude > 0)
        {
            //Mi movimiento tambian ha quedado rotado en la base
            Vector3 movimiento = Quaternion.Euler(0,angulo, 0) * Vector3.forward;
            controller.Move(movimiento * velocidadMovimiento * Time.deltaTime);
        }

        //Vector3 movimiento = new Vector3(h, 0, v).normalized;

        //float anguloRotacion = Mathf.Atan2(movimiento.x, movimiento.z) * Mathf.Rad2Deg + Camera.main.transform.rotation.eulerAngles.y;
        //if (movimiento.magnitude > 0)
        //{
        //    transform.eulerAngles = new Vector3(0, anguloRotacion, 0);
        //    controller.Move(movimiento * velocidadMovimiento * Time.deltaTime);
        //}

    }
}
