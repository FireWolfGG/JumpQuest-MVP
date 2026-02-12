using Godot;
using System;

public partial class TriggerLose : Area2D
{
	[Export] public string RoomLose;
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		BodyEntered += RestartLevel;
	}

	public void RestartLevel(Node2D body)
	{
		if (body.IsInGroup("Player"))
			GetTree().CallDeferred("change_scene_to_file", $"res://Scenes/{RoomLose}.tscn");	
	}
}
