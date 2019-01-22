using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    [SerializeField]
    private Text _pointsText;

    [SerializeField]
    private GameObject _resetButton;

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
        _resetButton.SetActive(true);
    }

    public void ResetGame()
    {
        UI.SetActive(true);
        _points = 0;
        _pointsText.text = "";
        _resetButton.SetActive(false);
    }
}
