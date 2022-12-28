using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class LevelResultSO : ScriptableObject
{
    public enum LevelResults
    {
        Restarted,
        Running,
        Passed,
        Failed,
    }

    public LevelResults Result;
}
