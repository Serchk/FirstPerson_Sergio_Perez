using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirstPerson : MonoBehaviour
{
    [Header("Movimiento")]
    [SerializeField] private float velocidadMovimiento;
    [SerializeField] private float factorGravedad;

    [Header("Detecci�n de Suelo")]
    [SerializeField] private float radioDeteccion;
    [SerializeField] private Transform pies;
    [SerializeField] private LayerMask queEsSuelo;
     

    CharacterController controller;
    private Vector3 movimientoVertical;
    // Start is called before the first frame update
    void Start()
    {
        controller = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        MoverTRotar();
        AplicarGravedad();
        EnSuelo();
    }
    void MoverTRotar()
    {
        float h = Input.GetAxisRaw("Horizontal");
        float v = Input.GetAxisRaw("Vertical");

        
        Vector2 input = new Vector2(h, v).normalized;

        //Calculo el �ngulo al que tengo que rotarme en funci�n de los inputs y c�mara
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
    private void Saltar()
    {

    }
    private void AplicarGravedad()
    {
        movimientoVertical.y += factorGravedad * Time.deltaTime;
        controller.Move(movimientoVertical * Time.deltaTime);
    }
    private bool EnSuelo()
    {
        //Tirar una esfera de detecci�n en los piescon cierto radio
        bool resultado = Physics.CheckSphere(pies.position, radioDeteccion, queEsSuelo);
        return resultado;
    }
}
