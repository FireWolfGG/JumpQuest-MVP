using Godot;
using System;

public partial class Player : CharacterBody2D
{
    public const float Speed = 300.0f;
    public const float JumpVelocity = -400.0f;
    [Export] public AnimatedSprite2D sprite;
    private bool isJumping = false;
    private bool facingRight;

    public override void _PhysicsProcess(double delta)
    {
        Vector2 velocity = Velocity;

        if (!IsOnFloor())
        {
            velocity += GetGravity() * (float)delta;
            sprite.Play("Jump");
            isJumping = true;
        }

        else
            isJumping = false;

        if (Input.IsActionJustPressed("Jump") && IsOnFloor())
        {
            velocity.Y = JumpVelocity;
            isJumping = true;
        }

        // Движение по X
        Vector2 direction = new Vector2(Input.GetAxis("ui_left", "ui_right"), 0);

        if (direction.X != 0)
        {
            velocity.X = direction.X * Speed;
            facingRight = direction.X > 0;
            sprite.FlipH = !facingRight;

            if (!isJumping)
            {
                sprite.Play("Walk");
            }
        }
        else
        {
            velocity.X = Mathf.MoveToward(Velocity.X, 0, Speed);
            
            if (!isJumping)
            {
                sprite.Play("Idle");
            }
        }

        Velocity = velocity;
        MoveAndSlide();
        
        if (IsOnFloor() && isJumping)
        {
            isJumping = false;
            sprite.Play("Idle");
        }
    }
}