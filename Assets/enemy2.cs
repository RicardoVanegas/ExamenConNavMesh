using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemy2 : MonoBehaviour
{
    public nodo[] nodos;
    public float threshold = 1.2f;
    public int current = 0;
    void Start()
    {
        StartCoroutine(patrullaje());
    }

    // Update is called once per frame
    void Update()
    {
        transform.LookAt(nodos[current].transform);
        transform.Translate(transform.forward * Time.deltaTime * 8, Space.World);
    }

    IEnumerator patrullaje()
    {
        while (true)
        {
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
    private void OnTriggerEnter(Collider other)
    {
       
            if (other.tag == "bala")
            {

                Destroy(this.gameObject);
            }
        
    }
   
}
