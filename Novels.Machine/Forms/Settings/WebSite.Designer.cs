
namespace Novels.Machine.Forms.Settings
{
	partial class WebSite
	{
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// Clean up any resources being used.
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
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.listBox1 = new System.Windows.Forms.ListBox();
			this.ConfirmButton = new System.Windows.Forms.Button();
			this.AddButton = new System.Windows.Forms.Button();
			this.ModifyButton = new System.Windows.Forms.Button();
			this.UpButton = new System.Windows.Forms.Button();
			this.DownButton = new System.Windows.Forms.Button();
			this.DelButton = new System.Windows.Forms.Button();
			this.SuspendLayout();
			// 
			// listBox1
			// 
			this.listBox1.FormattingEnabled = true;
			this.listBox1.ItemHeight = 17;
			this.listBox1.Location = new System.Drawing.Point(12, 12);
			this.listBox1.Name = "listBox1";
			this.listBox1.Size = new System.Drawing.Size(164, 259);
			this.listBox1.TabIndex = 0;
			// 
			// ConfirmButton
			// 
			this.ConfirmButton.Location = new System.Drawing.Point(101, 288);
			this.ConfirmButton.Name = "ConfirmButton";
			this.ConfirmButton.Size = new System.Drawing.Size(75, 23);
			this.ConfirmButton.TabIndex = 1;
			this.ConfirmButton.Text = "確定";
			this.ConfirmButton.UseVisualStyleBackColor = true;
			// 
			// AddButton
			// 
			this.AddButton.Location = new System.Drawing.Point(198, 22);
			this.AddButton.Name = "AddButton";
			this.AddButton.Size = new System.Drawing.Size(75, 23);
			this.AddButton.TabIndex = 2;
			this.AddButton.Text = "新增";
			this.AddButton.UseVisualStyleBackColor = true;
			this.AddButton.Click += new System.EventHandler(this.AddButton_Click);
			// 
			// ModifyButton
			// 
			this.ModifyButton.Location = new System.Drawing.Point(198, 75);
			this.ModifyButton.Name = "ModifyButton";
			this.ModifyButton.Size = new System.Drawing.Size(75, 23);
			this.ModifyButton.TabIndex = 3;
			this.ModifyButton.Text = "修改";
			this.ModifyButton.UseVisualStyleBackColor = true;
			this.ModifyButton.Click += new System.EventHandler(this.ModifyButton_Click);
			// 
			// UpButton
			// 
			this.UpButton.Location = new System.Drawing.Point(198, 128);
			this.UpButton.Name = "UpButton";
			this.UpButton.Size = new System.Drawing.Size(75, 23);
			this.UpButton.TabIndex = 4;
			this.UpButton.Text = "上移";
			this.UpButton.UseVisualStyleBackColor = true;
			this.UpButton.Click += new System.EventHandler(this.UpButton_Click);
			// 
			// DownButton
			// 
			this.DownButton.Location = new System.Drawing.Point(198, 181);
			this.DownButton.Name = "DownButton";
			this.DownButton.Size = new System.Drawing.Size(75, 23);
			this.DownButton.TabIndex = 5;
			this.DownButton.Text = "下移";
			this.DownButton.UseVisualStyleBackColor = true;
			this.DownButton.Click += new System.EventHandler(this.DownButton_Click);
			// 
			// DelButton
			// 
			this.DelButton.Location = new System.Drawing.Point(198, 234);
			this.DelButton.Name = "DelButton";
			this.DelButton.Size = new System.Drawing.Size(75, 23);
			this.DelButton.TabIndex = 6;
			this.DelButton.Text = "刪除";
			this.DelButton.UseVisualStyleBackColor = true;
			this.DelButton.Click += new System.EventHandler(this.DelButton_Click);
			// 
			// WebSite
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 17F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(292, 323);
			this.Controls.Add(this.DelButton);
			this.Controls.Add(this.DownButton);
			this.Controls.Add(this.UpButton);
			this.Controls.Add(this.ModifyButton);
			this.Controls.Add(this.AddButton);
			this.Controls.Add(this.ConfirmButton);
			this.Controls.Add(this.listBox1);
			this.Font = new System.Drawing.Font("微軟正黑體", 10F);
			this.Margin = new System.Windows.Forms.Padding(4);
			this.Name = "WebSite";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "Website";
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.ListBox listBox1;
		private System.Windows.Forms.Button ConfirmButton;
		private System.Windows.Forms.Button AddButton;
		private System.Windows.Forms.Button ModifyButton;
		private System.Windows.Forms.Button UpButton;
		private System.Windows.Forms.Button DownButton;
		private System.Windows.Forms.Button DelButton;
	}
}