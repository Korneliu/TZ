using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    private const string AnimAttack = "Attack", AnimWalk = "Walk", AnimRun = "Run";
    [SerializeField] private Image _staminaBar;
    [SerializeField] private Animator _animator;
    [SerializeField] private Rigidbody _rigidbody;
    [SerializeField] private Transform _groundCheck, _targetAim;
    [SerializeField] private LayerMask _groundMask;
    [SerializeField] private float _speed = 10f;
    [SerializeField] private float _jumpHeight = 3f;
    [SerializeField] private float _groundDistance = 0.4f;
    [SerializeField] private KeyCode _jump = KeyCode.Space, _run = KeyCode.LeftShift;
    [SerializeField] private ForceMode _jumpForceMode = ForceMode.Impulse;
    [SerializeField] private float _secondsStamina;
    private bool isGrounded;
    private float Speed { get; set; }

    private void Start()
    {
        _staminaBar.fillAmount = 1;
    }

    private void Update()
    {
        MovementPlayer();
        RunPlayer();
    }

    private void MovementPlayer()
    {
        isGrounded = Physics.CheckSphere(_groundCheck.position, _groundDistance, _groundMask);

        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        if (x != 0F || z != 0F)
        {
            _rigidbody.MovePosition(transform.position + new Vector3(x, 0, z) * Speed * Time.fixedDeltaTime);
            _animator.SetBool(AnimWalk, true);
        }
        else _animator.SetBool(AnimWalk, false);

        if (Input.GetKeyDown(_jump) && isGrounded)
            _rigidbody.AddForce(Vector3.up * _jumpHeight, _jumpForceMode);
    }

    private void RunPlayer()
    {
        RaycastHit hit;
        if (Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out hit, float.MaxValue, _groundMask))
        {
            var target = new Vector3(hit.point.x, transform.position.y, hit.point.z);
            transform.LookAt(target);
            _targetAim.position = target + Vector3.up * 2;
            Debug.DrawLine(hit.point + Vector3.up, hit.point, Color.red);
        }

        if (Input.GetKey(_run))
        {
            _staminaBar.fillAmount = Mathf.Clamp(_staminaBar.fillAmount - (Time.deltaTime / _secondsStamina), 0, 1);
            Speed = _speed * 2;
            _animator.SetBool(AnimRun, true);
        }
        else
        {
            _staminaBar.fillAmount = Mathf.Clamp(_staminaBar.fillAmount + (Time.deltaTime / _secondsStamina), 0, 1);
            Speed = _speed;
            _animator.SetBool(AnimRun, false);
        }

        if (Input.GetMouseButtonDown(0))
        {
            _animator.SetTrigger(AnimAttack);
        }
    }
}
