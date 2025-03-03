using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    public delegate void OnBallDied();
    public static OnBallDied onBallDied;
    public delegate void OnAtacked(Block block, int damage);
    public static OnAtacked onAtacked;
    
    [SerializeField] private int _force;
    [SerializeField] private int _damage;
    private Rigidbody _rigidbody;
    private AudioSource _audioSource;
    private bool _isRun = false;
    private Vector3 _velocity;

    public bool IsRun { get => _isRun; private set => _isRun = value; }

    void Start()
    {
        _rigidbody = GetComponent<Rigidbody>();
        _audioSource = GetComponent<AudioSource>();
    }
    private void OnEnable()
    {
        StartPlatform.onStartBall += Run;
    }
    private void OnDisable()
    {
        StartPlatform.onStartBall -= Run;
        
    }
    // Update is called once per frame
    void Update()
    {
        
    }
    public void Run()
    {   if (IsRun == false)
        {
            _rigidbody.velocity = new Vector3(Random.Range(-0.8f, 0.8f), Random.Range(0.5f, 1.0f), 0).normalized * _force;
            _velocity = _rigidbody.velocity;
            gameObject.transform.parent = null;
            IsRun = true;
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        Vector3 normal = collision.contacts[0].normal;
        if (collision.gameObject.TryGetComponent(out Block block))
        {
            if (block.Heath > _damage)
            {
                _audioSource.Play();
            }
            onAtacked?.Invoke(block, _damage);
            Reflection(normal);
            
        }
        if (collision.gameObject.TryGetComponent(out StartBlock startBlock) && IsRun)
        {
            Reflection(normal);
            _audioSource.Play();

        }
        if (collision.gameObject.TryGetComponent(out Border border))
        {
            Reflection(normal);
            _audioSource.Play();

        }
        if (collision.gameObject.TryGetComponent(out LowerBorder lowerBorder))
        {
            Destroy(gameObject);
            onBallDied?.Invoke();
        }

    }

    private void Reflection(Vector3 normal)
    {
        Vector3 reflectedVelocity = Vector3.Reflect(_velocity, normal);
        _rigidbody.velocity = reflectedVelocity.normalized * _velocity.magnitude;
        _velocity = _rigidbody.velocity;
    }
}
