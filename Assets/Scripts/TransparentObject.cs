using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TransparentObject : MonoBehaviour
{
    [Range(0, 1)]
    [SerializeField] private float _transparencyValue = 0.7f;
    [SerializeField] private float _transparencyFadeTime = .4f;

    private SpriteRenderer _spriteRenderer;

    void Awake()
    {
        _spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
       
        if (collision.gameObject.GetComponent<playerController>())
        {
            StartCoroutine(FadeTree(_spriteRenderer, _transparencyFadeTime, _spriteRenderer.color.a, _transparencyValue));
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        
        if (collision.gameObject.GetComponent<playerController>())
        {
            StartCoroutine(FadeTree(_spriteRenderer, _transparencyFadeTime, _spriteRenderer.color.a, 1f));
        }
    }

    private IEnumerator FadeTree(SpriteRenderer _sprite, float _fadeTime, float _startValue, float _targetTransparency)
    {
        float _timeElapsed = 0;

        while (_timeElapsed < _fadeTime)
        {
            _timeElapsed += Time.deltaTime;
            float _newAlpha = Mathf.Lerp(_startValue, _targetTransparency, _timeElapsed / _fadeTime);

            _sprite.color = new Color(_sprite.color.r, _sprite.color.g, _sprite.color.b, _newAlpha);

            yield return null;
        }
    }
}