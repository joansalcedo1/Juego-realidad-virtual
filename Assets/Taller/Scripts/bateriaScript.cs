using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine.XR;
using System;
using TMPro;

public class bateriaScript : MonoBehaviour
{
    public float bateriaMaxima = 100f;
    public float bateriaActual = 100f;

    public float VidaMaxima = 100f;
    public float VidaActual = 100f;

    public GameObject panelNobatery;

    public Image imagenBateria;
    public Image imagenVida;
    public Image imagenHambre;
    public Light lightToActivate;
    private InputDatas _inputData;
    public ContinuousMoveProviderBase continuousMoveProvider;
    float comida;
    float currentTime;
    public TextMeshProUGUI timeT;

    // Start is called before the first frame update
    void Start()
    {
        _inputData = GetComponent<InputDatas>();
        Debug.Log("Started inputData: " + _inputData);
        bateriaActual = bateriaMaxima;
        currentTime = 0;
        comida = 15.0f;
        
    }

    // Update is called once per frame


    public void bajarleBateria()
    {
        bateriaActual -= 5f;
    }
    public void quitarHambre()
    {
        comida -= 5f;
    }
    void Update()
    {
        
        revisarVida();
        revisarBateria();
        revisarHambre();

        

        if (bateriaActual <= 0) 
        {
            gameObject.SetActive(false);
        }
        if (bateriaActual < 50f)
        {
            imagenBateria.color = Color.yellow;
        }
        if (bateriaActual < 25f)
        {
            imagenBateria.color = Color.red;
        }

        if (bateriaActual <= 0)
        {
            panelNobatery.SetActive(true);
        }else
        {
            panelNobatery.SetActive(false);
        }

        if (_inputData._rightController.TryGetFeatureValue(CommonUsages.primaryButton, out bool Abutton))
        {

            lightToActivate.enabled = true;
            Debug.Log("A button: " + Abutton);
        }

        if (currentTime > comida)
        {
            continuousMoveProvider.moveSpeed -= 0.05f;
            comida += 10.0f;
        }

    }
    public void cargarBateria()
    {
        bateriaActual = 100;
    }
    private void FixedUpdate()
    {
        currentTime += Time.deltaTime;
        TimeSpan time = TimeSpan.FromSeconds(currentTime);
        timeT.text = time.ToString(@"mm\:ss\:fff");

    }

    public void revisarVida() 
    {
        imagenBateria.fillAmount = bateriaActual / bateriaMaxima;
    }

    public void revisarBateria()
    {
        imagenVida.fillAmount = VidaActual / VidaMaxima;
    }

    public void revisarHambre()
    {
        imagenHambre.fillAmount = 1 - continuousMoveProvider.moveSpeed;
    }
}
