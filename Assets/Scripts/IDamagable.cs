using System;

namespace SpaceShip
{
    public interface IDamagable
    {
        event Action OnExploded;

        void TakeHit(int damage);

        void Explode();
    }
}
