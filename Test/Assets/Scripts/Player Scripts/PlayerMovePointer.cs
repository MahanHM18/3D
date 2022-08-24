using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum Direction
{
    Left,
    Right,
    Noon
}

public class PlayerMovePointer : MonoBehaviour
{

    private Direction _direction = Direction.Noon;

    private Rigidbody _rb;
    

    private void Awake()
    {
        _rb = GetComponent<Rigidbody>();
    }

    void Start()
    {

    }

    void Update()
    {
        Movement();
    }

    public void PointerDown(bool right)
    {
        if (right)
        {
            _direction = Direction.Right;
        }
        else if (!right)
        {
            _direction = Direction.Left;
        }
    }

    public void PointerUp()
    {
        _direction = Direction.Noon;
    }


    private void Movement()
    {
        if (_direction == Direction.Left)
        {
            _rb.velocity = new Vector3(-10, _rb.velocity.y, _rb.velocity.z);
            //Debug.Log("left");
        }
        else if (_direction == Direction.Right)
        {
            _rb.velocity = new Vector3(10, _rb.velocity.y, _rb.velocity.z);
            //Debug.Log("right");
        }
        else if (_direction == Direction.Noon)
        {
            _rb.velocity = new Vector3(0, _rb.velocity.y, _rb.velocity.z);
            //Debug.Log("right");
        }
    }
}
