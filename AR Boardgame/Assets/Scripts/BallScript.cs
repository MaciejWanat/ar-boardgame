using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallScript : MonoBehaviour
{
    [SerializeField]
    private GameObject _floor;

    [SerializeField]
    private GameObject _spawnPoint;

    [SerializeField]
    private GameObject _ceiling;

    [SerializeField]
    private GameManager _gameManager;

    private Rigidbody _thisRigidbody;
    private bool isTurnedOn = true;

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

            transform.position = _spawnPoint.transform.position;
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
