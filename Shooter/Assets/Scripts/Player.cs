using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent (typeof (PlayerController))]
[RequireComponent (typeof (GunController))]
public class Player : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 5;
    PlayerController playerController;
    Camera viewCamera;
    GunController gunController;

    private void Start()
    {
        playerController = GetComponent<PlayerController>();
        gunController = GetComponent<GunController>();
        viewCamera = Camera.main;
    }
    private void Update()
    {
        movementInput();
        createAimRay();
        weaponInput();
    }

    private void weaponInput()
    {
        if (Input.GetMouseButton(0))
        {
            gunController.shoot();
        }
    }

    private void createAimRay()
    {
        Ray ray = viewCamera.ScreenPointToRay(Input.mousePosition);
        Plane groundPlane = new Plane(Vector3.up, Vector3.zero);
        float rayDistance;
        if (groundPlane.Raycast(ray, out rayDistance))
        {
            Vector3 point = ray.GetPoint(rayDistance);
            //Debug.DrawLine(ray.origin,point ,Color.red);
            playerController.lookAt(point);
        }
    }

    private void movementInput()
    {
        Vector3 moveInput = new Vector3(Input.GetAxisRaw("Horizontal"), 0, Input.GetAxisRaw("Vertical"));
        Vector3 velocity = (moveInput.normalized) * moveSpeed;
        //velocity = transform.TransformDirection(velocity);
        playerController.setVelocity(velocity);
    }
}
