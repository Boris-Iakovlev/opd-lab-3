using Godot;
using System;

namespace learningproject2.Enemies.Zombie;

[GlobalClass]
public partial class Zombie : Enemy
{   
    private float spawnX = 1300f;
    private float spawnY = 450f;

    public override Vector2 GetSpawnPosition()
    {
        return new Vector2(
            spawnX,
            spawnY
        );
    }
}
