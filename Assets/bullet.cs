using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bullet : MonoBehaviour
{
    // Start is called before the first frame update

    private Rigidbody rb;
    public GameObject character;
    private int score;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.AddForce(transform.forward *15, ForceMode.Impulse);

        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "enemigo")
        {

            Destroy(this.gameObject);
            FindObjectOfType<charactermovement>().setScore();
        }
    }
}
