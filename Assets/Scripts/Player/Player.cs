using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Player : MonoBehaviour
{
    [SerializeField] private int _health;
    [SerializeField] private int _needCoinsAmount;
    [SerializeField] private PanelShower _panelShower;

    private PlayerMovement _playerMovement;
    private int _coinsAmount = 0;
    private int _currentCoinsAmount;

    public event UnityAction<int> CoinAdded;
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

    //private void OnTriggerEnter2D(Collider2D collision)
    //{
    //    if (collision.TryGetComponent(out Coin coin))
    //    {
    //        AddCoin();
    //        coin.enabled = false;
    //    }
    //}

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
        _playerMovement.enabled = false;
        StartCoroutine(StopGame());
        _panelShower.ShowPanel();
        
    }

    private void AddHealth()
    {
        _currentCoinsAmount = 0;
        _health += 1;
        HealthChanged?.Invoke(_health);
    }

    private IEnumerator StopGame()
    {
        yield return new WaitForSeconds(1);
        Time.timeScale = 0;
    }
}
