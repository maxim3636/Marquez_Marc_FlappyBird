using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.EnhancedTouch;
using UnityEngine.Serialization;

public class FlyBehaviour : MonoBehaviour
{
    [SerializeField] private float _velocity = 1.5f;
    [SerializeField] private float _rotationSpeed = 10f;
    [SerializeField] private Canvas Freeze;
    [SerializeField] private AudioClip wing;
    [SerializeField] private AudioClip hit;
    [SerializeField] private AudioClip point;
    [SerializeField] private AudioSource a1;
    [SerializeField] private AudioSource a2;

    private Rigidbody2D _rb;
    public bool canMove = false;
    private bool touchProcessed = false; // Flag to track whether touch has been processed
    private bool win;

    private void Start()
    {
        _rb = GetComponent<Rigidbody2D>();

        if (a1 == null)
        {
            Debug.LogError("No se encontró el componente AudioSource en este GameObject.");
        }

        _rb.isKinematic = true;
    }

    private void Update()
    {
        if (!canMove && (Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0) || IsTouchPhaseBegan()))
        {
            if (!touchProcessed) // Check if touch hasn't been processed
            {
                Freeze.gameObject.SetActive(false);
                canMove = true;
                _rb.isKinematic = false;

                touchProcessed = true; // Set the flag to true after processing the touch
                _rb.velocity = Vector2.up * _velocity;
            }
        }

        if (canMove && (Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0) || IsTouchPhaseBegan()) && win == false)
        {
            if (!touchProcessed) // Check if touch hasn't been processed
            {
                _rb.velocity = Vector2.up * _velocity;
                if (a1 != null && wing != null)
                {
                    a1.clip = wing;
                    a1.Play();
                }
                touchProcessed = true; // Set the flag to true after processing the touch
            }
        }

        if (canMove && (Input.GetKeyUp(KeyCode.Space) || Input.GetMouseButtonUp(0) || IsTouchPhaseEnded()))
        {
            // Reset the flag when the touch is released
            touchProcessed = false;
        }
    }

    private bool IsTouchPhaseBegan()
    {
        if (Touchscreen.current.primaryTouch.phase.ReadValue() == UnityEngine.InputSystem.TouchPhase.Began)
        {
            return true;
        }
        return false;
    }

    private bool IsTouchPhaseEnded()
    {
        if (Touchscreen.current.primaryTouch.phase.ReadValue() == UnityEngine.InputSystem.TouchPhase.Ended)
        {
            return true;
        }
        return false;
    }

    private void FixedUpdate()
    {
        if (canMove)
        {
            transform.rotation = Quaternion.Euler(0, 0, _rb.velocity.y * _rotationSpeed);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (a1 != null && hit != null)
        {
            a1.clip = hit;
            a1.Play();
        }
        GameManager.instance.GameOver();
        win = true;
    }

    public void pointSound()
    {
        if (a2 != null && point != null)
        {
            a2.clip = point;
            a2.Play();
        }
    }
}
