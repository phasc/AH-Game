﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class floor : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            other.GetComponent<player>().Die();
        }
    }
}