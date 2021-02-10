using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pickup3 : MonoBehaviour
{
    public destroyableplataform[] plataformsArray;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            GameObject player = GameObject.Find("Player");
            player.GetComponent<player>().GetCoin();

            Destroy(gameObject);
            GameObject mask = GameObject.Find("darkMask");

            mask.GetComponent<color>().GetBright();
            foreach (destroyableplataform plataform in plataformsArray)
            {
                plataform.DestroyPlataform();
            }
        }
    }
}
