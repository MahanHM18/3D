using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    private Rigidbody _rb;
    private BoxCollider2D _boxCollider;

    [SerializeField] private Transform GroundPosition;
    [SerializeField] private LayerMask GroundLayer;
    [SerializeField] private float GroundDistance;

    public bool IsGrounded { get { return Physics.CheckSphere(GroundPosition.position,GroundDistance,GroundLayer); } }

    [SerializeField] private float MoveSpeed, JumpForce;

    private bool _doubleJump;

    [SerializeField] private Transform AttackPoint;
    [SerializeField] private float AttackRange;

    [SerializeField] private LayerMask EnemyLayer;

    [SerializeField] private Vector2 SpawnPos;
    
    private void Awake()
    {


        _rb = GetComponent<Rigidbody>();
        _boxCollider = GetComponent<BoxCollider2D>();
    }

    void Start()
    {
        _rb.constraints = RigidbodyConstraints.FreezeRotation;

        SpawnPos = transform.position;
    }


    void Update()
    {
        //Movement();

        if (IsGrounded)
            _doubleJump = false;
        

        if (Input.GetKeyDown(KeyCode.H))
        {
            Die();
        }
        
        //print(IsGrounded);
    }

    private void Movement()
    {
        float x = Input.GetAxisRaw("Horizontal") * MoveSpeed;

        _rb.velocity = new Vector3(x, _rb.velocity.y,_rb.velocity.z);

        PlayerJump();

    }

    private void PlayerJump()
    {
        if (Input.GetButtonDown("Jump"))
        {

            if (IsGrounded)
            {
                Jump();
            }
            if (!IsGrounded && !_doubleJump)
            {
                Jump();
                _doubleJump = true;
            }
        }

    }


    private void Jump()
    {
        _rb.velocity = new Vector3(_rb.velocity.x, JumpForce,_rb.velocity.z);
    }

    public void Attack()
    {
        

            Collider[] hit = Physics.OverlapSphere(AttackPoint.position, AttackRange, EnemyLayer);

            foreach (var item in hit)
            {
                Debug.Log(item.name);
            }

    }

    private void OnDrawGizmos()
    {
        if (GroundPosition)
        {
            Gizmos.color = Color.blue;
            Gizmos.DrawWireSphere(GroundPosition.position,GroundDistance);
        }
        
    }

    private void OnDrawGizmosSelected()
    {
        if (AttackPoint == null)
            return;

        Gizmos.color = Color.blue;
        Gizmos.DrawWireSphere(AttackPoint.position, AttackRange);
        
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Coin"))
        { 
            //GameManager.Coin++;
           //UIManager.Instance.Increase(1);
            Destroy(collision.gameObject);
        }

        if (collision.CompareTag("Checkpoint"))
        {
            SpawnPos = collision.transform.position;
            Destroy(collision.gameObject);
        }

        if (collision.CompareTag("Shop"))
        {
            Debug.Log("Shop");
            //UIManager.Instance.ActiveShopPanel();
            
        }
    }

    public void Die()
    {
        Respawn();
    }

    private void Respawn()
    {
        transform.position = SpawnPos;
    }

    public void PlayerJumpWithButton()
    {
        if (IsGrounded)
        {
            Jump();
        }
        if (!IsGrounded && !_doubleJump)
        {
            Jump();
            _doubleJump = true;
        }
    }

    public void PlayerMoveWithButton(float axis)
    {
        
        Debug.Log("D");
    }

}
