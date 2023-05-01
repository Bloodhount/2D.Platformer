using UnityEngine;

namespace PlatformerMVC
{
    public class PlayerController
    {
        #region Fields 
        [SerializeField] private LevelObjectView _playerView;
        [SerializeField] private AnimationConfig _config;
        [SerializeField] private SpriteAnimatorController _playerAnimator;
        [SerializeField] private ContactPooler _contactPooler;

        [SerializeField] private Transform _playerTransform;
        [SerializeField] private Rigidbody2D _playerRigidbody2D;

        [SerializeField] private int _hp = 50;
        public int Hp { get => _hp; private set => _hp = value; }

        private float _walkSpeed = 150f;
        private float _xAxisInput;
        private float _yVelocity;
        private float _xVelocity;

        private float _movingTreshold = 0.2f;
        private float _animationSpeed = 20f;

        private Vector3 _leftScale = new Vector3(-1, 1, 1);
        private Vector3 _rightScale = new Vector3(1, 1, 1);

        private bool _isMoving;
        private bool _isJump;

        private float _jumpForce = 5f;
        private float _jumpTreshold = 1.2f;

        #endregion

        public PlayerController(InteractiveObjectView playerView) // (LevelObjectView playerView)
        {
            _playerView = playerView;
            _playerTransform = playerView.transform;
            _playerRigidbody2D = playerView.Rigidbody2D;

            _config = Resources.Load<AnimationConfig>("SpriteAnimsCfg");
            _playerAnimator = new SpriteAnimatorController(_config);
            _playerAnimator.StartAnimation(playerView.SpriteRenderer, track: AnimState.Fall, false, _animationSpeed / 2);
            _contactPooler = new ContactPooler(playerView.Collider2D);

            playerView.TakeDamage += TakeBulletDamage;
        }

        private void MoveTowards()
        {
            _xVelocity = Time.fixedDeltaTime * _walkSpeed * (_xAxisInput < 0 ? -1 : 1);
            _playerRigidbody2D.velocity = new Vector2(_xVelocity, _yVelocity);
            _playerTransform.localScale = _xAxisInput < 0 ? _leftScale : _rightScale;
        }
        public void TakeBulletDamage(BulletView bullet)
        {
            _hp -= bullet.DamagePoint; Debug.LogWarning(_hp);
        }
        private void Crouch()
        {
            if (Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.DownArrow)) // LeftShift
            {
                _playerAnimator.StartAnimation(_playerView.SpriteRenderer, track: AnimState.Sit, true, _animationSpeed);
            }
            if ((Input.GetKey(KeyCode.S) && _isMoving) || (Input.GetKey(KeyCode.DownArrow) && _isMoving))
            {
                _playerAnimator.StartAnimation(_playerView.SpriteRenderer, track: AnimState.Roll, true, _animationSpeed / 2);
            }
        }

        private void PlayerDie()
        {
            if (_hp <= 0)
            {
                _hp = 0;
                _playerView.SpriteRenderer.enabled = false;
                _playerView.Rigidbody2D.simulated = false;
            }
        }
        private void TempInputAnimTestMethod()
        {

            if (Input.GetKey(KeyCode.R))
            {
                _playerAnimator.StartAnimation(_playerView.SpriteRenderer, track: AnimState.Run, true, _animationSpeed);
            }

            if (Input.GetKey(KeyCode.I))
            {
                _playerAnimator.StartAnimation(_playerView.SpriteRenderer, track: AnimState.Idle, true, _animationSpeed);
            }

            if (Input.GetKey(KeyCode.J))
            {
                _playerAnimator.StartAnimation(_playerView.SpriteRenderer, track: AnimState.Jump, true, _animationSpeed / 5);
            }

            if (Input.GetKey(KeyCode.F))
            {
                _playerAnimator.StartAnimation(_playerView.SpriteRenderer, track: AnimState.Fall, true, _animationSpeed / 5);
            }

            if (Input.GetKey(KeyCode.T))
            {
                _playerAnimator.StartAnimation(_playerView.SpriteRenderer, track: AnimState.Roll, true, 5);
            }
        }
        public void Update()
        {
            PlayerDie();
            _playerAnimator.Update();
            _contactPooler.Update();

            _xAxisInput = Input.GetAxis(InputModel.HORIZONTAL);
            //_xAxisInput = Input.GetAxis("Horizontal");
            // _isJump = Input.GetAxis("Vertical") > 0;
            _isMoving = Mathf.Abs(_xAxisInput) > _movingTreshold;
            _yVelocity = _playerRigidbody2D.velocity.y;

            _playerAnimator.StartAnimation(_playerView.SpriteRenderer, track: _isMoving ? AnimState.Run : AnimState.Idle, true, _animationSpeed);

            if (_isMoving)
            {
                MoveTowards();
            }
            else
            {
                _xVelocity = 0;
                _playerRigidbody2D.velocity = new Vector2(_xVelocity, _playerRigidbody2D.velocity.y);
            }

            if (_contactPooler.IsGrounded)
            {
                if (Input.GetKeyDown(KeyCode.Space) && _yVelocity <= _jumpTreshold) // (_isJump && _yVelocity <= _jumpTreshold)
                {
                    _playerRigidbody2D.AddForce(Vector2.up * _jumpForce, ForceMode2D.Impulse);
                }
            }
            else
            {
                if (_yVelocity > _jumpTreshold)
                {
                    _playerAnimator.StartAnimation(_playerView.SpriteRenderer, track: AnimState.Jump, true, _animationSpeed);
                }
                else if (_yVelocity < -_jumpTreshold)
                {
                    _playerAnimator.StartAnimation(_playerView.SpriteRenderer, track: AnimState.Fall, true, _animationSpeed);
                }
            }

            TempInputAnimTestMethod();

            Crouch();
        }
    }
}
