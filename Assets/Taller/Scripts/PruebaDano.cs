using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PruebaDano : MonoBehaviour
{
    public bateriaScript bateriaScript;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player")) 
        {
            Debug.Log("HP");
            bateriaScript.VidaActual -= 12.0f;
        }
    }
}
