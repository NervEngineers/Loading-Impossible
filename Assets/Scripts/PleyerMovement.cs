using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] Rigidbody2D rb;
    [SerializeField] private GameObject _visual;
    [SerializeField] private float _movementSpeed;
    [SerializeField] private float _jumppower;
    [SerializeField] private bool _onground;

    public void Flip()
    {
        transform.Rotate(0, 100, 0);
    }

    private void Start()
    {
    }

    void Update()
    {
        float horizontal = Input.GetAxis("Horizontal");
        if (horizontal != 0)
        {
            //move animation
        }
        else
        {
            //idle animation
        }
        if (horizontal > 0)
        {
            _visual.transform.localScale = new Vector3(1, 1, 1);
        }
        else if (horizontal < 0)
        {
            _visual.transform.localScale = new Vector3(-1, 1, 1);
        }
        transform.position += new Vector3(_movementSpeed, 0, 0) * horizontal * Time.deltaTime;
        if (Input.GetKeyDown(KeyCode.W) && _onground)
        {
            rb.AddForce(Vector2.up * _jumppower, ForceMode2D.Impulse);
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            _onground = true;
        }
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            _onground = false;
        }
    }
}