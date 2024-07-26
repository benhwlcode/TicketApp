namespace TicketAppTestingForm
{
	partial class TestWindow
	{
		/// <summary>
		///  Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		///  Clean up any resources being used.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing && (components != null))
			{
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Windows Form Designer generated code

		/// <summary>
		///  Required method for Designer support - do not modify
		///  the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			btnTestButton = new Button();
			SuspendLayout();
			// 
			// btnTestButton
			// 
			btnTestButton.Location = new Point(94, 46);
			btnTestButton.Name = "btnTestButton";
			btnTestButton.Size = new Size(180, 60);
			btnTestButton.TabIndex = 0;
			btnTestButton.Text = "Test Button";
			btnTestButton.UseVisualStyleBackColor = true;
			// 
			// TestWindow
			// 
			AutoScaleDimensions = new SizeF(15F, 37F);
			AutoScaleMode = AutoScaleMode.Font;
			BackColor = SystemColors.ControlDark;
			ClientSize = new Size(382, 153);
			Controls.Add(btnTestButton);
			Font = new Font("Segoe UI", 16.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
			Margin = new Padding(6, 6, 6, 6);
			Name = "TestWindow";
			Text = "Testing Window";
			ResumeLayout(false);
		}

		#endregion

		private Button btnTestButton;
	}
}
