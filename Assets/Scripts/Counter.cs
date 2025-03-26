using System;
using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;

public class Counter : MonoBehaviour
{
    public event Action<float> CountChanged;

    [SerializeField] private float _increaseNumber = 1f;
    [SerializeField] private float _countRate = 0.5f;

    private bool _isCounting = true;
    private Coroutine _countCoroutine;

    public float Value { get; private set; }

    private void Awake()
    {
        _countCoroutine = StartCoroutine(CountTime());
    }

    private void Update()
    {
        bool isClicked = Mouse.current.leftButton.wasPressedThisFrame;

        if (isClicked)
        {
            ChangeCountState();
        }
    }

    private void ChangeCountState()
    {
        _isCounting = !_isCounting;

        if (_isCounting)
        {
            _countCoroutine = StartCoroutine(CountTime());
        }
        else
        {
            if (_countCoroutine != null)
            {
                StopCoroutine(_countCoroutine);
            }
        }
    }

    private IEnumerator CountTime()
    {
        WaitForSeconds wait = new WaitForSeconds(_countRate);

        while (enabled)
        {
            yield return wait;

            Value += _increaseNumber;
            CountChanged?.Invoke(Value);
        }
    }
}
