using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Movement : MonoBehaviour
{
    public float mouseSensitivity = 2.0f;
    public float moveSpeed = 5.0f;

    private float verticalRotation = 0;
    private CharacterController characterController;
    public GameObject bulletPrefab;
    public Transform firePoint; // The position where bullets will be spawned

    void Start()
    {
        characterController = GetComponent<CharacterController>();
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    void Update()
    {
        // Mouse input for looking around
        float horizontalRotation = Input.GetAxis("Mouse X") * mouseSensitivity;
        verticalRotation -= Input.GetAxis("Mouse Y") * mouseSensitivity;
        verticalRotation = Mathf.Clamp(verticalRotation, -90, 90);

        transform.Rotate(0, horizontalRotation, 0);

        Camera.main.transform.localRotation = Quaternion.Euler(verticalRotation, 0, 0);

        // Keyboard input for movement
        float horizontalMovement = Input.GetAxis("Horizontal");
        float verticalMovement = Input.GetAxis("Vertical");

        Vector3 movement = transform.forward * verticalMovement + transform.right * horizontalMovement;

        movement.Normalize();
        characterController.Move(movement * moveSpeed * Time.deltaTime);

        if (Input.GetMouseButtonDown(0)) // Fire on left click
        {
            // Spawn a bullet at the fire point
            GameObject bullet = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);

            // Optionally, you can add force to the bullet's Rigidbody if you have one
            Rigidbody bulletRigidbody = bullet.GetComponent<Rigidbody>();
            if (bulletRigidbody != null)
            {
                bulletRigidbody.velocity = bullet.transform.forward * bullet.GetComponent<Bullet_Behavior>().getSpeed();
            }
        }
    }
}
