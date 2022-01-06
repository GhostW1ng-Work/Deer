using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
    private const string TIME = "Time";

    [SerializeField] private ParticleSystem _coinParticle;
    [SerializeField] private Animator _animator;

    private float _remainingTime = 10;

    private void Update()
    {
        _remainingTime -= Time.deltaTime;

        _animator.SetFloat(TIME, _remainingTime);
        
        if (_remainingTime <= 0)
        {

            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out Player player))
        {
            Instantiate(_coinParticle, gameObject.transform.position, Quaternion.identity);
            _coinParticle.Play();
        }
    }
}
