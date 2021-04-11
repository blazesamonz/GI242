using System;
using System.Collections;
using System.Collections.Generic;
using SpaceShip;
using UnityEngine;

public class EnemySpaceShip : BaseSpaceShip, IDamagable
{
   public event Action OnExploded;

   public void Explode()
   {

   }

   public override void Fire()
   {
      var bullet = Instantiate(defaultBullet, gunPosition.position, Quaternion.identity);
      bullet.Init();

   }

   public void Init(float hp, float speed)
   {

   }

   public void TakeHit(int damage)
   {
      
   }
}
