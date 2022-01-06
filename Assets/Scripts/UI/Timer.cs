using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Timer : MonoBehaviour
{
    [SerializeField] private TMP_Text _time;

    private float _currentTime;

    public float CurrentTime => _currentTime;

    private void Start()
    {
        _time.text = _currentTime.ToString();
    }

    private void Update()
    {
        _currentTime += Time.deltaTime;
        int timeText = Mathf.RoundToInt(_currentTime);
        _time.text = timeText.ToString();
    }
}
