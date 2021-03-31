using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreBoard : MonoBehaviour
{
    // Start is called before the first frame update
    private TextMeshPro scoreText;
    private TextMeshPro creditsText;
    private Sphere sphere;
    void Start()
    {
        scoreText = transform.Find("Score").GetComponent<TextMeshPro>();
        creditsText = transform.Find("Credits").GetComponent<TextMeshPro>();
        sphere = GameObject.FindObjectOfType<Sphere>();
    }

    // Update is called once per frame
    void Update()
    {
        scoreText.text = "Score: " + sphere.Score.ToString();
        creditsText.text = "Credits: " + sphere.Credits.ToString();
    }
}
