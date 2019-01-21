using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    [SerializeField]
    private Text _pointsText;

    [SerializeField]
    private GameObject _augmentedObject;

    public GameObject UI;

    public DefaultTrackableEventHandler _augmentedObjectTrackableEvent;
    private int _points = 0;

    void Start()
    {
        _augmentedObjectTrackableEvent = _augmentedObject.GetComponent<DefaultTrackableEventHandler>();
    }

    public void AddPoints(int points)
    {
        _points += points;
        _pointsText.text = "Points: " + _points.ToString();
    }
}
