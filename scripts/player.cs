using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Security.Cryptography;
using UnityEngine.SceneManagement;
using UnityEngine;

public class player : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private float s;
    [SerializeField] private double tx = 0.01;
    [SerializeField] private float jumpForce;

    [SerializeField] private Transform groundCheck;
    [SerializeField] private Vector2 groundCheckSize;

    [SerializeField] private bool canAttack = true;

    [SerializeField] private bool isFliped = false;
    [SerializeField] private Vector3 newScale = Vector3.one;

    [SerializeField] private Vector2 checkpoint;

    [SerializeField] public int coins = 0;
    [SerializeField] public double kills = 0;



    private Rigidbody2D _rb;
    private Animator _animator;

    // Start is called before the first frame update
    void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
        _animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        Attack();
        FlipPlayer();
        s = _rb.velocity.x;
        loadlevel();
        restart();
    }

    void FixedUpdate()
    {
        Jump();

        Movement();
    }

    private void Movement()
    {
        float xSpeed = Input.GetAxisRaw("Horizontal") * speed * Time.deltaTime;

        _rb.velocity = new Vector2(xSpeed, _rb.velocity.y);
    }

    private void FlipPlayer()
    {
        if (_rb.velocity.x < -tx && !isFliped)
        {
            isFliped = true;
            newScale.x = -1;
        }
        else if (_rb.velocity.x > tx && isFliped)
        {
            isFliped = false;
            newScale.x = 1;
        }
        transform.localScale = newScale;
    }

    private void Jump()
    {
        if (Input.GetKeyDown(KeyCode.Space) && CanJump())
        {
            _rb.gravityScale = 2;
            _rb.AddForce(new Vector2(0, jumpForce));
        }
        else if (!Input.GetKeyDown(KeyCode.Space) || _rb.velocity.y < 0)
        {
            _rb.gravityScale = 3;
        }
    }

    [SerializeField]
    private bool CanJump()
    {
        return Physics2D.OverlapBox(groundCheck.position, groundCheckSize, 0, LayerMask.GetMask("Ground"));
    }

    private void Attack()
    {
        if (canAttack && Input.GetKeyDown(KeyCode.UpArrow))
        {
            _animator.SetTrigger("attack");
        }
    }

    public void SetCheckpoint(Vector3 newCheckpoint)
    {
        checkpoint = newCheckpoint;
    }

    public void Die()
    {
        transform.position = checkpoint;
        GameObject bonde = GameObject.Find("bonde");
        bonde.GetComponent<bonde>().reset();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Checkpoint"))
        {
            SetCheckpoint(other.transform.position);
        }
        else if (other.CompareTag("Finish"))
        {
            StopMusic();
        }
    }

    private void onDrawGizmosSelected()
    {
        Gizmos.DrawWireCube(groundCheck.position, groundCheckSize);
    }

    public void loadlevel()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            SceneManager.LoadScene("SampleScene");
        }
        
    }

    public void restart()
    {
        if (Input.GetKeyDown(KeyCode.T))
        {
            SceneManager.LoadScene("title");
        }

    }

    public void GetCoin ()
    {
        coins += 1;
    }

    public void GetKill()
    {
        kills += 0.5;
    }

    private void StopMusic()
    {
        GameObject music = GameObject.Find("music");
        Destroy(music);
    }
}
