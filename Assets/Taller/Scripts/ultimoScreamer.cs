using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using TMPro;

public class ultimoScreamer : MonoBehaviour
{
    // Start is called before the first frame update
    public mensajeCargarCamara msjCargarCam;
    public bool b;
    public GameObject panel;
    public TextMeshProUGUI nombre;
    string nombreEquipo;
    public AudioSource AudioSource;
    void Start()
    {
        nombreEquipo = Environment.MachineName;

    }
    private void Update()
    {
        b = msjCargarCam.activarUltimoScreamer;
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player") & b)
        {
            panel.SetActive(true);
            AudioSource.Play();
         
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player") & b)
        {
            panel.SetActive(false);
           
        }
    }
}
