using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnBall : MonoBehaviour
{
    [SerializeField] private Transform _ballSpawnPoint;
    [SerializeField] private Ball _ball;

    void Start()
    {
        Spawn();
    }

    private void OnEnable()
    {
        Ball.onBallDied += Spawn;
    }

    private void OnDisable()
    {
        Ball.onBallDied -= Spawn;
    }

    private void Spawn()
    {
        Instantiate(_ball, _ballSpawnPoint.position, _ballSpawnPoint.rotation, _ballSpawnPoint.parent);

    }
}
