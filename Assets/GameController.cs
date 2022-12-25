using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using static GameController;

public class GameController : MonoBehaviour
{
    public enum LevelState
    {
        Running,
        Passed,
        Failed
    }

    public LevelState levelState;
    public void Win()
    {
        levelState = LevelState.Passed;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
    public void Lose()
    {
        levelState = LevelState.Failed;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
