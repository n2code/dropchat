namespace DropboxChatPrototype
{
	partial class MainForm
	{
		/// <summary>
		/// Designer variable used to keep track of non-visual components.
		/// </summary>
		private System.ComponentModel.IContainer components = null;
		
		/// <summary>
		/// Disposes resources used by the form.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing) {
				if (components != null) {
					components.Dispose();
				}
			}
			base.Dispose(disposing);
		}
		
		/// <summary>
		/// This method is required for Windows Forms designer support.
		/// Do not change the method contents inside the source code editor. The Forms designer might
		/// not be able to load this method if it was changed manually.
		/// </summary>
		private void InitializeComponent()
		{
			this.components = new System.ComponentModel.Container();
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
			this.sendbutton = new System.Windows.Forms.Button();
			this.nickname = new System.Windows.Forms.TextBox();
			this.input = new System.Windows.Forms.TextBox();
			this.timer1 = new System.Windows.Forms.Timer(this.components);
			this.chatview = new System.Windows.Forms.RichTextBox();
			this.prechatview = new System.Windows.Forms.RichTextBox();
			this.SuspendLayout();
			// 
			// sendbutton
			// 
			this.sendbutton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.sendbutton.Location = new System.Drawing.Point(469, 281);
			this.sendbutton.Name = "sendbutton";
			this.sendbutton.Size = new System.Drawing.Size(73, 22);
			this.sendbutton.TabIndex = 1;
			this.sendbutton.Text = "Login";
			this.sendbutton.UseVisualStyleBackColor = true;
			this.sendbutton.Click += new System.EventHandler(this.Button1Click);
			// 
			// nickname
			// 
			this.nickname.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.nickname.Location = new System.Drawing.Point(14, 282);
			this.nickname.Name = "nickname";
			this.nickname.Size = new System.Drawing.Size(74, 20);
			this.nickname.TabIndex = 2;
			this.nickname.Text = "Nickname";
			this.nickname.TextChanged += new System.EventHandler(this.NicknameTextChanged);
			this.nickname.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TextBox2KeyDown);
			// 
			// input
			// 
			this.input.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
									| System.Windows.Forms.AnchorStyles.Right)));
			this.input.Enabled = false;
			this.input.Location = new System.Drawing.Point(92, 282);
			this.input.Name = "input";
			this.input.Size = new System.Drawing.Size(371, 20);
			this.input.TabIndex = 3;
			this.input.TextChanged += new System.EventHandler(this.InputTextChanged);
			this.input.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TextBox3KeyDown);
			// 
			// timer1
			// 
			this.timer1.Enabled = true;
			this.timer1.Interval = 1000;
			this.timer1.Tick += new System.EventHandler(this.Timer1Tick);
			// 
			// chatview
			// 
			this.chatview.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
									| System.Windows.Forms.AnchorStyles.Left) 
									| System.Windows.Forms.AnchorStyles.Right)));
			this.chatview.Font = new System.Drawing.Font("Courier New", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.chatview.Location = new System.Drawing.Point(9, 9);
			this.chatview.Name = "chatview";
			this.chatview.ReadOnly = true;
			this.chatview.Size = new System.Drawing.Size(533, 263);
			this.chatview.TabIndex = 4;
			this.chatview.Text = "";
			this.chatview.LinkClicked += new System.Windows.Forms.LinkClickedEventHandler(this.ChatviewLinkClicked);
			this.chatview.Resize += new System.EventHandler(this.ChatviewResize);
			// 
			// prechatview
			// 
			this.prechatview.Location = new System.Drawing.Point(-1, 0);
			this.prechatview.Name = "prechatview";
			this.prechatview.Size = new System.Drawing.Size(125, 17);
			this.prechatview.TabIndex = 5;
			this.prechatview.Text = "";
			this.prechatview.Visible = false;
			// 
			// MainForm
			// 
			this.AcceptButton = this.sendbutton;
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor = System.Drawing.Color.Silver;
			this.ClientSize = new System.Drawing.Size(554, 309);
			this.Controls.Add(this.prechatview);
			this.Controls.Add(this.chatview);
			this.Controls.Add(this.input);
			this.Controls.Add(this.nickname);
			this.Controls.Add(this.sendbutton);
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.MinimumSize = new System.Drawing.Size(570, 347);
			this.Name = "MainForm";
			this.Text = "DropChat";
			this.Shown += new System.EventHandler(this.MainFormShown);
			this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.MainFormKeyDown);
			this.ResumeLayout(false);
			this.PerformLayout();
		}
		private System.Windows.Forms.RichTextBox prechatview;
		private System.Windows.Forms.RichTextBox chatview;
		private System.Windows.Forms.Timer timer1;
		private System.Windows.Forms.TextBox input;
		private System.Windows.Forms.TextBox nickname;
		private System.Windows.Forms.Button sendbutton;
	}
}
