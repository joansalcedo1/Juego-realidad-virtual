using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class Gun : MonoBehaviour
{

    public XRGrabInteractable interactable;
    public DisparoRay disparo;
    // Start is called before the first frame update
    void Start()
    {
        interactable.activated.AddListener(x => Disparando());
        interactable.deactivated.AddListener(x => DejarDisparo());

    }

    // Update is called once per frame
    public void Disparando()
    {
        disparo.Disparar();
    }

    public void DejarDisparo()
    {
        Debug.Log("Disparandont");
    }

}
