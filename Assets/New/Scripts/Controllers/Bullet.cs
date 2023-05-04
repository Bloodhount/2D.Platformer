using UnityEngine;

namespace PlatformerMVC
{
    public class Bullet // BulletController
    {
        private Vector3 _velocity;
        private BulletView _view;

        public Bullet(BulletView view)
        {
            _view = view;
            Active(false);
        }
        public void Active(bool value)
        {
            _view.gameObject.SetActive(value);
        }

        public void Throw(Vector3 position, Vector3 velocity)
        {
            _view.SetVisible(false);
            _view.Transform.position = position;
            _view.Rigidbody2D.velocity = Vector2.zero;
            _view.Rigidbody2D.angularVelocity = 0;
            _view.SetVisible(true);
            _view.Rigidbody2D.AddForce(velocity, ForceMode2D.Impulse);
        }
        private void SetVelocity(Vector3 velocity)
        {
            _velocity = velocity;
            var angle = Vector3.Angle(Vector3.left, _velocity);
            var axis = Vector3.Cross(Vector3.left, _velocity);
            _view.transform.rotation = Quaternion.AngleAxis(angle, axis);
        }
    }
}
