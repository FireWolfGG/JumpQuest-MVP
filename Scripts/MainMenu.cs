using Godot;
using System;
using System.Threading;

public partial class MainMenu : Node2D
{
	[Export] private AnimationPlayer animation;
	[Export] private Button buttonPlay;
	[Export] private Button buttonExit;
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		ResetGame();
		var music = GD.Load<AudioStream>("res://Asset/sound/music/medieval-fantasy-142837.mp3");
		MusicManager.Instance.MusicPlay(music);
		buttonPlay.GrabFocus();
		animation.AnimationFinished += GoToGame;
		buttonPlay.Pressed += () => animation.Play("transition_anim");
		buttonExit.Pressed += () => GetTree().CreateTimer(0.1).Timeout += () => GetTree().Quit();
	}

	public void GoToGame(StringName AnimName)
	{
		if (AnimName == "transition_anim")
			GetTree().ChangeSceneToFile("res://Scenes/Room1.tscn");
	}

	public void ResetGame() => Money.Count = 0;
}