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
    private float horizontalInput;
    public Animator animator;

    public void Flip()
    {
        transform.Rotate(0, 100, 0);
    }

    private void Start()
    {
    }

  
    void Update()
    {
        horizontalInput = Input.GetAxis("Horizontal");

        if (horizontalInput < 0)
        {
            animator.SetBool("Idle", false);
            animator.SetBool("Right", false);
            animator.SetBool("Left", true);
        }
        else if (horizontalInput > 0)
        {
            animator.SetBool("Idle", false);
            animator.SetBool("Right", true);
            animator.SetBool("Left", false);
        }
        else
        {
            animator.SetBool("Idle", true);
            animator.SetBool("Right", false);
            animator.SetBool("Left", false);        }

        if (horizontalInput > 0)
        {
            _visual.transform.localScale = new Vector3(1, 1, 1);
        }
        else if (horizontalInput < 0)
        {
            _visual.transform.localScale = new Vector3(-1, 1, 1);
        }

        if (Input.GetKeyDown(KeyCode.W) && _onground)
        {
            rb.AddForce(Vector2.up * _jumppower, ForceMode2D.Impulse);
        }
    }

    void FixedUpdate()
    {
        rb.linearVelocity = new Vector2(horizontalInput * _movementSpeed, rb.linearVelocity.y);
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