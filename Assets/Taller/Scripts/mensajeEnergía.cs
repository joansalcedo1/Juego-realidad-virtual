using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mensajeEnergía : MonoBehaviour
{
    public GameObject panelMensaje;
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            panelMensaje.SetActive(true);
           
        }

    }
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            panelMensaje.SetActive(false);
            
        }

    }
}
