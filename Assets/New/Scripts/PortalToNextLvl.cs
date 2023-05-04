using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PlatformerMVC
{
    public class PortalToNextLvl : MonoBehaviour
    {
        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.attachedRigidbody && collision.attachedRigidbody.GetComponent<PlayerController>() is PlayerController playerHealth)
            {
                // if (EnemyCounter._KeyIsAvailable && EnemyCounter._allEnemyDie)
                // {
                FindObjectOfType<GameManager>().NextScene();
                // }
            }
            else
            {
                Debug.LogError("GameManager>().NextScene.Error");
            }
        }
    }
}
