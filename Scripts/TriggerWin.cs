using Godot;

public partial class TriggerWin : Area2D
{
	[Export] public string RoomNext;
	[Export] public AnimationPlayer animation;
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		BodyEntered += NextLevel;
		animation.AnimationFinished += AnimFinish;
	}

	public void NextLevel(Node2D body)
	{
		if (body.IsInGroup("Player"))
		{
			animation.Play("transition_anim");
		}
	}

	public void AnimFinish(StringName AnimName)
	{
		if (AnimName == "transition_anim")
		{
			GetTree().CallDeferred("change_scene_to_file", $"res://Scenes/{RoomNext}.tscn");
		}
	}
}
