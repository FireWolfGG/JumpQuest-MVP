using Godot;
using System;

public partial class MusicManager : Node
{
	public static MusicManager Instance;
	private AudioStreamPlayer audio;
	private AudioStream stream;
	public override void _Ready()
	{
		Instance = this;
		audio = GetNodeOrNull<AudioStreamPlayer>("AudioStreamPlayer");
		audio.ProcessMode = ProcessModeEnum.Always;
		audio.Finished += () => audio.Play();
	}

	public void MusicPlay(AudioStream stream = null)
	{
		if (stream != null)
		{
			audio.Stream = stream;
			audio.Play();
		}
	}
}