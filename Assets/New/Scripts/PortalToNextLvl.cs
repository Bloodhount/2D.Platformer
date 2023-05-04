using UnityEngine;

namespace PlatformerMVC
{
    public class PortalToNextLvl : MonoBehaviour
    {
        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.attachedRigidbody && collision.attachedRigidbody.GetComponent<PlayerController>() is PlayerController playerHealth)
            {
                FindObjectOfType<GameManager>().NextScene();
            }
            else
            {
                Debug.LogError("GameManager>().NextScene.Error");
            }
        }
    }
}
