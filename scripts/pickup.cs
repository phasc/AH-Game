using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEngine;

public class pickup : MonoBehaviour
{
    public destroyableplataform[] plataformsArray;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            GameObject player = GameObject.Find("Player");
            player.GetComponent<player>().GetCoin();

            Destroy(gameObject);
            foreach (destroyableplataform plataform in plataformsArray)
            {
                plataform.DestroyPlataform();
            }
        }
    }
}
