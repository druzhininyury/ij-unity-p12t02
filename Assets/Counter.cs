using System.Collections;
using TMPro;
using UnityEngine;

[RequireComponent(typeof(TMP_Text))]
public class Counter : MonoBehaviour
{
    [SerializeField] private float _incrementTimeInterval = 0.5f;

    private TMP_Text _text;
    private int _counter = 0;
    private readonly int _counterStep = 1;
    
    private Coroutine _counterCoroutine;
    
    private void Start()
    {
        _text = GetComponent<TMP_Text>();
        _text.text = _counter.ToString();
    }
    
    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            ToggleCounter();
        }
    }

    private IEnumerator CounterCoroutine()
    {
        while (true)
        {
            yield return new WaitForSeconds(_incrementTimeInterval);

            _counter += _counterStep;
            _text.text = _counter.ToString();
        }
    }

    private void ToggleCounter()
    {
        if (_counterCoroutine == null)
        {
            _counterCoroutine = StartCoroutine(CounterCoroutine());
        }
        else
        {
            StopCoroutine(_counterCoroutine);
            _counterCoroutine = null;
        }
    }
}
