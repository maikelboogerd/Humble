using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Humble
{
    interface ICollidable
    {
        Rectangle Bounds { get; }
        bool Intersects(Rectangle rectangle);
        bool Contains(Vector2 point);
    }

    interface IMovable
    {
        Vector2 Position { get; set; }
        void ChangePosition(Vector2 position);
    }

    interface ISpawnable
    {
        Vector2 SpawnPoint { get; set; }
        void Spawn(Vector2 spawnPoint);
        void Respawn();
    }

    interface IKillable
    {
        void Kill();
        bool IsDeath();
    }

    interface IDamageable
    {
        int Health { get; set; }
        void Damage();
        void Heal();
    }
}
