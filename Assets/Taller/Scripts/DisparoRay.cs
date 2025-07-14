using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisparoRay : MonoBehaviour
{
    public Transform firePoint;           
    public int damage;
    public LineRenderer lineRenderer;
    public Light shootLight;              
    public GameObject shootEffectPrefab;
    public bateriaScript bateriaScript;


    public void Disparar()
    {
        StartCoroutine(Disparo());
    }
    IEnumerator Disparo()
    {
        RaycastHit hit;
        bool hitInfo = Physics.Raycast(firePoint.position, firePoint.forward, out hit, 50f);

        if (hitInfo)
        {
            lineRenderer.SetPosition(0, firePoint.position);    // Punto de inicio del rayo
            lineRenderer.SetPosition(1, hit.point);             // Punto donde colisiona el rayo

            // Verifica si colisiona con un objeto con la etiqueta "enemigo"
            if (hit.collider.CompareTag("enemigo"))
            {
                Destroy(hit.collider.gameObject);
                Debug.Log("Funciona Camara");
            }
        }
        else
        {
            lineRenderer.SetPosition(0, firePoint.position);    // Punto de inicio del rayo
            lineRenderer.SetPosition(1, firePoint.position + firePoint.forward * 20); // Distancia de 20 metros
        }

        // Activar la luz en el punto de disparo
        if (shootLight != null)
        {
            bateriaScript.bajarleBateria();
            shootLight.transform.position = firePoint.position; // Asegura que la luz esté en el punto correcto
            shootLight.enabled = true;
            print("Funciona");
        }

        if (shootEffectPrefab != null)
        {
            GameObject efecto = Instantiate(shootEffectPrefab, firePoint.position, firePoint.rotation);


        }

        lineRenderer.enabled = true;
        yield return new WaitForSeconds(0.08f);

        // Desactiva el rayo y la luz después de un corto tiempo
        lineRenderer.enabled = false;
        if (shootLight != null)
        {
            shootLight.enabled = false;
        }
    }
}
