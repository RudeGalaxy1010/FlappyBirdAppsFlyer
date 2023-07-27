using System;
using UnityEngine;

public class Score : MonoBehaviour
{
    private const string NegativeValueExceptionMessage = "Value can't be less than 0";

    public event Action<int> PointsChanged;

    private int _points;

    public void AddPoints(int value)
    {
        if (value <= 0)
        {
            throw new ArgumentException(NegativeValueExceptionMessage);
        }

        _points += value;
        PointsChanged?.Invoke(_points);
    }
}
