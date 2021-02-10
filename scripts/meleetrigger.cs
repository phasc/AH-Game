using UnityEngine;

public class meleetrigger : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Enemy"))
        {
            other.GetComponent<enemy>().Damage();
        }
    }
}
