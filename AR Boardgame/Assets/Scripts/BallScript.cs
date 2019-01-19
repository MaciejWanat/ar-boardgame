using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallScript : MonoBehaviour
{
    [SerializeField]
    private GameObject _plane;

    [SerializeField]
    private GameObject _spawnPoint;

    void FixedUpdate()
    {
        if (transform.position.y < _plane.transform.position.y - 10)
        {
            transform.position = _spawnPoint.transform.position;
        }
    }
}
