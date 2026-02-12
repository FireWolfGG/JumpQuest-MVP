using Godot;
using System;

public partial class TriggerLose : Area2D
{
	[Export] public string RoomLose;
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
