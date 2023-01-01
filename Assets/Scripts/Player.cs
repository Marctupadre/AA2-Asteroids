using UnityEngine;

public class Player : MonoBehaviour
{
    public float Impulse = 1.0f;

    public float MaxImpulse = 1.0f;

    private Rigidbody2D _shipRb;

    private bool _thrusting;
    [SerializeField]
    private float _turnDirection = 1.0f;


    void Awake()
    {
        _shipRb = GetComponent<Rigidbody2D>();
    }
    
    void Update()
    {
        _thrusting = Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow);

        if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow)) {
            _turnDirection = 1.0f;
        }
        else if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
        {
            _turnDirection = -1.0f;
        } else
        {
            _turnDirection = 0.0f;
        }
        

        void FixedUpdate()
        {
            if (_thrusting == true )
            {
                _shipRb.AddForce(this.transform.up * this.Impulse);
            }
            
            if (_turnDirection != 0.0f) {
                _shipRb.AddTorque(_turnDirection * this._turnDirection);
            }
        }




    }
}
