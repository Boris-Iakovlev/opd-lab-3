using Godot;
using System;

public partial class Enemy : DamagingObject
{
    [Export]
    protected float Health;

    public void TakeDamage(float damage)
    {
        Health -= damage;
        GD.Print($"Enemy took {damage} damage. Remaining health: {Health}");
        if (Health <= 0)
        {
            Die();
        }
    }

    private void Die()
    {
        GD.Print("Enemy died.");
        QueueFree();
    }

    public virtual Vector2 GetSpawnPosition()
    {
        // Assuming the enemy spawns at a random position within the viewport
        Vector2 viewportSize = GetViewport().GetVisibleRect().Size;
        return new Vector2(
            (float)GD.RandRange(0.0, viewportSize.X),
            (float)GD.RandRange(0.0, viewportSize.Y)
        );
    }
}
