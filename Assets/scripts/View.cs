using TMPro;
using UnityEngine;

[RequireComponent(typeof(TMP_Text))]
public class View : MonoBehaviour
{
    [SerializeField] private Counter _counter;

    private TMP_Text _text;

    private void Awake()
    {
        _text = GetComponent<TMP_Text>();
    }

    private void OnCounterValueChanged(int value)
    {
        _text.text = value.ToString();
    }

    private void OnEnable()
    {
        if (_counter == null)
        {
            return;
        }

        _counter.ValueChanged += OnCounterValueChanged;
    }

    private void OnDisable()
    {
        if (_counter != null)
        {
            _counter.ValueChanged -= OnCounterValueChanged;
        }
    }
}
