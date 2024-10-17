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
        
        Vector3 movimiento = new Vector3(h, 0, v).normalized;

        float anguloRotacion = Camera.main.transform.rotation.eulerAngles.y;
        controller.Move(movimiento * velocidadMovimiento * Time.deltaTime);

    }
}
