using Godot;
using System;

public partial class Bullet : CharacterBody2D
{
    private float Damage = 10f;

    public override void _Process(double delta)
    {
        MoveAndSlide();
    }
	
    private void _On_Collision(Area2D area)
    {
        GD.Print("Bullet collided with: " + area.Name);
        if (area is Enemy)
        {
            GD.Print("Bullet hit an enemy!");
            Enemy enemy = (Enemy)area;
            enemy.TakeDamage(Damage);
        }
        QueueFree();
    }
    private void _On_ScreenLeave()
    {
        QueueFree();
    }
    public void SetDamage(float damage)
    {
        Damage = damage;
    }
}
