using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pickup2 : MonoBehaviour
{
    public destroyableplataform[] plataformsArray;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            GameObject player = GameObject.Find("Player");
            player.GetComponent<player>().GetCoin();

            GameObject bonde = GameObject.Find("bonde");
            bonde.GetComponent<bonde>().slowDown();

            Destroy(gameObject);
            foreach (destroyableplataform plataform in plataformsArray)
            {
                plataform.DestroyPlataform();
            }
            
        }
    }
}
