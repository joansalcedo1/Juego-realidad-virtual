using System.Collections;
using System.Collections.Generic;
using UnityEditor.Animations;
using UnityEngine;

public class abrirPuerta : MonoBehaviour
{
    public Animator anim;

    public void animacion()
    {
        anim.SetTrigger("Abrir");
        
    }
   


}
