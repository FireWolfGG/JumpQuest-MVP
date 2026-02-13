using Godot;

public partial class TriggerWin : Area2D
{
	[Export] public string RoomNext;
	[Export] private AnimationPlayer animation;
	public override void _Ready()
	{
		BodyEntered += NextLevel;
		animation.AnimationFinished += AnimFinish;
	}

	public void NextLevel(Node2D body)
	{
		if (!body.IsInGroup("Player")) return;
		animation.Play("transition_anim");
	}

	public void AnimFinish(StringName AnimName)
	{
		if (AnimName == "transition_anim")
			GetTree().CallDeferred("change_scene_to_file", $"res://Scenes/{RoomNext}.tscn");
	}
}