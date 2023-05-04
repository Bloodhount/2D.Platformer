using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PlatformerMVC
{
    public class CoinController //: MonoBehaviour
    {
        [SerializeField] private AnimationConfig _config;
        [SerializeField] private SpriteAnimatorController _coinAnimator;
        // [SerializeField] private LevelObjectView _coinView;

        private InteractiveObjectView _coinView;

        private float _animationSpeed = 20f;
        public CoinController(InteractiveObjectView view)
        {
            _coinView = view;
            Active(false);
        }
        //public CoinController(CoinView coinView)
        //{
        //    _coinView = coinView;
        //    _config = Resources.Load<AnimationConfig>("SpriteAnimsCfg");
        //    _coinAnimator = new SpriteAnimatorController(_config);
        //    _coinAnimator.StartAnimation(_coinView.SpriteRenderer, track: AnimState.Coin_rotation, true, _animationSpeed / 2);
        //}
        public void Active(bool value)
        {
            _coinView.gameObject.SetActive(value);
        }
        public void Update()
        {

        }
    }
}
