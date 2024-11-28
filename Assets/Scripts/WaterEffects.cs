using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;

public class WaterEffects : MonoBehaviour
{
    private Volume volume;

    private LensDistortion distorsionEffect;

    [SerializeField] float velocidadAngular;
    // Start is called before the first frame update
    void Start()
    {
        volume = GetComponent<Volume>();
        if(volume.profile.TryGet(out LensDistortion lensDistortion))
        {
            distorsionEffect = lensDistortion;
        }
    }

    // Update is called once per frame
    void Update()
    {
        FloatParameter ejemplo = new FloatParameter(1+ Mathf.Sin(velocidadAngular * Time.time) / 2);
        FloatParameter ejemplo2 = new FloatParameter(1+ Mathf.Cos(velocidadAngular * Time.time) / 2);        
        distorsionEffect.xMultiplier.SetValue(ejemplo);
        distorsionEffect.yMultiplier.SetValue(ejemplo2);
    }
}
