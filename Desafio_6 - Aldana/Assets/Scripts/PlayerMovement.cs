using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float playerSpeed;
    [SerializeField] private float rotationSpeed;

    private void Update()
    {
        movePlayer();
        
    }

    private void movePlayer()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        Vector3 movementDirection = new Vector3(horizontal, 0.0f, vertical);
        movementDirection.Normalize();

        transform.Translate(movementDirection * playerSpeed * Time.deltaTime);


        //Player Rotation

        if (movementDirection != Vector3.zero)
        {
            Quaternion newRotation = Quaternion.LookRotation(movementDirection, Vector3.up);

            transform.rotation = Quaternion.RotateTowards(transform.rotation, newRotation, (rotationSpeed * Time.deltaTime));
        }

    }

   
}
