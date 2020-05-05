using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using UnityEngine;

public class Rupia : MonoBehaviour
{
    public float velAngular = 0;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(new UnityEngine.Vector3(0, velAngular, 0) * Time.deltaTime);

    }
}
