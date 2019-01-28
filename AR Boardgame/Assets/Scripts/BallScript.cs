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
    private DefaultTrackableEventHandler _defaultTrackableEventHandler;

    void Start()
    {
        _thisRigidbody = this.GetComponent<Rigidbody>();
        _defaultTrackableEventHandler = GetComponentInParent<DefaultTrackableEventHandler>();

        Respawn();
    }

    void FixedUpdate()
    {
        if (transform.position.y < _floor.transform.position.y - 7)
        {
            if (!_defaultTrackableEventHandler.ObjectLost)
            {
                _gameManager.AddPoints(1);
            }

            Respawn();
        }

        if (isTurnedOn && _defaultTrackableEventHandler.ObjectLost)
        {
            TurnOff();
        }

        if (!isTurnedOn && !_defaultTrackableEventHandler.ObjectLost)
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

    private void Respawn()
    {
        var spawnPoint = _rnd.Next(0, _spawnPoints.Length);

        transform.position = _spawnPoints[spawnPoint].transform.position;
    }
}
