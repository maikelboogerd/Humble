using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Humble
{
    public interface ICollidable
    {
        Rectangle Bounds { get; }
        bool Intersects(Rectangle rectangle);
        bool Contains(Vector2 point);
    }

    public interface IMoveable
    {
        Vector2 Position { get; set; }
        int MovementSpeed { get; }
        void ChangePosition(Vector2 position);
    }

    public interface ISpawnable
    {
        Vector2 SpawnPoint { get; set; }
        void Spawn(Vector2 spawnPoint);
        void Respawn();
    }

    interface IKillable
    {
        void Kill();
        void Revive();
        bool IsDeath();
    }

    interface IDamageable
    {
        int Health { get; set; }
        void Damage();
        void Heal();
    }
}
