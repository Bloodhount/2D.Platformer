using UnityEngine;

namespace PlatformerMVC
{
    public class ContactPooler
    {
        private Collider2D _collider2D;
        private ContactPoint2D[] _contacts = new ContactPoint2D[5];
        private int _contactCount = 0;
        private float _treshold = 0.2f;

        public bool IsGrounded { get; private set; }
        public bool LeftContact { get; private set; }
        public bool RightContact { get; private set; }

        public ContactPooler(Collider2D collider)
        {
            _collider2D = collider;
        }

        public void Update()
        {
            IsGrounded = false;
            LeftContact = false;
            RightContact = false;

            _contactCount = _collider2D.GetContacts(_contacts);
            for (int i = 0; i < _contactCount; i++)
            {
                if (_contacts[i].normal.y > _treshold) IsGrounded = true;
                if (_contacts[i].normal.x > _treshold) LeftContact = true;
                if (_contacts[i].normal.x < _treshold) RightContact = true;

            }
        }
    }
}
