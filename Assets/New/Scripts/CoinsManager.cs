using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PlatformerMVC
{
    public class CoinsManager : IDisposable//MonoBehaviour
    {
        private const float _animationsSpeed = 10;
        private LevelObjectView _characterView;
        private SpriteAnimatorController _spriteAnimator;
        private List<LevelObjectView> _coinViews;

        public CoinsManager(LevelObjectView characterView, List<LevelObjectView> coinViews, SpriteAnimatorController spriteAnimator)
        {
            _characterView = characterView;
            _spriteAnimator = spriteAnimator;
            _coinViews = coinViews;
            _characterView.OnLevelObjectContact += OnLevelObjectContact;

            foreach (var coinView in coinViews)
            {
                _spriteAnimator.StartAnimation(coinView.SpriteRenderer,
                AnimState.Coin_rotation, true, _animationsSpeed);
            }

        }
        private void OnLevelObjectContact(LevelObjectView contactView)
        {
            if (_coinViews.Contains(contactView))
            {
                _spriteAnimator.StopAnimation(contactView.SpriteRenderer);
                GameObject.Destroy(contactView.gameObject);
            }
        }

        public void Dispose()
        {
            _characterView.OnLevelObjectContact -= OnLevelObjectContact;
        }
    }
}