using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rotacion : MonoBehaviour
{
    public float movementSpeed;
    public GameObject camera;
    public GameObject bala;
    public Transform puntoDisparo;
    private Coroutine dispara;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Plane playerPlane = new Plane(Vector3.up, transform.position);
        Ray ray = UnityEngine.Camera.main.ScreenPointToRay(Input.mousePosition);
        float hitDist = 0.0f;
        if (playerPlane.Raycast(ray, out hitDist))
        {
            Vector3 targetPoint = ray.GetPoint(hitDist);
            Quaternion targetRotation = Quaternion.LookRotation(targetPoint - transform.position);
            targetRotation.x = 0;
            targetRotation.z = 0;
            transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, 7f * Time.deltaTime);
        }

        if (Input.GetMouseButtonDown(0))
        {
             dispara = StartCoroutine(disparar());
            //Invoke("disparando",.8f);

        }
        if(Input.GetMouseButtonUp(0)) {
            StopCoroutine(dispara);      
        }
        

        
    }
    IEnumerator disparar() {
        while (true) {

            Debug.Log("estoy disparando");
            Instantiate(bala,puntoDisparo.position, puntoDisparo.rotation);
            yield return new WaitForSeconds(.8f);

        }
    }

   /* public void disparando() {
        Debug.Log("estoy disparando");
    }*/
}
