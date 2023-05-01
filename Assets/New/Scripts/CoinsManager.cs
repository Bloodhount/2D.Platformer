using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PlatformerMVC
{
    public class CoinsManager : IDisposable//MonoBehaviour
    {
        private const float _animationsSpeed = 10;
        private LevelObjectView _coinView;
        private SpriteAnimatorController _spriteAnimator;
        [SerializeField] private List<InteractiveObjectView> _coinViews = new List<InteractiveObjectView>();

        public CoinsManager(List<CoinView> coinViews, SpriteAnimatorController spriteAnimator)
        {
            // _coinView = coinView;
            _spriteAnimator = spriteAnimator;
            // _coinViews = coinViews;
          //  _coinView.OnLevelObjectContact += OnLevelObjectContact;

            foreach (CoinView coin in coinViews)
            {
                //_coinViews.Add(new CoinController());
                // _spriteAnimator.StartAnimation(coinView.SpriteRenderer, AnimState.Coin_rotation, true, _animationsSpeed);
            }

        }
        private void OnLevelObjectContact(LevelObjectView contactView)
        {
            //if (_coinViews.Contains(contactView))
            //{
            //    _spriteAnimator.StopAnimation(contactView.SpriteRenderer);
            //    GameObject.Destroy(contactView.gameObject);
            //}
        }

        public void Dispose()
        {
            //_coinView.OnLevelObjectContact -= OnLevelObjectContact;
        }
    }
}