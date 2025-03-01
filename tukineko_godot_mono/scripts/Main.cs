using Godot;
using System;
using System.Text;
using tukineko;

public partial class Main : Node2D
{
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		/*
  System.ArgumentException
  HResult=0x80070057
  Message='Shift-JIS' is not a supported encoding name. For information on defining a custom encoding, see the documentation for the Encoding.RegisterProvider method. Arg_ParamName_Name
  Source=System.Private.CoreLib
  StackTrace:
   System.Text.EncodingTable.InternalGetCodePageFromName(String name)
   System.Text.EncodingTable.GetCodePageFromName(String name)
   System.Text.Encoding.GetEncoding(String name)
   tukineko.NScripter.run() D:\work_godot\projects\tukineko_godot_mono\scripts\tukineko\parser\NScripter.cs
		*/
		Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);
		
		MainForm mainForm = new MainForm();
		AddChild(mainForm);
		mainForm.onStart();
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
	}
}
