using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using UnityEngine;
using UnityEngine.UI;


public class ui : MonoBehaviour
{
    public Text coin;

    public Text kill;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        GameObject player = GameObject.Find("Player");

        int coins = player.GetComponent<player>().coins;

        double kills = player.GetComponent<player>().kills;

        coin.text = "" + coins;
        kill.text = "" + kills;
    }
}
