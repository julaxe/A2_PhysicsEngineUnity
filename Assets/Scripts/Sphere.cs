using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sphere : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField]
    public GameObject restartPoint;
    public int Credits;
    public int Score;
    public AudioSource s_background;
    public AudioSource s_hitActiveBumper;
    public AudioSource s_hitPassiveBumper;
    public AudioSource s_hitToy;
    public AudioSource s_gameOver;
    public AudioSource s_resetPosition;


    private Rigidbody rb;
    private GameObject gameOver;
    void Start()
    {
        s_background.Play();
        gameOver = GameObject.Find("GameOver");
        gameOver.SetActive(false);
        rb = GetComponent<Rigidbody>();
        Score = 0;
        Credits = 3;
    }

    // Update is called once per frame
    void Update()
    {
        //Game Over
        if(Credits <= 0)
        {
            gameOver.SetActive(true);
            if(Input.anyKey)
            {
                Credits = 3;
                Score = 0;
                gameOver.SetActive(false);
            }
        }
        if(s_hitActiveBumper.time > 0.5f)
        {
            s_hitActiveBumper.Stop();
        }
        if(Input.GetKey(KeyCode.Escape))
        {
            Application.Quit();  
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        //change the color of the gameObject hitted, representing some Score earned
        if(collision.gameObject.GetComponent<ChangeColorOnHit>())
        {
            collision.gameObject.GetComponent<ChangeColorOnHit>().onCollision = true;
            Score += collision.gameObject.GetComponent<ChangeColorOnHit>().score;
        }
        //check for Active bumpers
        if(collision.gameObject.tag == "ActiveBumper")
        {
            s_hitActiveBumper.Play();

            Vector3 newvelocity = rb.velocity;
            newvelocity = Vector3.Reflect(newvelocity, collision.contacts[0].normal);

            //go top speed when collide with active bumpers
            newvelocity = newvelocity.normalized * 20.0f;
            
            rb.velocity = newvelocity;
        }else if(collision.gameObject.tag == "PassiveBumper")
        {
            s_hitPassiveBumper.Play();
        }
        else if (collision.gameObject.tag == "BashToy")
        {
            s_hitToy.Play();
        }
        //Lose Credit and restart position
        else if(collision.gameObject.name == "BottomWall")
        {
            transform.position = restartPoint.transform.position;
            rb.velocity = Vector3.zero;
            Credits -= 1;
            if(Credits>0)
            {
                s_resetPosition.Play();
            }else
            {
                s_gameOver.Play();
            }
        }else
        {
        }
    }
}
