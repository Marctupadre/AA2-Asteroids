using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Asteroiide : MonoBehaviour
{
    private Rigidbody2D asteroidRb;

    public Sprite[] sprites;

    public float speed = 1.0f;

    public float size = 1f;

    public float minSize = 0.5f;

    public float maxSize = 1.5f;

    public float maxLifetime = 30.0f;
    public SpriteRenderer spriteRenderer { get; private set; }

    private void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        asteroidRb = GetComponent<Rigidbody2D>();

    }


    void Start()
    {
        spriteRenderer.sprite = sprites[Random.Range(0, sprites.Length)];
        asteroidRb.drag = 0;
        asteroidRb.angularDrag = 0;

        asteroidRb.velocity = new Vector3(
                               Random.Range(-1f, 1f),
                               Random.Range(-1f, 1f),
                               0
                               ).normalized * speed;
        asteroidRb.angularVelocity = Random.Range(-50f, 50f);
    }

    public void SetTrajectory(Vector2 direction)
    {
        asteroidRb.AddForce(direction * this.speed);

        Destroy(this.gameObject, this.maxLifetime);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Bullet")
        {
            Debug.Log("Colisiona");
            if ((size * 0.5f) >= minSize)
                {
                Debug.Log("se separa");
                CreateSplit();
                CreateSplit();
            }


            FindObjectOfType<GameManager>().AsteroidDestroyed(this);

            Destroy(this.gameObject);
        }
    }


    private Asteroiide CreateSplit()
    {
        Vector2 position = transform.position;
        position += Random.insideUnitCircle * 0.5f;

       
        Asteroiide half = Instantiate(this, position, transform.rotation);
        half.size = size * 0.25f;

       
        half.SetTrajectory(Random.insideUnitCircle.normalized);

        return half;
    }   

}
