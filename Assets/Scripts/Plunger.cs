using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Plunger : MonoBehaviour
{
    // Start is called before the first frame update
    private Rigidbody rb;
    private SpringJoint spring;
    private float springLimit;
    private float springForce;

    //child variables
    private Transform springChild;

    //public
    public AudioSource s_release;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        spring = GetComponent<SpringJoint>();
        springLimit = transform.position.z - 6.0f;
        springForce = spring.spring;
        springChild = transform.Find("Spring");
    }

    // Update is called once per frame
    void Update()
    {
         if(Input.GetKey(KeyCode.DownArrow))
        {
            //disable spring force and residual forces
            spring.spring = 0.0f;
            rb.velocity = Vector3.zero;

            if (transform.position.z > springLimit) //set limit
            {
                float velocitySpring = 0.012f;
                transform.position += new Vector3(0.0f, 0.0f, -velocitySpring);

                //reScale the spring so it looks like it is getting compressed
                springChild.localScale += new Vector3(0.0f, 0.0f, -velocitySpring);
                springChild.position += new Vector3(0.0f, 0.0f, velocitySpring*0.5f);
            }
            else
            {
                transform.position = new Vector3(transform.position.x, transform.position.y, springLimit);
            }
        }
        else if(Input.GetKeyUp(KeyCode.DownArrow))
        {
            //enable spring force
            spring.spring = springForce;

            s_release.Play();
        }
        
            

        //change the scale of the Spring with the velocity of the plunger.
        float positionChange = rb.velocity.z * Time.deltaTime;
        springChild.localScale += new Vector3(0.0f, 0.0f, positionChange);
        springChild.position += new Vector3(0.0f, 0.0f, -positionChange * 0.5f);
        

    }
}
