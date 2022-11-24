using Godot;
using System;

public partial class app : Control{
	private TextEdit textEditor;
	private Label resultLabel;
	private RandomNumberGenerator random;
	
	public override void _Ready(){
		textEditor = GetNode("TextEdit") as TextEdit;
		resultLabel = GetNode("Label") as Label;
		random = new();
	}
	
	void _on_text_edit_text_changed(){
		string result = "";
		bool flip = false;
		foreach (char c in textEditor.Text) {
			if (String.IsNullOrWhiteSpace(c.ToString())) {
				result += " ";
				continue;
			}
			if(flip) {
				result += c.ToString().Capitalize();
				flip = !flip;
			}
			else {
				result += c.ToString().ToLower();
				flip = !flip;
			}
		}

		resultLabel.Text = result;
		DisplayServer.ClipboardSet(result);
	}
}
