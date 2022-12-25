using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    public void Win()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
    public void Lose()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
