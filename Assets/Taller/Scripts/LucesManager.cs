using System.Collections.Generic;
using UnityEngine;

public class LucesManager : MonoBehaviour
{
    public List<Light> lights;
    public float intervaloMin = 0.1f; // Tiempo mínimo entre parpadeos
    public float intervaloMax = 0.5f; // Tiempo máximo entre parpadeos

    private void Start()
    {
        foreach (Light luzobj in lights)
        {
            StartCoroutine(ParpadeoLuz(luzobj));
        }
    }
    public void lucesQuietas()
    {
        StopAllCoroutines();
        foreach (Light luzobj in lights)
        {
            luzobj.enabled = true;
        }
    }

    private System.Collections.IEnumerator ParpadeoLuz(Light luzobj)
    {
        while (true)
        {
            // Apaga o enciende la luz aleatoriamente
             luzobj.enabled = !luzobj.enabled; 
           

            // Espera un tiempo aleatorio antes de volver a cambiar el estado de la luz
            float tiempoEspera = Random.Range(intervaloMin, intervaloMax);
            yield return new WaitForSeconds(tiempoEspera);
        }
    }
   
}
