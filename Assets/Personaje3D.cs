using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Personaje3D : MonoBehaviour
{
    public Animator ani;
   // public RigidBody3D rb;
    void Start()
    {
       // rb = GetComponent<RigidBody>();
        ani = GetComponent<Animator>();
        
    }
    void OnTriggerEnter(Collider c)
    {
        if (c.CompareTag("arma"))
        {
            Debug.Log("Dano");
        }
    }
    
}
