using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    public int LevelNum
    {
        get => PlayerPrefs.GetInt("Level", 1);
        private set
        {
            PlayerPrefs.SetInt("Level", value);
            PlayerPrefs.Save();
        }
    }
    public void Win()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        LevelNum++;
    }
    public void Lose()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
