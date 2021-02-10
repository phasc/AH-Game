using System.Collections;
using System.Collections.Specialized;
using System.Security.Cryptography;
using System.Threading;
using UnityEngine;

public class enemy : MonoBehaviour
{

    [SerializeField] private float speed;
    [SerializeField] private Transform groundCheck;
    [SerializeField] private Vector2 groundCheckSize;
    [SerializeField] private bool canMove;
    [SerializeField] private bool isFlipped;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (canMove)
        {
            transform.position += Vector3.right * speed * Time.deltaTime;
        }

        DetectFloor();
    }

    private void DetectFloor()
    {
        if (!GroundCheck())
        {
            StartCoroutine(ChangeTarget());
        }
    }

    private bool GroundCheck()
    {
        return Physics2D.OverlapBox(groundCheck.position, groundCheckSize, 0, LayerMask.GetMask("Ground"));
    }

    private IEnumerator ChangeTarget()
    {
        canMove = false;

        if (isFlipped)
        {
            transform.localScale = new Vector3(1, 1, 1);
            speed *= -1;
        }
        else if (!isFlipped)
        {
            transform.localScale = new Vector3(-1, 1, 1);
            speed *= -1;
        }
        isFlipped = !isFlipped;

        yield return new WaitForSeconds(0.5f);

        canMove = true;
    }

    public void Damage()
    {
        Destroy(gameObject);

        GameObject player = GameObject.Find("Player");
        player.GetComponent<player>().GetKill();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            other.GetComponent<player>().Die();
        }
        if (other.CompareTag("melee"))
        {
            Damage();
        }
    }


    private void onDrawGizmosSelected()
    {
        Gizmos.DrawWireCube(groundCheck.position, groundCheckSize);
    }
}
