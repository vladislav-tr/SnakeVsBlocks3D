using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using static LevelResultSO;

public class GameController : MonoBehaviour
{
    public LevelResultSO LevelResult;
    public UIController uiController;

    public int LevelNum
    {
        get => PlayerPrefs.GetInt("Level", 1);
        private set
        {
            PlayerPrefs.SetInt("Level", value);
            PlayerPrefs.Save();
        }
    }
    private void Start()
    {
        switch (LevelResult.Result)
        {
            case LevelResults.Passed:
                uiController.SetPassed();
                break;
            case LevelResults.Failed:
                uiController.SetFailed();
                break;
            default:
                uiController.SetRunning();
                break;
        }
        uiController.SetLevelNum(LevelNum);
        Time.timeScale = 0;
    }
    private void Update()
    {
        if (Input.GetMouseButtonDown(0) && LevelResult.Result != LevelResults.Running)
        {
            Time.timeScale = 1;
            LevelResult.Result = LevelResults.Running;
            uiController.SetRunning();
        }
    }
    public void Win()
    {
        LevelResult.Result = LevelResults.Passed;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        LevelNum++;
    }
    public void Lose()
    {
        LevelResult.Result = LevelResults.Failed;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
    public void Reatart()
    {
        LevelResult.Result = LevelResults.Restarted;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
