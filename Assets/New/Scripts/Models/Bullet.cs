using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PlatformerMVC
{
    public class Bullet // BulletController
    {
        private float _radius = 0.3f;
        private Vector3 _velocity;
        private float _groundLevel = 0f;
        private float _g = 10f;

        private BulletView _view;

        public Bullet(BulletView view)
        {
            _view = view;
            Active(false);
            //_view.SetVisible(false);
        }
        public void Active(bool value)
        {
            _view.gameObject.SetActive(value);
        }
        //private bool IsGrounded()
        //{
        //    return _view.transform.position.y <= _groundLevel + _radius + float.Epsilon && _velocity.y <= 0;
        //}
        public void Throw(Vector3 position, Vector3 velocity)
        {
            _view.SetVisible(false);
            _view.Transform.position = position;
            _view.Rigidbody2D.velocity = Vector2.zero;
            _view.Rigidbody2D.angularVelocity = 0;
            _view.SetVisible(true);
            _view.Rigidbody2D.AddForce(velocity, ForceMode2D.Impulse);
            //_view.transform.position = position;
            //SetVelocity(velocity);
            //_view.SetVisible(true);
        }
        private void SetVelocity(Vector3 velocity)
        {
            _velocity = velocity;
            var angle = Vector3.Angle(Vector3.left, _velocity);
            var axis = Vector3.Cross(Vector3.left, _velocity);
            _view.transform.rotation = Quaternion.AngleAxis(angle, axis);

            //_dir = _targetTransform.position - _muzzleTransform.position;
            //_angle = Vector3.Angle(Vector3.up, _dir);
            //_axis = Vector3.Cross(Vector3.up, _dir);

        }
        //public void Update()
        //{
        //    if (IsGrounded())
        //    {
        //        SetVelocity(_velocity.Change(y: -_velocity.y));
        //        _view.transform.position = _view.transform.position.Change(y: _groundLevel + _radius);
        //    }
        //    else
        //    {
        //        SetVelocity(_velocity + Vector3.up * _g * Time.deltaTime);
        //        _view.transform.position += _velocity * Time.deltaTime;
        //    }
        //}
    }
}
