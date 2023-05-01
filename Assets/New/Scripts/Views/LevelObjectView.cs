using UnityEngine;

namespace PlatformerMVC
{
    public class LevelObjectView : MonoBehaviour
    {
        public Transform Transform;
        public SpriteRenderer SpriteRenderer;
        public Collider2D Collider2D;
        public Rigidbody2D Rigidbody2D;
        //internal Action<BulletView> TakeDamage;

        //public Action<LevelObjectView> OnLevelObjectContact { get; set; }

        //private void OnTriggerEnter2D(Collider2D collision)
        //{
        //    Debug.LogWarning(collision.name);
        //    var levelObject = gameObject.GetComponent<LevelObjectView>();
        //    OnLevelObjectContact?.Invoke(levelObject);
        //}

        #region MyTestRegion
        //[SerializeField] TextMeshProUGUI text;
        //void MessageText(string s)
        //{
        //    text.text = s;
        //}
        #endregion
    }
}
