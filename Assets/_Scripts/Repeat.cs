using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Repeat : MonoBehaviour
{
    private AudioSource _audio;

    // Start is called before the first frame update
    void Start()
    {
        _audio = GetComponent<AudioSource>();
        StartCoroutine(repeat());
    }

    IEnumerator repeat()
    {
        _audio.Play();
        yield return new WaitForSeconds(UnityEngine.Random.Range(50f, 70f));
        StartCoroutine(repeat());

        yield return null;
    }
}
