using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] int target;
    [HideInInspector] [SerializeField] Transform exit;
    [HideInInspector] [SerializeField] List<Transform> wayPoints;
    [SerializeField] float navigation;

    Transform enemy;
    float navigationTime = 0;

    // Start is called before the first frame update
    void Start()
    {
        //enemy = GetComponent<Transform>();
        exit = GameObject.FindGameObjectWithTag("Finish").transform;

        var routePointsObject = GameObject.FindGameObjectWithTag("PointRoute");
        /*var wayPointsRoutesCount = routePointsObject.transform.childCount;
        var route = routePointsObject.transform.GetChild(Random.Range(0, wayPointsRoutesCount));*/
                                                  
        wayPoints = routePointsObject.transform.GetComponentsInChildren<Transform>().ToList();

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
                if (target < wayPoints.Count)
                    transform.position = Vector2.MoveTowards(transform.position, wayPoints[target].position, navigationTime);

                else
                    transform.position = Vector2.MoveTowards(transform.position, exit.position, navigationTime);

                navigationTime = 0;
            }
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
