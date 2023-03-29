using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelControl : MonoBehaviour
{
    public static LevelControl Instance = null;

    [SerializeField] GameObject level;
    [SerializeField] GameObject gameInterface;
    [SerializeField] GameObject mainMenu;
    [SerializeField] Animator animator;

    void Awake()
    {
        if (Instance == null) Instance = this;
        else if (Instance != this) Destroy(gameObject);

        DontDestroyOnLoad(gameObject);
    }

    public void OpenLevel()
    {
        animator.SetTrigger("hide_levels");
        mainMenu.SetActive(false);
        gameInterface.SetActive(true);
        level.SetActive(true);
    }
                  
    public void LevelFail()
    {
        gameInterface.SetActive(false);
        level.SetActive(false);
        animator.SetTrigger("open_level_failed");     
    }       
    
    public void LevelRestart()
    {
        animator.SetTrigger("hide_level_failed");     
        gameInterface.SetActive(true);
        level.SetActive(true);
    }
}
