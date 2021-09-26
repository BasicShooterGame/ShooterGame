using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    private float bulletSpeed = 10f;
    [SerializeField] private LayerMask enemyLayerMask;

    public void setBulletSpeed(float newSpeed) {
        bulletSpeed = newSpeed;
    }

    void Update()
    {
        float moveDistance = bulletSpeed * Time.deltaTime;
        checkCollisions(moveDistance);
        transform.Translate(Vector3.forward * moveDistance);
    }

    private void checkCollisions(float moveDistance)
    {
        Ray ray = new Ray(transform.position, transform.forward);
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit, moveDistance, enemyLayerMask, QueryTriggerInteraction.Collide))
        {
            onHitEnemy(hit);
        }
    }

    private void onHitEnemy(RaycastHit hit)
    {
        Debug.Log("Enemy name = " + hit.transform.name);
        Destroy(this.gameObject);
    }
}
