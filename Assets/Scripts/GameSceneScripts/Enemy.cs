using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [HideInInspector][SerializeField] Transform exit;
    [HideInInspector][SerializeField] List<Transform> wayPoints;
                           
    int target = 0;
    float navigationTime = 0;

    void Start()
    {
        ++target;
        exit = GameObject.FindGameObjectWithTag("Finish").transform;

        var array = GameObject.FindGameObjectWithTag("Route").GetComponentsInChildren<Transform>();
        wayPoints = new List<Transform>(array);
        wayPoints.Add(exit);

        //var count = GameObject.FindGameObjectsWithTag("PointRoute").Length;
        //wayPoints = GameObject.FindGameObjectsWithTag("PointRoute").Where(x => x != null).ToArray();
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
              
            var targetPosition = wayPoints[target].position;
            targetPosition.z = 90;       
            transform.position = Vector3.MoveTowards(transform.position, targetPosition, navigationTime);

            navigationTime = 0;
        }
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "PointRoute") ++target;

        else if (collision.tag == "Finish")
        {
            Manager.Instance.RemoveEnemyFromScreen();
            Destroy(gameObject);    
        }
    }
}
