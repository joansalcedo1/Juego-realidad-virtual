using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mensajeCargarCamara : MonoBehaviour
{
    public GameObject panelMensajeCamara;
    public List<GameObject> enemigos;
    public bool activarUltimoScreamer;

    void onAwake()
    {
        foreach (GameObject enemigoObj in enemigos)
        {
            enemigoObj.SetActive(false);
        }
    }
    // Start is called before the first frame update
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player")) 
        {
            panelMensajeCamara.SetActive(true);
            Debug.Log("HOLA");
            foreach (GameObject enemigoObj in enemigos)
            {
                enemigoObj.SetActive(true);
            }
            activarUltimoScreamer = true;
        }
        
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            panelMensajeCamara.SetActive(false);
            Debug.Log("CHAO");
        }
       
    }
}
