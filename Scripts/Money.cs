using Godot;
using System;
using System.Collections;

public partial class Money : Area2D
{
	[Export] private AudioStreamPlayer audio;
	public static int Count;
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		BodyEntered += GiveMoney;
	}

	public void GiveMoney(Node2D body)
	{
		if (body.IsInGroup("Player"))
		{
			Count++;
			audio.Play();
			Visible = false;
			GetTree().CreateTimer(0.1).Timeout += QueueFree;
		}

		else return;
	}
}