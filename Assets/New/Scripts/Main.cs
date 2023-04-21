using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PlatformerMVC
{

    public class Main : MonoBehaviour
    {
        [SerializeField] private LevelObjectView _playerView;
        [SerializeField] private AnimationConfig _config;
        [SerializeField] private SpriteAnimatorController _playerAnimator;

        private void Awake()
        {
            _config = Resources.Load<AnimationConfig>("SpriteAnimsCfg");
            _playerAnimator = new SpriteAnimatorController(_config);
            _playerAnimator.StartAnimation(_playerView._spriteRenderer, track: AnimState.Idle, true, 20f);
            // _playerAnimator.StartAnimation(_playerView._spriteRenderer, AnimState.Run, true, 20f);
        }
        void Update()
        {
            TempInputMethod();

            _playerAnimator.Update();
        }

        private void TempInputMethod()
        {
            if (Input.GetKey(KeyCode.R))
            {
                _playerAnimator.StartAnimation(_playerView._spriteRenderer, track: AnimState.Run, true, 20f);
            }

            if (Input.GetKey(KeyCode.I))
            {
                _playerAnimator.StartAnimation(_playerView._spriteRenderer, track: AnimState.Idle, true, 20f);
            }

            if (Input.GetKey(KeyCode.J))
            {
                _playerAnimator.StartAnimation(_playerView._spriteRenderer, track: AnimState.Jump, true, 5f);
            }
        }
    }
}
