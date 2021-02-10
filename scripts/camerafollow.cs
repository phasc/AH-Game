using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class camerafollow : MonoBehaviour
{
    public Transform player;
    public Transform farLeft;
    public Transform farRight;
    void Update()
    {

        Vector3 newPosition = transform.position;
        newPosition.x = player.position.x;
        newPosition.x = Mathf.Clamp(newPosition.x, farLeft.position.x, farRight.position.x);
        transform.position = newPosition;
    }

}