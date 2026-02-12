using Godot;
using System;

public partial class MainMenu : Node2D
{
	[Export] private AnimationPlayer animation;
	[Export] private Button ButtonPlay;
	[Export] private Button ButtonExit;
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		ResetGame();
		var music = GD.Load<AudioStream>("res://Asset/sound/music/medieval-fantasy-142837.mp3");
		MusicManager.Instance.MusicPlay(music);
		ButtonPlay.GrabFocus();
		animation.AnimationFinished += GoToGame;

	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{

		if (ButtonPlay.ButtonPressed)
			animation.Play("transition_anim");

		else if (ButtonExit.ButtonPressed)
			GetTree().CreateTimer(0.1).Timeout += () => GetTree().CallDeferred("quit", true);
	}

	public void GoToGame(StringName AnimName)
	{
		if (AnimName == "transition_anim")
			GetTree().ChangeSceneToFile("res://Scenes/Room1.tscn");
	}

	public void ResetGame() => Money.count = 0;
}