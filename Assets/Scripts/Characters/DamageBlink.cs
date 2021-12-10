using System.Collections;
using UnityEngine;

[RequireComponent(typeof(SpriteRenderer))]
public class DamageBlink : MonoBehaviour
{
    [SerializeField] Color _blinkColor;
    [SerializeField] int _numberOfBlinks;
    [SerializeField] float _secondsBetweenBlinks;
    Material _material;
    Color _defaultColor;

    private void Awake()
    {
        _material = GetComponent<SpriteRenderer>().material;
        _defaultColor = _material.color;
    }

    public void HealthChanged(HealthChangedArgs args)
    {
        if (args.CurrentHealth < args.PreviousHealth)
        {
            StopAllCoroutines();
            StartCoroutine( BlinkCoroutine() );
        }
    }

    IEnumerator BlinkCoroutine()
    {
        for (int i = 0; i < _numberOfBlinks; i++)
        {
            _material.color = _blinkColor;
            yield return new WaitForSeconds( _secondsBetweenBlinks );
            _material.color = _defaultColor;
            yield return new WaitForSeconds( _secondsBetweenBlinks );
        }
    }
}