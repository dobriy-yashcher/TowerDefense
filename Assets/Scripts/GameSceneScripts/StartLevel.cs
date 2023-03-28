using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartLevel : MonoBehaviour
{
    [SerializeField] GameObject level;
    [SerializeField] GameObject gameInterface;
    [SerializeField] Animator animator;

    public void OpenLevel()
    {
        animator.SetTrigger("hide_levels");
        gameInterface.SetActive(true);
        level.SetActive(true);
    }
}
