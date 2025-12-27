using UnityEngine;

public class playerController : MonoBehaviour
{
    private Rigidbody2D _playerRigidibody2D;
    private Animator _playerAnimator;
    public float _playerSpeed;
    private float _playerInitialSpeed;
    public float _playerRumSpeed;
    private Vector2 _playerDirection;

    private bool _isAttack = false;

    void Start()
    {
        _playerRigidibody2D = GetComponent<Rigidbody2D>();
        _playerAnimator = GetComponent<Animator>();

        _playerInitialSpeed = _playerSpeed;
    }

    void Update()
    {
    }

    void FixedUpdate()
    {
        _playerDirection = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));

        if (_playerDirection.sqrMagnitude > 0.1f)
        {
            _playerAnimator.SetInteger("Movimento", 1);

            _playerAnimator.SetFloat("AxisX", _playerDirection.x);
            _playerAnimator.SetFloat("AxisY", _playerDirection.y);
            MovePlayer();
        }
        else
        {
            _playerAnimator.SetInteger("Movimento", 0);
        }

        PlayerRun();
        OnAttack();

        if (_isAttack)
        {
            _playerAnimator.SetInteger("Movimento", 2);
        }
    }

    void MovePlayer()
    {
        _playerRigidibody2D.MovePosition(_playerRigidibody2D.position + _playerDirection.normalized * _playerSpeed * Time.fixedDeltaTime);
    }


    void PlayerRun()
    {
        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            _playerSpeed = _playerRumSpeed;
        }

        if (Input.GetKeyUp(KeyCode.LeftShift))
        {
            _playerSpeed = _playerInitialSpeed;
        }
    }

    void OnAttack()
    {
        if (Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(1))
        {
            _isAttack = true;
        }
        if (Input.GetKeyUp(KeyCode.Space) || Input.GetMouseButtonUp(1))
        {
            _isAttack = false;
        }
    }
}