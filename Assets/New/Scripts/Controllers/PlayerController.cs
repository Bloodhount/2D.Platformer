using UnityEngine;

namespace PlatformerMVC
{
    public class PlayerController
    {
        [SerializeField] private LevelObjectView _playerView;
        [SerializeField] private AnimationConfig _config;
        [SerializeField] private SpriteAnimatorController _playerAnimator;
        [SerializeField] private Transform _playerTransform;

        private float _xAxisInput;
        private float _walkSpeed = 3f;

        private float _movingTreshold = 0.2f;
        private float _animationSpeed = 20f;

        private Vector3 _leftScale = new Vector3(-1, 1, 1);
        private Vector3 _rightScale = new Vector3(1, 1, 1);

        private bool _isMoving;
        private bool _isJump;

        private float _jumpForce = 5f;
        private float _jumpTreshold = 1.2f;
        private float g = -9.8f;
        private float _groundLevel = -0.5f;
        private float _yVelocity;


        public PlayerController(LevelObjectView player)
        {
            _config = Resources.Load<AnimationConfig>("SpriteAnimsCfg");
            _playerAnimator = new SpriteAnimatorController(_config);
            _playerAnimator.StartAnimation(player._spriteRenderer, track: AnimState.Idle, true, _animationSpeed);
            _playerView = player;
            _playerTransform = player.transform;
        }
        public void Update()
        {
            _xAxisInput = Input.GetAxis("Horizontal");
            _isMoving = Mathf.Abs(_xAxisInput) > _movingTreshold;

            _isJump = Input.GetAxis("Vertical") > 0;

            if (_isMoving)
            {
                MoveTowards();
            }

            if (IsGrounded())
            {
                _playerAnimator.StartAnimation(_playerView._spriteRenderer, track: _isMoving ? AnimState.Run : AnimState.Idle, true, _animationSpeed);
                if (_isJump && _yVelocity <= 0)
                {
                    _yVelocity = _jumpForce;
                }
                else if (_yVelocity < 0)
                {
                    _yVelocity = 0;
                    _playerTransform.position = new Vector3(_playerTransform.position.x, _groundLevel, _playerTransform.position.z);
                }
            }
            else
            {
                if (_yVelocity > _jumpTreshold) /*(Mathf.Abs(_yVelocity) > _jumpTreshold)*/
                {
                    _playerAnimator.StartAnimation(_playerView._spriteRenderer, track: AnimState.Jump, true, _animationSpeed);
                }
                else if (_yVelocity < _jumpTreshold)
                {
                    _playerAnimator.StartAnimation(_playerView._spriteRenderer, track: AnimState.Fall, true, _animationSpeed);
                }
                _yVelocity += g * Time.deltaTime;
                _playerTransform.position += Vector3.up * (Time.deltaTime * _yVelocity);
            }

            TempInputAnimTestMethod();

            _playerAnimator.Update();
        }

        private void MoveTowards()
        {
            _playerTransform.position += Vector3.right * (Time.deltaTime * _walkSpeed * (_xAxisInput < 0 ? -1 : 1));
            _playerTransform.localScale = _xAxisInput < 0 ? _leftScale : _rightScale;
        }

        public bool IsGrounded()
        {
            return _playerTransform.position.y <= _groundLevel && _yVelocity <= 0;
        }

        private void TempInputAnimTestMethod()
        {
            if (Input.GetKey(KeyCode.LeftShift))
            {
                _playerAnimator.StartAnimation(_playerView._spriteRenderer, track: AnimState.Sit, true, _animationSpeed);
            }

            if (Input.GetKey(KeyCode.LeftShift) && _isMoving)
            {
                _playerAnimator.StartAnimation(_playerView._spriteRenderer, track: AnimState.Roll, true, _animationSpeed);
            }

            if (Input.GetKey(KeyCode.R))
            {
                _playerAnimator.StartAnimation(_playerView._spriteRenderer, track: AnimState.Run, true, _animationSpeed);
            }

            if (Input.GetKey(KeyCode.I))
            {
                _playerAnimator.StartAnimation(_playerView._spriteRenderer, track: AnimState.Idle, true, _animationSpeed);
            }

            if (Input.GetKey(KeyCode.J))
            {
                _playerAnimator.StartAnimation(_playerView._spriteRenderer, track: AnimState.Jump, true, _animationSpeed / 5);
            }
        }
    }
}
