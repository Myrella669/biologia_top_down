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

    // UPDATE: Aqui a gente lê as TECLAS (Inputs)
    void Update()
    {
        // 1. Captura a direção das setinhas
        _playerDirection = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));

        // 2. Controla a Animação de Andar
        if (_playerDirection.sqrMagnitude > 0.1f)
        {
            _playerAnimator.SetInteger("Movimento", 1);
            _playerAnimator.SetFloat("AxisX", _playerDirection.x);
            _playerAnimator.SetFloat("AxisY", _playerDirection.y);
        }
        else
        {
            _playerAnimator.SetInteger("Movimento", 0);
        }

        // 3. Verifica se correu ou atacou
        PlayerRun();
        OnAttack();

        // 4. Força a animação de ataque se estiver atacando
        if (_isAttack)
        {
            _playerAnimator.SetInteger("Movimento", 2);
        }
    }

    // FIXED UPDATE: Aqui a gente mexe na FÍSICA (Mover o boneco)
    void FixedUpdate()
    {
        if (_playerDirection.sqrMagnitude > 0.1f)
        {
            MovePlayer();
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
        // Agora aceita: CTRL Esquerdo OU Botão Esquerdo (0) OU Botão Direito (1)
        if (Input.GetKeyDown(KeyCode.LeftControl) || Input.GetMouseButtonDown(0) || Input.GetMouseButtonDown(1))
        {
            _isAttack = true;
            _playerSpeed = 0;
        }

        // Tem que soltar qualquer um deles para voltar a andar
        if (Input.GetKeyUp(KeyCode.LeftControl) || Input.GetMouseButtonUp(0) || Input.GetMouseButtonUp(1))
        {
            _isAttack = false;
            _playerSpeed = _playerInitialSpeed;
        }
    }
}