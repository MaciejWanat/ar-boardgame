﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    [SerializeField]
    private Text _pointsText;

    public GameObject UI;

    private int _points = 0;

    void Start()
    {
        _pointsText.text = "";
    }

    public void AddPoints(int points)
    {
        _points += points;
        _pointsText.text = "Points: " + _points.ToString();
    }

    public void TurnUIOff()
    {
        UI.SetActive(false);
        _pointsText.text = "Points: " + _points.ToString();
    }
}
