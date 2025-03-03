using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Block : MonoBehaviour
{
    public delegate void OnBreakeBloack();
    public static OnBreakeBloack onBreakeBloack;

    [SerializeField] private int _heath = 1;

    public int Heath { get => _heath; private set => _heath = value; }

    private void Start()
    {
        float random = Random.Range(0.0f, 1.0f);
        if(random < 0.1f)
        {
            Heath = 2;
        }else if(random < 0.15f)
        {
            Heath = 3;
        }
    }

    private void OnEnable()
    {
        Ball.onAtacked += TakeDamage;
    }
    private void OnDisable()
    {
        Ball.onAtacked -= TakeDamage;
    }
    private void TakeDamage(Block block, int damage)
    {
        if (block.gameObject.Equals(gameObject))
        {
            Heath -= damage;
            if (Heath <= 0)
            {
                Destroy(gameObject);
                SpawnBlocks.substractionBlockNumber();
                onBreakeBloack?.Invoke();
            }
        }
    }
}
