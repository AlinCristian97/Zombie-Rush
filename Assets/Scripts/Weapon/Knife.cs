using System.Collections;
using UnityEngine;

namespace Weapon
{
    public class Knife : Weapon
    {
        protected override void Attack()
        {
            Debug.Log("Knife attack!");
            //knife attack
        }
    }
}