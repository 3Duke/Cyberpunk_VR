using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlickeringNeon : MonoBehaviour
{
    // Start is called before the first frame update

    public Light neonLight;
    private Material neonMaterial;
    public MeshRenderer neonMaterial2;
    private AudioSource hum;

    int maxFlashes = 6;
    int minFlashes = 2;

    void Start()
    {
        neonMaterial = GetComponent<MeshRenderer>().material;
        hum = GetComponent<AudioSource>();
        StartCoroutine(wait());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void disable()
    {
        neonMaterial.DisableKeyword("_EMISSION");
        neonMaterial2.material.DisableKeyword("_EMISSION");
        neonLight.enabled = false;
        hum.Stop();
    }

    void enable()
    {
        neonMaterial.EnableKeyword("_EMISSION");
        neonMaterial2.material.EnableKeyword("_EMISSION");
        neonLight.enabled = true;
        hum.Play();
    }

    IEnumerator flash()
    {
        int numFlash = UnityEngine.Random.Range(minFlashes, maxFlashes);

        while(numFlash > 0)
        {
            disable();
            yield return new WaitForSeconds(UnityEngine.Random.Range(0.05f, 0.1f));
            enable();
            yield return new WaitForSeconds(UnityEngine.Random.Range(0.05f, 0.1f));

            --numFlash;
        }
       
        yield return null;
    }

    IEnumerator wait()
    {
        while (true)
        {
            yield return new WaitForSeconds(UnityEngine.Random.Range(2f, 4f));
            StartCoroutine(flash());
        }

        yield return null;
    }
}
