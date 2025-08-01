using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PipeSpawner : MonoBehaviour
{
    [SerializeField] private float _maxTime = 1.5f;
    [SerializeField] private float _heightRange = 0.45f;
    [SerializeField] private GameObject _pipe;
    [SerializeField] private float _speedIncrease = 0.1f;
    [SerializeField] private float _spawnTimeDecrease = 0.1f;

    private float _timer;
    private float _currentSpeed = 0.65f;
    private float _currentSpawnTime = 1.5f;

    private void Start()
    {
        SpawnPipe();
    }

    private void Update()
    {
        if (_timer > _currentSpawnTime)
        {
            SpawnPipe();
            _timer = 0;
        }

        _timer += Time.deltaTime;
    }

    private void SpawnPipe()
    {
        Vector3 spawnPos = transform.position + new Vector3(0, Random.Range(-_heightRange, _heightRange));
        GameObject pipe = Instantiate(_pipe, spawnPos, Quaternion.identity);
        
        // Boruya mevcut hızı ver
        MovePİpe movePipe = pipe.GetComponent<MovePİpe>();
        if (movePipe != null)
        {
            movePipe.SetSpeed(_currentSpeed);
        }
        
        Destroy(pipe, 10f);
    }

    public void IncreaseSpeed()
    {
        _currentSpeed += _speedIncrease;
        _currentSpawnTime -= _spawnTimeDecrease;
        
        // Minimum spawn süresini koru
        if (_currentSpawnTime < 0.5f)
        {
            _currentSpawnTime = 0.5f;
        }
    }
}
