using UnityEngine;

public class Screamer : MonoBehaviour
{
    public GameObject modelo3D; // El modelo 3D que quieres activar
    public Transform jugador; // Transform del jugador (c�mara o controlador VR)
    public AudioSource audioSusto;

    void Start()
    {
        // Aseg�rate de que el modelo est� desactivado al inicio
        if (modelo3D != null)
        {
            modelo3D.SetActive(false);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        { 
            modelo3D.SetActive(true); 
            audioSusto.Play();
        }
       
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player")) 
        {
            modelo3D.SetActive(false);
            gameObject.SetActive(false);
        }
    }
    private System.Collections.IEnumerator DesactivarModelo()
    {
        // Espera 5 segundos
        yield return new WaitForSeconds(4f);
        // Desactiva el modelo
            gameObject.SetActive(false);
    }
}
