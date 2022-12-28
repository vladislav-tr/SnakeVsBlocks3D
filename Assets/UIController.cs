using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UIController : MonoBehaviour
{
    public GameObject bg;
    public TextMeshProUGUI levelLabel;
    public GameObject passedLabel;
    public GameObject failedLabel;
    public GameObject tapPrompt;
    public GameObject restartButton;

    public void SetLevelNum(int levelNum)
    {
        levelLabel.text = "Level " + levelNum.ToString();
    }
    public void SetRunning()
    {
        bg           .SetActive(false);
        passedLabel  .SetActive(false);
        failedLabel  .SetActive(false);
        tapPrompt    .SetActive(false);
        restartButton.SetActive(true);
    }
    public void SetPassed()
    {
        bg.SetActive(true);
        passedLabel.SetActive(true);
        failedLabel.SetActive(false);
        tapPrompt.SetActive(true);
        restartButton.SetActive(false);
    }
    public void SetFailed()
    {
        bg.SetActive(true);
        passedLabel.SetActive(false);
        failedLabel.SetActive(true);
        tapPrompt.SetActive(true);
        restartButton.SetActive(false);
    }
}
