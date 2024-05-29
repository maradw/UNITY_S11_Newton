using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    public float _rotationSpeed = 1f;
    public float _velocityModifier = 8f;
    [SerializeField] private Rigidbody birdRBD;
    private float _vertical;
    public float _backward = 9f;
    public float _reposition = 9f;
    public float wind = 5f;

    public void OnMovement(InputAction.CallbackContext move)
    {
        _vertical = move.ReadValue<float>();
    }
    private void FixedUpdate()
    {
        birdRBD.AddForce(Vector3.right * wind, ForceMode.Force);
        if (_vertical > 0)
        {
            birdRBD.AddForce(Vector3.up * _velocityModifier, ForceMode.Impulse);
        }
        else if (_vertical < 0)
        {
            birdRBD.AddForce(Vector3.down * _velocityModifier, ForceMode.Impulse);
        }

    }
    void Update()
    {
        transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.Euler(0, 0, birdRBD.velocity.y), Time.deltaTime);
        //transform.rotation = Quaternion.Angle(Quaternion.)
    }
    private void OnCollisionEnter(Collision collision)
    {

        if (collision.gameObject.CompareTag("Obstacle"))
        {
            birdRBD.transform.position = new Vector3(transform.position.x-3, transform.position.y);
            // birdRBD.AddForce(Vector3.left , );


        }
    }
}
