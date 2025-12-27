
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlimeController : MonoBehaviour
{
    public float _moveSpeedSlime = 3.5f;
    public DetectionController _detectionArea;
    private Vector2 _slimeDirection;
    private Rigidbody2D _slimeRigidbody2D;

    private SpriteRenderer _spriteRenderer;

    void Start()
    {
        _slimeRigidbody2D = GetComponent<Rigidbody2D>();
        _spriteRenderer = GetComponent<SpriteRenderer>();
    }

    void FixedUpdate()
    {
        if (_detectionArea._detectedObjs.Count > 0)
        {
            _slimeDirection = (_detectionArea._detectedObjs[0].transform.position - transform.position).normalized;

            _slimeRigidbody2D.MovePosition(_slimeRigidbody2D.position + _slimeDirection * _moveSpeedSlime * Time.fixedDeltaTime);

            if (_slimeDirection.x > 0)
            {
                _spriteRenderer.flipX = false; 
            }
            else if (_slimeDirection.x < 0)
            {
                _spriteRenderer.flipX = true; 
            }
        }
    }
}