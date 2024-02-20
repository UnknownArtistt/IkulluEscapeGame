using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlyingEnemyController : MonoBehaviour
{
    public Transform[] points;
    public float moveSpeed;
    public int currentPoint;
    public SpriteRenderer theSR;

    public float distanceToAttackPlayer, chaseSpeed;

    void Start()
    {
        for (int i = 0; i < points.Length; i++)
        {
            points[i].parent = null;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Vector3.Distance(transform.position, PlayerController.instance.transform.position) > distanceToAttackPlayer)
        {
            transform.position = Vector3.MoveTowards(transform.position, points[currentPoint].position, moveSpeed * Time.deltaTime);

            if (Vector3.Distance(transform.position, points[currentPoint].position) < .05f)
            {
                currentPoint++;

                if (currentPoint >= points.Length)
                {
                    currentPoint = 0;
                }

            }

            if (transform.position.x < points[currentPoint].position.x)
            {
                theSR.flipX = true;
            }
            else if (transform.position.x > points[currentPoint].position.x)
            {
                theSR.flipX = false;
            }
        }

        else
        {
            transform.position = Vector3.MoveTowards(transform.position, PlayerController.instance.transform.position, chaseSpeed * Time.deltaTime);
        }

        
    }
}
