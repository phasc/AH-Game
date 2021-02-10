using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Security.Cryptography;
using UnityEngine;

public class bonde : MonoBehaviour
{
    [SerializeField] public float speedy = 3.0f;

    [SerializeField] public bool go = false;

    [SerializeField] public Transform limite;

    public Vector3 initPos;

    void Start()
    {
        initPos = transform.position;
    }

    void Update()
    { 
        if (go)
        {
            move();
        }
    }

    private void move()
    {
        if (transform.position.x < limite.position.x)
        {
            transform.position += transform.right * speedy * Time.deltaTime;
        }
            
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            go = true;
        }
    }

    public void slowDown()
    {
        speedy += -0.5f;
    }

    public void reset()
    {
        go = false;
        transform.position = initPos;
    }
}
