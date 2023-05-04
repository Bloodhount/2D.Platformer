using System;
using UnityEngine;

namespace PlatformerMVC
{
    public class InteractiveObjectView : LevelObjectView
    {
        public Action<BulletView> TakeDamage { get; set; }
        public Action<CoinView> CollectCoin { get; set; }
        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.TryGetComponent(out BulletView bulletViewComponent))
            {
                TakeDamage?.Invoke(bulletViewComponent);
            }
            if (collision.TryGetComponent(out CoinView coinViewComponent))
            {
                CollectCoin?.Invoke(coinViewComponent);
            }
        }
    }
}
