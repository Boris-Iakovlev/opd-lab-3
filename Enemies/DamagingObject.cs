using Godot;
using System;

public partial class DamagingObject : Area2D
{
    [Export]
    protected Vector2 velocity = new Vector2(-300f, 0);

    public override void _Ready()
    {
        VisibleOnScreenNotifier2D notifier = new VisibleOnScreenNotifier2D();
        AddChild(notifier);
        notifier.Connect("screen_exited", new Callable(this, "_On_Screen_Exited"));
    }

    public override void _Process(double delta)
    {
        Move((float)delta);
    }

    protected virtual void Move(float delta)
    {
        Position += velocity * delta;
    }

    private async void _On_Screen_Exited()
    {
        Timer timer = new Timer();
        timer.WaitTime = 1f;
        timer.OneShot = true;
        AddChild(timer);
        timer.Start();
        await ToSignal(timer, "timeout");
        GD.Print($"{Name} has exited the screen and will be freed.");
        QueueFree();
    }

}
