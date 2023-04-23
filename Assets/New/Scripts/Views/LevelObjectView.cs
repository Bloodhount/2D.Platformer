using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

namespace PlatformerMVC
{
    public class LevelObjectView : MonoBehaviour
    {
        public Transform _transform;
        public SpriteRenderer _spriteRenderer;
        public Collider2D _collider;
        public Rigidbody2D _rigidbody;

        #region MyTestRegion
        TextMeshProUGUI text;
        void MessageText(string s)
        {
            text.text = s;
        }
        #endregion
    }
}
