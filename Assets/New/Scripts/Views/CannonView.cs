using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PlatformerMVC
{
    public class CannonView : MonoBehaviour
    {
        public Transform MuzzleTransform;
        public Transform EmitterTransform; // shot start pos
        public List<LevelObjectView> Bullets;
    }
}
