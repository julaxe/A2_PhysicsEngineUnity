using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flipper : MonoBehaviour
{
    // Start is called before the first frame update
    private Rigidbody rb;
    private HingeJoint hj;
    [SerializeField]
    private float force;
    private bool inUse;


    public AudioSource s_use;

    public enum orientation
    {
        right,
        left
    }

    public orientation key;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        hj = GetComponent<HingeJoint>();
    }

    // Update is called once per frame
    void Update()
    {
        if(key == orientation.right)
        {
            if(Input.GetKey(KeyCode.RightArrow))
            {
                hj.useSpring = false;
                rb.AddForce(new Vector3(0.0f,0.0f, force));
                if(!inUse)
                {
                    s_use.Play();
                }
                inUse = true;
            }
            else
            {
                inUse = false;
                hj.useSpring = true;
            }
        }
        else if(key == orientation.left)
        {
            if (Input.GetKey(KeyCode.LeftArrow))
            {
                hj.useSpring = false;
                rb.AddForce(new Vector3(0.0f, 0.0f, force));
                if (!inUse)
                {
                    s_use.Play();
                }
                inUse = true;
            }
            else
            {
                inUse = false;
                hj.useSpring = true;
            }
        }
    }
}
