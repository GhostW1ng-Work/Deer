using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Player : MonoBehaviour
{
    [SerializeField] private int _health;
    [SerializeField] private int _needCoinsAmount;


    private PlayerMovement _playerMovement;
    private int _coinsAmount = 0;
    private int _currentCoinsAmount;

    public event UnityAction<int> CoinAdded;
    public event UnityAction PlayerDied;
    public event UnityAction<int> HealthChanged;

    private void Awake()
    {
        CoinAdded?.Invoke(_coinsAmount);
        
    }

    private void Start()
    {
        _playerMovement = GetComponent<PlayerMovement>();
        HealthChanged?.Invoke(_health);
    }


    private void Update()
    {
        if (_currentCoinsAmount >= _needCoinsAmount)
            AddHealth();
    }

    public void ApplyDamage(int damage)
    {
        _health -= damage;
        HealthChanged?.Invoke(_health);

        if (_health <= 0)
            Die();
    }

    public void AddCoin()
    {
        _coinsAmount++;
        _currentCoinsAmount++;
        CoinAdded(_coinsAmount);
    }

    private void Die()
    {
        PlayerDied?.Invoke();
        _playerMovement.enabled = false;
    }

    private void AddHealth()
    {
        _currentCoinsAmount = 0;
        _health += 1;
        HealthChanged?.Invoke(_health);
    }
}
