using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParteEnemigo : MonoBehaviour
{
    [SerializeField] private Enemigo mainScript;
    [SerializeField] private float multiplicadorDanho;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void RecibirDanho(float danhoRecibido)
    {
        mainScript.Vidas -= danhoRecibido * multiplicadorDanho;

        if (mainScript.Vidas <= 0)
        {

            mainScript.Morir();
            //if(this.gameObject.name == "") //para accecer a una parte concreta (para reducir velocidades o danho que haga) 
        }

    }
    public void Explotar()
    {

    }
}
