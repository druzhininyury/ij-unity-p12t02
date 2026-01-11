using System;
using System.Collections;
using UnityEngine;

public class Counter : MonoBehaviour
{
    [SerializeField] private float _incrementTimeInterval = 0.5f;
    
    private readonly int _incrementStep = 1;
    
    public int Value { get; private set; }

    public event Action<int> ValueChanged;
    
    private Coroutine _coroutine;
    
    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Toggle();
        }
    }

    private IEnumerator Incrementing()
    {
        while (true)
        {
            yield return new WaitForSeconds(_incrementTimeInterval);

            Value += _incrementStep;
            ValueChanged?.Invoke(Value);
        }
    }

    private void Toggle()
    {
        if (_coroutine == null)
        {
            _coroutine = StartCoroutine(Incrementing());
        }
        else
        {
            StopCoroutine(_coroutine);
            _coroutine = null;
        }
    }
}
