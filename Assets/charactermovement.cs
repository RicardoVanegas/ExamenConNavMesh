using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class charactermovement : MonoBehaviour
{
    public Text score;
    public int life = 10;
    private Transform t;
    // Start is called before the first frame update
    void Start()
    {
        t = GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");

        t.Translate(h*8*Time.deltaTime, 0, v*Time.deltaTime*8);
        score.text = "score: " + life;
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.layer == 8)
        {

            life--;

        }
    }
    public int getScore() {


        return this.life;
    }
    public void setScore() {
        this.life++;
    }
    public void restScore()
    {
        this.life--;
    }
}
