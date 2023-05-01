using UnityEngine;

public class PickUpBonus : MonoBehaviour
{
    [SerializeField] private int _healing = 1;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            var player = collision.gameObject.GetComponent<PlayerCharacter>();
            player.Healing(_healing);
            Destroy(gameObject);
        }
    }
}
