using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class enemigo : MonoBehaviour
{

    public nodo[] nodos;
    public float threshold=1.2f;
    public int current = 0;
    public Transform objetivo;
    private NavMeshAgent agente;
    private Coroutine pat;
    private Boolean flag = false;
    void Start()
    {

        agente = GetComponent<NavMeshAgent>();

        pat = StartCoroutine(patrullaje());
    }

    // Update is called once per frame
    void Update()
    {

        float distancia = Vector3.Distance(objetivo.position, transform.position);
        
        
        if (distancia >7 && !flag) {
            transform.LookAt(nodos[current].transform);
            transform.Translate(transform.forward * Time.deltaTime * 8, Space.World);
        }
        else if(distancia > 0){
            flag = true;
            
            StopCoroutine(pat);
            StartCoroutine(perseguir());
           
        }
        
       

    }

    IEnumerator patrullaje() {
        while (true) {
            float distance = Vector3.Distance(transform.position, nodos[current].transform.position);
           
            if (distance < threshold)
            {

                current++;


                current %= nodos.Length;

                transform.LookAt(nodos[current].transform);
            }

            yield return new WaitForSeconds(.5f);
        }
    
    }
    IEnumerator perseguir() {
        while (true) {
            agente.destination = objetivo.position;
            yield return new WaitForSeconds(.01f);
        }
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "bala") {

            Destroy(this.gameObject);
        }
        
    }
}
