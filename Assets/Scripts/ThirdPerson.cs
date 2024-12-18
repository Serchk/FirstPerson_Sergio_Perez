using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThirdPerson : MonoBehaviour
{
    [SerializeField] private float velocidadMovimiento;
    [SerializeField] private float smoothTime;
    CharacterController controller;

    private float velocidadRotacion;

    private Animator anim;
    // Start is called before the first frame update
    void Start()
    {
        controller = GetComponent<CharacterController>();
        anim = GetComponent<Animator>();
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

        //Calculo el �ngulo al que tengo que rotarme en funci�n de los inputs y c�mara
        

        if (input.sqrMagnitude > 0)
        {
            anim.SetBool("Walking", true);
            float angulo = Mathf.Atan2(input.x, input.y) * Mathf.Rad2Deg + Camera.main.transform.eulerAngles.y;

            float anguloSuave = Mathf.SmoothDampAngle(transform.eulerAngles.y, angulo, ref velocidadRotacion, smoothTime);

            transform.eulerAngles = new Vector3(0, anguloSuave, 0);

            //Mi movimiento tambian ha quedado rotado en la base
            Vector3 movimiento = Quaternion.Euler(0, angulo, 0) * Vector3.forward;

            controller.Move(movimiento * velocidadMovimiento * Time.deltaTime);
        }
        else
        {
            anim.SetBool("Walking", false);
        }
    }
}
