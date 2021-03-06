﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunController : MonoBehaviour {

    public Camera mainCamera;
    public bool isFiring;
    public float bulletSpeed;
    public Vector3 offset;
    public Transform firePoint;
    public BulletController bulletPrefab;

    private Ray cameraRay;
    private Plane groundPlane;
    private float rayLength;
    private float fireRate = 0.1f;
    private float nextFire = 0f;


    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        // rotate with mouse
        cameraRay = mainCamera.ScreenPointToRay(Input.mousePosition); // Cast a "ray" from mainCamera to the cursor position
        groundPlane = new Plane(Vector3.up, Vector3.zero);            // A "mathematical" plane representing the ground

        if (groundPlane.Raycast(cameraRay, out rayLength))            // Assign value to rayLength whitch is the length of the ray from mainCamera to groundPlane
        {
            Vector3 pointToLook = cameraRay.GetPoint(rayLength);      // Get location of where the ray hits the ground
            Debug.DrawLine(cameraRay.origin, pointToLook, Color.blue);// Draw a line draw the line in blue color

            // rotate the gun towards ray point
            transform.LookAt(new Vector3(pointToLook.x + offset.x, transform.position.y + offset.y, pointToLook.z + offset.z));
        }
        if (isFiring && Time.time > nextFire)
        {
            nextFire = Time.time + fireRate;
            BulletController newBullet = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation) as BulletController;
            newBullet.speed = bulletSpeed;
        }
    }
}
