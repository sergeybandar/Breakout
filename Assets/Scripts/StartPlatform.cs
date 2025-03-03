using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartPlatform : MonoBehaviour
{
    public delegate void OnStartBall();
    public static OnStartBall onStartBall;

    [SerializeField] private int _speed;
    [SerializeField] private Transform _rightBorderPoint;
    [SerializeField] private Transform _leftBorderPoint;
    void Update()
    {
        if (Input.GetKey(KeyCode.A) && (transform.position.x > _leftBorderPoint.position.x))
        {
            gameObject.transform.position += Vector3.left * _speed * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.D) && (transform.position.x < _rightBorderPoint.position.x))
        {
            gameObject.transform.position += Vector3.right * _speed * Time.deltaTime;
        }
        if (Input.GetKeyDown(KeyCode.Space))
        {
            onStartBall?.Invoke();           
        }
    }
}
