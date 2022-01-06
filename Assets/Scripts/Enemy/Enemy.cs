using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Enemy : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private int _damage;
    [SerializeField] private Vector2 _direction;
    [SerializeField] private ParticleSystem _particle;

    private void Update()
    {
        transform.Translate(_direction * _speed * Time.deltaTime); 
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Instantiate(_particle, gameObject.transform.position, Quaternion.identity);
        _particle.Play();

        if (collision.TryGetComponent(out Player player))
        {
            player.ApplyDamage(_damage);
        }
        
        Die();
    }

    private void Die()
    {
        Destroy(gameObject);
    }
}
