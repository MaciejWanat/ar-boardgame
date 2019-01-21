using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = System.Random;

public class BallScript : MonoBehaviour
{
    [SerializeField]
    private GameObject _floor;

    [SerializeField]
    private GameObject[] _spawnPoints;

    [SerializeField]
    private GameObject _ceiling;

    [SerializeField]
    private GameManager _gameManager;

    private Rigidbody _thisRigidbody;
    private bool isTurnedOn = true;
    private Random _rnd = new Random();

    void Start()
    {
        _thisRigidbody = this.GetComponent<Rigidbody>();
    }

    void FixedUpdate()
    {
        if (transform.position.y < _floor.transform.position.y - 10)
        {
            if (!_gameManager._augmentedObjectTrackableEvent.ObjectLost)
            {
                _gameManager.AddPoints(1);
            }

            var spawnPoint = _rnd.Next(0, _spawnPoints.Length);

            transform.position = _spawnPoints[spawnPoint].transform.position;
        }

        if (isTurnedOn && _gameManager._augmentedObjectTrackableEvent.ObjectLost)
        {
            TurnOff();
        }

        if (!isTurnedOn && !_gameManager._augmentedObjectTrackableEvent.ObjectLost)
        {
            TurnOn();
        }
    }

    private void TurnOn()
    {
        _thisRigidbody.detectCollisions = true;
        _thisRigidbody.useGravity = true;
        isTurnedOn = true;
    }

    private void TurnOff()
    {
        _thisRigidbody.detectCollisions = false;
        _thisRigidbody.useGravity = false;
        isTurnedOn = false;
    }
}
