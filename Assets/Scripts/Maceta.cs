using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Maceta : MonoBehaviour
{
    private Animator anim;
    private void Start()
    {
        anim = GetComponent<Animator>();
    }
    public void PlantarFlor()
    {
        anim.SetTrigger("Plantar");
        anim.SetBool("Plantado", true);
    }
    
    public void AbsorberFlor()
    {
        anim.SetBool("Plantado", false);
    }

}
