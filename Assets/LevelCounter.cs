using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class LevelCounter : MonoBehaviour
{
    public GameController gameController;
    private TextMeshProUGUI level;
    private void Start()
    {
        level = GetComponent<TextMeshProUGUI>();
        level.text = "Level " + gameController.LevelNum.ToString();
    }

}
