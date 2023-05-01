using UnityEngine;

namespace PlatformerMVC
{
    public class CannonController
    {
        Transform _muzzleTransform;
        Transform _targetTransform;

        private Vector3 _dir;
        private Vector3 _axis;
        private float _angle;
        public CannonController(Transform muzzleTransform, Transform aimTransform)
        {
            _muzzleTransform = muzzleTransform;
            _targetTransform = aimTransform;
        }
        public void Update()
        {
            _dir = _targetTransform.position - _muzzleTransform.position;
            _angle = Vector3.Angle(Vector3.up, _dir);
            _axis = Vector3.Cross(Vector3.up, _dir);
            _muzzleTransform.rotation = Quaternion.AngleAxis(_angle, _axis);
        }
    }
}

