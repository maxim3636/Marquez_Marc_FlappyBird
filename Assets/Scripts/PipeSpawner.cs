using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PipeSpawner : MonoBehaviour
{
    [SerializeField] private float _maxTime = 1.5f;
    [SerializeField] private float _heightRange = 0.45f;
    [SerializeField] private GameObject _pipe;
    public GameObject bird;

    private float _timer;

    private void Start(){

        if (bird.GetComponent<FlyBehaviour>().canMove == true)
        {
            SpawnPipe();
        }
    }

    private void Update()
    {
        if (bird.GetComponent<FlyBehaviour>().canMove == true)
        {
            if (_timer > _maxTime)
            {

                SpawnPipe();
                _timer = 0;
            }

            _timer += Time.deltaTime;
        }
    }

    private void SpawnPipe(){

        Vector3 spawnPos = transform.position + new Vector3(-1, Random.Range(-_heightRange, _heightRange));
        GameObject pipe = Instantiate(_pipe, spawnPos, Quaternion.identity);

        Destroy(pipe, 10f);
    }




}
