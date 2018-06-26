using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    public GameObject pauseIndicator;
    public GameObject context;
    public bool isFirstLevel;
    void Awake()
    {
        context.SetActive(Data.inst.currLevel == 1 && Data.inst.currStage == 0);
    }

    void Update()
    {
        if (Data.inst.currLevel == 1 && Data.inst.currStage == 0)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                context.SetActive(false);
            }
        }
        else
        {
            context.SetActive(false);
        }


        if (pauseIndicator.activeInHierarchy)
        {
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                pauseIndicator.SetActive(false);
                Time.timeScale = 1f;
                AudioListener.pause = false;
            }
            else if (Input.GetKeyDown(KeyCode.Q))
            {
                Time.timeScale = 1f;
                SceneManager.LoadScene("title");
            }
            else if (Input.GetKeyDown(KeyCode.Space))
            {
                Time.timeScale = 1f;
                RestartLevel();
            }
        }
        else
        {
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                OnStop();
                //return;
            }

        }
        


        
    }

    public void RestartLevel()
    {
        SceneManager.LoadScene(UnityEngine.SceneManagement.SceneManager.GetActiveScene().name);
    }

    public void OnStop()
    {
        Time.timeScale = 0f;
        AudioListener.pause = true;
        pauseIndicator.SetActive(true);
    }


}
