using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] int target;
    [HideInInspector] [SerializeField] Transform exit;
    [HideInInspector] [SerializeField] GameObject[] wayPoints;
    [SerializeField] float navigation;

    Transform enemy;
    float navigationTime = 0;
                                                        
    void Start()
    {                                              
        exit = GameObject.FindGameObjectWithTag("Finish").transform;                           
        wayPoints = GameObject.FindGameObjectsWithTag("PointRoute");

        target = 0;
    }

    // Update is called once per frame
    void Update()
    {
        MoveToTarget();
    }

    void MoveToTarget()
    {
        if (wayPoints != null)
        {
            navigationTime += Time.deltaTime;

            if (navigationTime > navigation)
            {
                var targetPosition = wayPoints[target].transform.position;
                targetPosition.z = 90;

                if (target <= wayPoints.Length)
                    transform.position = Vector3.MoveTowards(transform.position, targetPosition, navigationTime);        

                else
                    transform.position = Vector3.MoveTowards(transform.position, exit.position, navigationTime);

            }

            navigationTime = 0;
        }
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "PointRoute") ++target;

        else if (collision.tag == "Finish")
        {
            Manager.Instance.RemoveEnemyFromScreen();
            Destroy(gameObject);
        }
    }
}
