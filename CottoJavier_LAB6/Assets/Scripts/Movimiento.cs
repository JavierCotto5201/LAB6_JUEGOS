using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public class Movimiento : MonoBehaviour
{
    // Start is called before the first frame update
    private Rigidbody2D rb2d;
    private float score;

    //public AudioClip rupia;
    //public AudioClip muerto;
    //AudioSource audioS;
    void Start()
    {

        rb2d = GetComponent<Rigidbody2D>();
        //audioS = GetComponent<AudioSource>();

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Jump"))
            Jump();

        UnityEngine.Vector3 newScale = transform.localScale;
        if (Input.GetAxis("Horizontal") > 0.0f)
            newScale.x = 0.5f;
        else if (Input.GetAxis("Horizontal") < 0.0f)
            newScale.x = -0.5f;

        transform.localScale = newScale;

    }

    private void FixedUpdate()
    {

        if(rb2d)
        {
            rb2d.AddForce(new UnityEngine.Vector2(Input.GetAxis("Horizontal") * 10, 0));
        }
        
    }

    void Jump() 
    {
        if (rb2d)
            if (Mathf.Abs(rb2d.velocity.y) < 0.05f)
                rb2d.AddForce(new UnityEngine.Vector2(0, 6), ForceMode2D.Impulse);
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Rupia"))
        {
            Destroy(collision.gameObject);
            score++;
            GetComponent<SpriteRenderer>().material.color = Color.blue;
        }
        if (collision.gameObject.CompareTag("Enemy") && score < 1)
        {
            Destroy(gameObject);
        }
        else if (collision.gameObject.CompareTag("Enemy") && score == 1)
            Destroy(collision.gameObject);

    }

}
