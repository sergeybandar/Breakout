using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SpawnBlocks : MonoBehaviour
{
    [SerializeField] private Transform _blockStartSpawnPoint;
    [SerializeField] private Block _block;
    [SerializeField] private int _countRow;
    [SerializeField] private int _countLine;
    [SerializeField] private ColorLine _colorLine;

    public static int blocksNumber = 0;
    public static void substractionBlockNumber()
    {
        blocksNumber--;
        if (blocksNumber == 0)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }

    void Start()
    {
        Vector3 startSpawnPoint = _blockStartSpawnPoint.position;
        for (int i = 0; i < _countRow; i++)
        {
            
            for (int j = 0; j < _countLine; j++)
        {
            Block block = Instantiate(_block, startSpawnPoint + Vector3.right * j * 2.5f, Quaternion.identity);
            blocksNumber++;
                if (i < _colorLine.colors.Length)
                {
                    var component = block.GetComponent<Renderer>();
                    component.material.color = _colorLine.colors[i];
                }                
                }
        startSpawnPoint += Vector3.down * 1;
    }
}

    // Update is called once per frame
    void Update()
    {
        
    }
}
