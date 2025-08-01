using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovePİpe : MonoBehaviour
{
    [SerializeField] private float _speed = 0.65f;

    // Update is called once per frame
    void Update()
    {
        transform.position += Vector3.left * _speed * Time.deltaTime;
    }

    public void SetSpeed(float newSpeed)
    {
        _speed = newSpeed;
    }
}
