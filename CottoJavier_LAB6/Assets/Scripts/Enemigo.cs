using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemigo : MonoBehaviour
{
    public Transform seguir = null;
    public float vel = 1;
    // Start is called before the first frame update
    void Start()
    {
        seguir = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {

        if (seguir == null)
            return;

        transform.position = Vector2.MoveTowards(transform.position, seguir.transform.position, vel * Time.deltaTime);
        transform.up = seguir.position - transform.position;

    }
}
