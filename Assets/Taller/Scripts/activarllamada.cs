using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class activarllamada : MonoBehaviour
{
    public AudioSource llamada;
    // Start is called before the first frame update
    private void OnTriggerEnter(Collider other)
    {
        llamada.Play();
    }

    private void OnTriggerExit(Collider other)
    {
        gameObject.SetActive(false);
    }
}
