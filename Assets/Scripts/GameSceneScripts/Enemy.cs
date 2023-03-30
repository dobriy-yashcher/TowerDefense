using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine;

public class Enemy : MonoBehaviour
{                              
    List<Transform> wayPoints;
                           
    int target = 0;
    float navigationTime = 0;

    void Start()
    {                   
        var routes = GameObject.FindGameObjectWithTag("Level1");
        var routesMain = GameObject.FindGameObjectWithTag("RouteMain")
            .GetComponentsInChildren<Transform>()
            .Where((item, index) => index != 0)
            .ToArray();     
        wayPoints = new List<Transform>(routesMain);

        var restRoute = routes.transform
            .GetChild(Random.Range(3, routes.transform.childCount))
            .GetComponentsInChildren<Transform>()
            .Where((item, index) => index != 0)
            .ToArray();
        wayPoints.AddRange(restRoute);
    }
                                          
    void Update()
    {
        MoveToTarget();
    }

    void MoveToTarget()
    {
        if (wayPoints != null)
        {
            navigationTime += Time.deltaTime;

            if (wayPoints.Count > target)
            {                 
                var targetPosition = wayPoints[target].position;
                targetPosition.z = 90;
                transform.position = Vector3.MoveTowards(transform.position, targetPosition, navigationTime);           
            }
            else
            {
                var targetPosition = wayPoints[wayPoints.Count - 1].position;
                targetPosition.z = 90;
                transform.position = Vector3.MoveTowards(transform.position, targetPosition, navigationTime);
            }

            navigationTime = 0;
        }
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Finish")
        {
            Manager.Instance.EnemyTakeOffHealth();
            Manager.Instance.RemoveEnemyFromScreen();
            Destroy(gameObject);    
        }

        else if(collision.tag == "PointRoute") ++target;
    }
}
