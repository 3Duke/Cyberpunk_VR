using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlickeringFluo : MonoBehaviour
{
    // Start is called before the first frame update

    public Light neonLight;
    public Light neonLight1;
    public Light neonLight2;
    private Material neonMaterial;

    int maxFlashes = 6;
    int minFlashes = 2;

    void Start()
    {
        neonMaterial = GetComponent<MeshRenderer>().material;
        StartCoroutine(wait());
    }

    // Update is called once per frame
    void Update()
    {

    }

    void disable()
    {
        neonMaterial.DisableKeyword("_EMISSION");
        neonLight.enabled = false;
        neonLight1.enabled = false;
        neonLight2.enabled = false;
    }

    void enable()
    {
        neonMaterial.EnableKeyword("_EMISSION");
        neonLight.enabled = true;
        neonLight1.enabled = true;
        neonLight2.enabled = true;
    }

    IEnumerator flash()
    {
        int numFlash = UnityEngine.Random.Range(minFlashes, maxFlashes);

        while (numFlash > 0)
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
