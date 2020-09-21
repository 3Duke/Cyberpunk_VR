using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrafficLight : MonoBehaviour
{
    // Start is called before the first frame update

    public Light _light;
    private Material trafficLight;

    void Start()
    {
        trafficLight = GetComponent<MeshRenderer>().material;
        StartCoroutine(flash());
    }

    // Update is called once per frame
    void Update()
    {

    }

    void disable()
    {
        trafficLight.DisableKeyword("_EMISSION");
        _light.enabled = false;
    }

    void enable()
    {
        trafficLight.EnableKeyword("_EMISSION");
        _light.enabled = true;
    }

    IEnumerator flash()
    {
        while (true)
        {
            disable();
            yield return new WaitForSeconds(1f);
            enable();
            yield return new WaitForSeconds(1f);
        }

        yield return null;
    }
}
