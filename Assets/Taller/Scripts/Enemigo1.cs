using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemigo1 : MonoBehaviour
{
    public int rutina;
    public float cronometro;
    public Animator ani;
    public Quaternion angulo;
    public float grado;

    public GameObject target;
    public bool atacando;

    void start()
    {
        ani = GetComponent<Animator>();
        target = GameObject.Find("Player");
    }

    public void Comportamiento_enemigo()
    {
        if (Vector3.Distance(transform.position, target.transform.position) > 20)
        {

            cronometro += 1 * Time.deltaTime;
            if (cronometro >= 4)
            {
                rutina = Random.Range(0, 2);
                cronometro = 0;
            }

            switch (rutina)
            {
                case 0:
                    ani.SetBool("walk", false);

                    break;
                case 1:
                    grado = Random.Range(0, 360);
                    angulo = Quaternion.Euler(0, grado, 0);
                    rutina++;
                    
                    break;
                case 2:
                    transform.rotation = Quaternion.RotateTowards(transform.rotation, angulo, 0.5f);
                    transform.Translate(Vector3.forward * 1 * Time.deltaTime);
                    ani.SetBool("walk", true);

                    break;
            }

        }
        else
        {

            Debug.Log("FuncionaCaminando");
            if (Vector3.Distance(transform.position, target.transform.position) > 8 && !atacando)
            {
                var lookPos = target.transform.position - transform.position;
                lookPos.y = 0;
                var rotation = Quaternion.LookRotation(lookPos);
                transform.rotation = Quaternion.RotateTowards(transform.rotation, rotation, 2);
                ani.SetBool("walk", true);


                transform.Translate(Vector3.forward * 2 * Time.deltaTime);
                Debug.Log(Vector3.Distance(transform.position, target.transform.position));



            }
            else
            {
                
                Debug.Log("FuncionaaATAQUE");
                ani.SetBool("walk", false);
                ani.SetBool("attack", true);

                
                atacando = true;
            }
        }
    }
    public void Final_Ani()
    {
        
        ani.SetBool("attack", false);
        atacando = false;
    }

    void Update()
    {
        Comportamiento_enemigo();
    }
}
        
        
          


 
    

