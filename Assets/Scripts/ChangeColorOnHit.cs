using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeColorOnHit : MonoBehaviour
{
    // Start is called before the first frame update
    public Material defaultMaterial;
    public Material HitMaterial;
    public bool onCollision;
    public int score;

    private double timer;
    private Renderer r;
    private void Start()
    {
        onCollision = false;
        timer = 0;
        r = GetComponent<Renderer>();
    }
    private void Update()
    {
        if(onCollision)
        {
            r.material = HitMaterial;
            timer += Time.deltaTime;
            if(timer>0.2)
            {
                timer = 0;
                onCollision = false;
                r.material = defaultMaterial;
            }
        }
    }
}
