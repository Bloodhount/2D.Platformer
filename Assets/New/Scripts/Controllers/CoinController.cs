using UnityEngine;

namespace PlatformerMVC
{
    public class CoinController 
    {
        [SerializeField] private AnimationConfig _config;
        [SerializeField] private SpriteAnimatorController _coinAnimator;

        private InteractiveObjectView _coinView;

        private float _animationSpeed = 20f;
        public CoinController(InteractiveObjectView view)
        {
            _coinView = view;
            Active(false);
        }
        public void Active(bool value)
        {
            _coinView.gameObject.SetActive(value);
        }
        public void Update()
        {

        }
    }
}
