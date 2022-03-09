using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class nodo : MonoBehaviour
{


    public nodo[] nodos;


    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnDrawGizmos()
    {
        Color purple = new Color(230, 230, 250);
        Gizmos.color = purple;
        Gizmos.DrawCube(transform.position, new Vector3(1, 1, 1));


        Color naranja = new Color(255,165,0);
        Gizmos.color = naranja;
        foreach (nodo current in nodos) {
            
            Gizmos.DrawLine(transform.position, current.transform.position);
        }
    }
}
