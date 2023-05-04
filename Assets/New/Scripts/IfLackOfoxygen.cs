using UnityEngine;

namespace PlatformerMVC
{
    public class IfLackOfoxygen : InteractiveObjectView
    {
        [SerializeField] private float _timeToDamage = 1.2f;
        private float _timer;
        private void OnTriggerStay2D(Collider2D collision)
        {
            _timer += Time.deltaTime;

            if (_timer > _timeToDamage)
            {
                if (collision.TryGetComponent(out BulletView bulletViewComponent))
                {
                    _timer = 0f;
                    TakeDamage?.Invoke(bulletViewComponent);
                }
            }
        }
    }
}
