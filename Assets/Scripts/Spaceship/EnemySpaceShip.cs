// using System;
// using System.Collections;
// using System.Collections.Generic;
// using Damage;
// using SpaceShip;
// using UnityEngine;

// namespace SpaceShip
// {
//     public class EnemySpaceShip : BaseSpaceShip, IDamagable
//     {
//         public event Action Exploded;

//         public void Explode()
//         {

//         }

//         public override void Fire()
//         {
//             var bullet = Instantiate(base.bullet, gunPosition.position, Quaternion.identity);
//             bullet.Init();
//         }

//         public override void Move(Vector2 direction)
//         {
//             throw new NotImplementedException();
//         }

//         public void TakeHit(int damage)
//         {

//         }
//     }
// }
