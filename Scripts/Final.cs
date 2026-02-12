using Godot;
using System;
using System.Net.Http.Headers;

public partial class Final : Control
{
	[Export] private RichTextLabel labelText;
	[Export] private Button buttonResetGame;
	[Export] private Button buttonExit;
	private AudioStreamPlayer audio = new AudioStreamPlayer();
	public override void _Ready()
	{
		AudioStream finalMusic = GD.Load<AudioStream>("res://Asset/sound/music/cloud-of-sorrow-13984.mp3");
		MusicManager.Instance.MusicPlay(finalMusic);
		buttonResetGame.GrabFocus();
		labelText.Text = $"Разработал: [color=orange]FireWolfGG[/color]\nИспользуемый ассет: OakWoods\nСобранные монеты: [color=yellow]{Money.Count}[/color]";
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
		if (buttonResetGame.ButtonPressed) 
			GetTree().ChangeSceneToFile("res://Scenes/MainMenu.tscn");

		else if (buttonExit.ButtonPressed) 
			GetTree().Quit();
	}
}
