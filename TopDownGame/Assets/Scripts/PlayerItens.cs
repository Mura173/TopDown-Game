using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerItens : MonoBehaviour
{
    [SerializeField] private int _totalWood;
    [SerializeField] private float _currentWater;
    [SerializeField] private int _totalCarrots;

    private float waterLimit = 50;

    public int totalWood { get => _totalWood; set => _totalWood = value; }
    public float currentWater { get => _currentWater; set => _currentWater = value; }
    public int totalCarrots { get => _totalCarrots; set => _totalCarrots = value; }

    public void WaterLimit(float water)
    {
        if (currentWater < waterLimit)
        {
            currentWater += water;
        }
    }
}
