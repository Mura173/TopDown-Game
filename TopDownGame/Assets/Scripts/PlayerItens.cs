using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerItens : MonoBehaviour
{
    [Header("Amounts")]
    [SerializeField] private int _totalWood;
    [SerializeField] private float _currentWater;
    [SerializeField] private int _totalCarrots;

    [Header("Limits")]
    [SerializeField] private float waterLimit = 50;
    [SerializeField] private float woodLimit = 10;
    [SerializeField] private float carrotLimit = 10;

    // Encapsulate Amounts
    public int totalWood { get => _totalWood; set => _totalWood = value; }
    public float currentWater { get => _currentWater; set => _currentWater = value; }
    public int totalCarrots { get => _totalCarrots; set => _totalCarrots = value; }

    // Encapsulate Limits
    public float WaterLimit { get => waterLimit; set => waterLimit = value; }
    public float WoodLimit { get => woodLimit; set => woodLimit = value; }
    public float CarrotLimit { get => carrotLimit; set => carrotLimit = value; }

    public void MaxWater(float water)
    {
        if (currentWater <= WaterLimit)
        {
            currentWater += water;
        }
    }
}
