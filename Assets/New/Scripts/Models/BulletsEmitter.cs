using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PlatformerMVC
{
   // [Serializable]
    public class BulletsEmitter //: MonoBehaviour // EmitterController
    {
        private float _delay = 2;  // const
        private float _startSpeed = 11;  // const

        //public List<LevelObjectView> Bullets;
        [SerializeField] private List<Bullet> _bulletsControllers = new List<Bullet>();
        private Transform _transform;

        private int _currentIndex;
        private float _timeTillNextBullet;

        public BulletsEmitter(List<BulletView> bulletsViews, Transform emitterTransform) //  public BulletsEmitter(List<BulletView> bulletViews, Transform transform)
        {
            // this._bullets = bulletsController; ;
            //_bullets = new List<Bullet>();
            _transform = emitterTransform;

            foreach (BulletView bulletView in bulletsViews)
            {
                _bulletsControllers.Add(new Bullet(bulletView));
            }
        }

        public void Update()
        {
            if (_timeTillNextBullet > 0)
            {
                _timeTillNextBullet -= Time.deltaTime;
                _bulletsControllers[_currentIndex].Active(false);
            }
            else
            {
                _bulletsControllers[_currentIndex].Active(true);
                _timeTillNextBullet = _delay;
                _bulletsControllers[_currentIndex].Throw(_transform.position, _transform.up * _startSpeed); // -_transform.up 
                _currentIndex++;
                if (_currentIndex >= _bulletsControllers.Count) _currentIndex = 0;
            }
            //_bulletsControllers.ForEach(b => b.Update());
        }
    }
}