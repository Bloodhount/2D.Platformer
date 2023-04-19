using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpBonus : MonoBehaviour
{
    [SerializeField] private int _healing = 1;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
   
    }
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
