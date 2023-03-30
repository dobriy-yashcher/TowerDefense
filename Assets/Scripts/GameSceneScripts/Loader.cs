using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Loader : MonoBehaviour
{
    public static Transform level1;

    void Start()
    {
        level1 = GameObject.FindGameObjectWithTag("Level").GetComponentsInChildren<Transform>(true).FirstOrDefault();
        if (Manager.Instance == null) Instantiate(level1);
    }          
}
