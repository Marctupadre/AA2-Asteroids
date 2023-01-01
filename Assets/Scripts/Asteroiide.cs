using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Asteroiide : MonoBehaviour
{
    private Rigidbody2D asteroidRb;
    public float speed = 1.0f;
    private bool asteroidDeath = false;
    // Start is called before the first frame update
    void Start()
    {
        asteroidRb = GetComponent<Rigidbody2D>();
        asteroidRb.drag = 0;
        asteroidRb.angularDrag = 0;

        asteroidRb.velocity = new Vector3(
                               Random.Range(-1f, 1f),
                               Random.Range(-1f, 1f),
                               0
                               ).normalized * speed;
        asteroidRb.angularVelocity = Random.Range(-50f, 50f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
