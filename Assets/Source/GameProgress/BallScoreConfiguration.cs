using Sirenix.OdinInspector;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "BallScoreConfiguration", menuName = "Scriptable Objects/BallScoreConfiguration")]
public class BallScoreConfiguration : SerializedScriptableObject, IScoreByColorGetter
{
    [SerializeField] private Dictionary<BallColor, int> _colorsScore;

    public int GetScoreBy(BallColor color)
    {
        return _colorsScore[color];
    }
}