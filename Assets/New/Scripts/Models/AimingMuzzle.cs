using UnityEngine;

namespace PlatformerMVC
{
    public class AimingMuzzle
    {
        Transform _muzzleTransform;
        Transform _aimTransform;
        public AimingMuzzle(Transform muzzleTransform, Transform aimTransform)
        {
            _muzzleTransform = muzzleTransform;
            _aimTransform = aimTransform;
        }
        public void Update()
        {
            var dir = _aimTransform.position - _muzzleTransform.position;
            var angle = Vector3.Angle(Vector3.up, dir);
            var axis = Vector3.Cross(Vector3.up, dir);
            _muzzleTransform.rotation = Quaternion.AngleAxis(angle, axis);
        }

    }
}