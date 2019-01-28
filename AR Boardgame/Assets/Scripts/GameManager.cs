using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    [SerializeField]
    private Text _pointsText;

    [SerializeField]
    private Text _timeText;

    [SerializeField]
    private Text _bestTimeText;

    [SerializeField]
    private GameObject _resetButton;

    public GameObject UI;

    private int _points = 0;
    private float _startTime;
    private Tuple<string, int> _bestTime = new Tuple<string, int>("", int.MaxValue);
    private bool _gameOn = false;

    void Start()
    {
        _pointsText.text = "";
        _timeText.text = "";
        _bestTimeText.text = "";
    }

    void FixedUpdate()
    {
        if (_gameOn)
        {
            float t = Time.time - _startTime;

            var min = ((int)t / 60).ToString();
            var sec = (t % 60).ToString("f2");

            _timeText.text = "Time: " + min + ":" + sec;
        }
    }

    public void AddPoints(int points)
    {
        _points += points;
        _pointsText.text = "Points: " + _points.ToString();

        var time = Int32.Parse(_timeText.text.Replace(":", "").Replace(",", "").Substring(5));
        if (time < _bestTime.Item2)
        {
            _bestTime = new Tuple<string, int>(_timeText.text.Substring(5), time);
        }

        _bestTimeText.text = "Best: " + _bestTime.Item1;
        _startTime = Time.time;
    }

    public void TurnUserTargetUIOff()
    {
        UI.SetActive(false);
        _pointsText.text = "Points: " + _points.ToString();
        _resetButton.SetActive(true);
        _gameOn = true;
        _startTime = Time.time;
    }

    public void ResetGame()
    {
        UI.SetActive(true);
        _points = 0;
        _pointsText.text = "";
        _resetButton.SetActive(false);
        _gameOn = false;
        _timeText.text = "";
    }
}
