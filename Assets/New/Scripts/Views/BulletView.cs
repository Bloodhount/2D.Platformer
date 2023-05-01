using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PlatformerMVC
{
    public class BulletView : LevelObjectView
    {
        [SerializeField] private TrailRenderer _trail;

        //private int _damagePoint = 10;
        //public int DamagePoint { get => _damagePoint; set => _damagePoint = value; }

        public void SetVisible(bool visible)
        {
            if (_trail)
            {
                _trail.enabled = visible;
                _trail.Clear();
                SpriteRenderer. enabled = visible;
            }
        }
    }
}
