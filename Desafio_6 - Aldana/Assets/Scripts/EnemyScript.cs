using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum Enemies
{
    Enemy1Behaviour,
    Enemy2Behaviour,
}

public class EnemyScript : MonoBehaviour
{
    [SerializeField] Enemies enemyType;
    [SerializeField] private Transform playerTransform;
    [SerializeField] private float rotationSpeed;
    [SerializeField] private float enemySpeed;

    private void Update()
    {
        selectEnemy();
    }

    private void selectEnemy()
    {
        switch (enemyType)
        {
            case Enemies.Enemy1Behaviour:
                firstEnemy();
                break;

            case Enemies.Enemy2Behaviour:
                secondEnemy();
                break;
            default:
                break;
        }
    }

    private void firstEnemy()
    {
        Quaternion newRotation = Quaternion.LookRotation(playerTransform.position - transform.position);
        transform.rotation = Quaternion.Lerp(transform.rotation, newRotation, (rotationSpeed * Time.deltaTime));
    }

    private void secondEnemy()
    {
        //Rotate, look and persuit player

        //Distance

        if (Vector3.Distance(transform.position, playerTransform.position) > 2)
        {
            //Rotate and look

            Vector3 direction = (playerTransform.position - transform.position).normalized;
            var rotation = Quaternion.LookRotation(direction);
            transform.rotation = Quaternion.RotateTowards(transform.rotation, rotation, rotationSpeed);

            //Persuit

            transform.Translate(Vector3.forward * enemySpeed * Time.deltaTime);
        }
    }

   
}


