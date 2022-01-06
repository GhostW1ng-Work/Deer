using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloudMover : MonoBehaviour
{
    [SerializeField] private GameObject _container;
    [SerializeField] private float _speed;
 
    private void Update()
    {
        _container.transform.Translate(Vector3.left * _speed * Time.deltaTime);
    }
}
