using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
    private const string TIME = "Time";

    [SerializeField] private ParticleSystem _coinParticle;
    [SerializeField] private Animator _animator;
    [SerializeField] private AudioClip _audio;
    [SerializeField] private float _audioVolume;
    [SerializeField] private Vector3 _audioPosition;
 
    private float _remainingTime = 10;

    private void Update()
    {
        _remainingTime -= Time.deltaTime;

        _animator.SetFloat(TIME, _remainingTime);
        
        if (_remainingTime <= 0)
        {
            Die();
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out Player player))
        {
            Instantiate(_coinParticle, gameObject.transform.position, Quaternion.identity);
            _coinParticle.Play();
            AudioSource.PlayClipAtPoint(_audio, _audioPosition, _audioVolume);

            player.AddCoin();
            Die();
        }
    }
    
    private void Die()
    {
        Destroy(gameObject);
    }
}
