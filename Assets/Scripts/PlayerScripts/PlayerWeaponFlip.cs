using System;
using UnityEngine;


public class PlayerWeaponFlip : MonoBehaviour
{

    public SpriteRenderer rendPlayerWeapon;

    public Animator plWeapAnim;

   // public float PlayerDirX;
    public Vector2 plWeapDirX;
    public bool plWeapRight = true;

    void FlipPlayerWeapon()
    {
       // plWeapAnim.SetFloat("moveX", plWeapDirX.x);
       //// rendPlayerWeapon.
        if ((plWeapDirX.x > 0 && !plWeapRight) || (plWeapDirX.x < 0 && plWeapRight))
        {          
            transform.localScale *= new Vector2(-1, 1);
            plWeapRight = !plWeapRight;
           // rendPlayerWeapon.flipX = false;
        }
        // //else if (plWeapDirX.x < 0)
        // //{
        // //    rendPlayerWeapon.flipX = true;
        // //}
    }

    void Start()
    {
        plWeapDirX = GameObject.Find("Player").GetComponent<PlayerCharacter>().moveVector;
        rendPlayerWeapon = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        FlipPlayerWeapon();
    }

  
}
