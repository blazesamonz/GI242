using System;
using System.Collections;
using System.Collections.Generic;
using Damage;
using Player;
using UnityEngine;

namespace SpaceShip
{
    public class PlayerSpaceShip : BaseSpaceShip, IDamagable
    {
        public float fireRate = 0.2f;



        public override void Fire()
        {
            var bullet = Instantiate(base.bullet, gunPosition.position, Quaternion.identity);
            bullet.Init();
        }

        public override void Move(Vector2 direction)
        {
            var velocity = direction * speed;

            var newPosition = transform.position;

            newPosition.x = transform.position.x + velocity.x * Time.smoothDeltaTime;
            newPosition.y = transform.position.y + velocity.y * Time.smoothDeltaTime;

            transform.position = newPosition;
        }

        public void Move(Vector2 direction, PlayerController.Boundary boundary)
        {
            Move(direction);

            var newPosition = transform.position;

            newPosition.x = Mathf.Clamp(newPosition.x, boundary.MinX, boundary.MaxX);
            newPosition.y = Mathf.Clamp(newPosition.y, boundary.MinY, boundary.MaxY);

            transform.position = newPosition;
        }

        public void TakeHit(int damage)
        {
            hp -= damage;

            if (hp > 0)
            {
                return;
            }

            Explode();
        }

        public override void Explode()
        {
            OnExploded();
            Destroy(gameObject);
        }
    }
}
