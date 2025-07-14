using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class activarPalanca : MonoBehaviour
{
    public Animator anim;
    public bool llavePuesta;

    void Start()
    {
        llavePuesta = false;
    }
    // Start is called before the first frame update
    public void sePusoLlave()
    {
        llavePuesta = true;
    }
    public void noHayLlave() 
    { 
        llavePuesta = false;
    }
    public void activarEnergia()
    {
        if (llavePuesta)
        {
            anim.SetTrigger("Abrir");
        }
    }
}
