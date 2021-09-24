using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    private float bulletSpeed = 10f;

    public void setBulletSpeed(float newSpeed) {
        bulletSpeed = newSpeed;
    }

    void Update()
    {
        transform.Translate(Vector3.forward * bulletSpeed * Time.deltaTime);
    }
}
