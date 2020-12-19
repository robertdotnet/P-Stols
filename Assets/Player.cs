using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float speed = 6.0F;
    public float jumpSpeed = 8.0F;
    public float gravity = 20.0F;
    private Vector3 moveDirection = Vector3.zero;
    public float rotationSpeed = 99f;
    public GameObject missile;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        CharacterController controller = GetComponent<CharacterController>();

        Movement(controller);
        Fire();
    }

    private void Movement(CharacterController controller)
    {
        if (controller.isGrounded)
        {
            //Feed moveDirection with input
            moveDirection = new Vector3(-Input.GetAxis("Vertical"), 0, 0);
            moveDirection = transform.TransformDirection(moveDirection);
            float moveRotationAngle = Input.GetAxis("Horizontal");
            print(moveRotationAngle.ToString());

            transform.Rotate(new Vector3(0, moveRotationAngle * rotationSpeed, 0), rotationSpeed * (Time.deltaTime + 0.15F));
            //Multiply it by speed.
            moveDirection *= speed;
            //Jumping
            if (Input.GetButton("Jump"))
                moveDirection.y = jumpSpeed;

        }
        //Applying gravity to the controller
        moveDirection.y -= gravity * Time.deltaTime;
        //Making the character move
        controller.Move(moveDirection * Time.deltaTime);
    }

    private void Fire()
    {
        if (Input.GetKeyDown("x"))
        {
            GameObject missileObject = Instantiate(missile);
            StartingPosition(missileObject);
        }
            //Launch(projectile, projectileSpeed);
            //DO THE DESPAWN IN MISSILE SCRIPT
    }

    private void StartingPosition(GameObject projectile)
    {
        Vector3 adjuster = new Vector3(1.5f, 0, 0);
        projectile.transform.position = this.transform.position + adjuster;
    }

    private void Despawn(GameObject projectile, float lifeSpan)
    {
        lifeSpan -= Time.deltaTime;
        if (lifeSpan <= 0)
        {
            Destroy(projectile);
        }
    }

    private void Launch(GameObject projectile, float projectileSpeed)
    {
    }
}
