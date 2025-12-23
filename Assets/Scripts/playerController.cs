using UnityEngine;  // <--- ESSA LINHA É A MÁGICA QUE FALTA!

public class playerController : MonoBehaviour
{
    private Rigidbody2D _playerRigidibody2D;
    private Animator _playerAnimator;
    public float _playerSpeed;
    private float _playerInitialSpeed;
    public float _playerRumSpeed;
    private Vector2 _playerDirection;

    void Start()
    {
        _playerRigidibody2D = GetComponent<Rigidbody2D>();
        _playerAnimator = GetComponent<Animator>();

        _playerInitialSpeed = _playerSpeed;
    }

    void Update()
    {
        _playerDirection = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));

        if (_playerDirection.sqrMagnitude > 0)
        {
            _playerAnimator.SetInteger("Movimento", 1);
        }
        else
        {
            _playerAnimator.SetInteger("Movimento", 0);
        }

        Flip();

        PlayerRun();
    }

    void FixedUpdate()
    {
        _playerRigidibody2D.MovePosition(_playerRigidibody2D.position + _playerDirection * _playerSpeed * Time.fixedDeltaTime);
    }
    void Flip()
    {
        if (_playerDirection.x > 0)
        {        
            transform.eulerAngles = new Vector2(0f, 0f);
        }
        else if (_playerDirection.x < 0)
        {
            
            transform.eulerAngles = new Vector2(0f, 180f);
        }
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
}