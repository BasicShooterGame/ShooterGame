using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent (typeof (Rigidbody))]
public class PlayerController : MonoBehaviour
{
    private Vector3 velocity;
    private Rigidbody playerRb;

    private void Start()
    {
        playerRb = GetComponent<Rigidbody>();
    }

    private void FixedUpdate()
    {
        move();
    }

    private void move()
    {
        playerRb.MovePosition(playerRb.position + velocity * Time.fixedDeltaTime);
    }

    public void setVelocity(Vector3 velocity) {
        this.velocity = velocity;
    }

    public void lookAt(Vector3 point) {
        Vector3 lookPoint = new Vector3(point.x, transform.position.y, point.z);
        transform.LookAt(lookPoint);
    }
}
