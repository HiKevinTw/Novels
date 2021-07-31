
namespace Novels.Machine.Forms.Dialog
{
	partial class MessageForm
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
			this.tlpMain = new System.Windows.Forms.TableLayoutPanel();
			this.label1 = new System.Windows.Forms.Label();
			this.lblTime = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.lblMachine = new System.Windows.Forms.Label();
			this.label3 = new System.Windows.Forms.Label();
			this.rtbMessage = new System.Windows.Forms.RichTextBox();
			this.tlpMain.SuspendLayout();
			this.SuspendLayout();
			// 
			// tlpMain
			// 
			this.tlpMain.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.Outset;
			this.tlpMain.ColumnCount = 2;
			this.tlpMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 60F));
			this.tlpMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
			this.tlpMain.Controls.Add(this.label1, 0, 0);
			this.tlpMain.Controls.Add(this.lblTime, 1, 0);
			this.tlpMain.Controls.Add(this.label2, 0, 1);
			this.tlpMain.Controls.Add(this.lblMachine, 1, 1);
			this.tlpMain.Controls.Add(this.label3, 0, 2);
			this.tlpMain.Controls.Add(this.rtbMessage, 1, 2);
			this.tlpMain.Dock = System.Windows.Forms.DockStyle.Fill;
			this.tlpMain.Location = new System.Drawing.Point(0, 0);
			this.tlpMain.Name = "tlpMain";
			this.tlpMain.RowCount = 3;
			this.tlpMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
			this.tlpMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
			this.tlpMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
			this.tlpMain.Size = new System.Drawing.Size(820, 602);
			this.tlpMain.TabIndex = 1;
			// 
			// label1
			// 
			this.label1.Anchor = System.Windows.Forms.AnchorStyles.Right;
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(10, 15);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(49, 14);
			this.label1.TabIndex = 0;
			this.label1.Text = "時間：";
			// 
			// lblTime
			// 
			this.lblTime.Anchor = System.Windows.Forms.AnchorStyles.Left;
			this.lblTime.AutoSize = true;
			this.lblTime.Location = new System.Drawing.Point(67, 15);
			this.lblTime.Name = "lblTime";
			this.lblTime.Size = new System.Drawing.Size(41, 14);
			this.lblTime.TabIndex = 1;
			this.lblTime.Text = "label2";
			// 
			// label2
			// 
			this.label2.Anchor = System.Windows.Forms.AnchorStyles.Right;
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(10, 57);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(49, 14);
			this.label2.TabIndex = 2;
			this.label2.Text = "機器：";
			// 
			// lblMachine
			// 
			this.lblMachine.Anchor = System.Windows.Forms.AnchorStyles.Left;
			this.lblMachine.AutoSize = true;
			this.lblMachine.Location = new System.Drawing.Point(67, 57);
			this.lblMachine.Name = "lblMachine";
			this.lblMachine.Size = new System.Drawing.Size(41, 14);
			this.lblMachine.TabIndex = 3;
			this.lblMachine.Text = "label4";
			// 
			// label3
			// 
			this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.label3.AutoSize = true;
			this.label3.Location = new System.Drawing.Point(10, 89);
			this.label3.Margin = new System.Windows.Forms.Padding(3, 3, 3, 0);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(49, 14);
			this.label3.TabIndex = 4;
			this.label3.Text = "訊息：";
			// 
			// rtbMessage
			// 
			this.rtbMessage.Dock = System.Windows.Forms.DockStyle.Fill;
			this.rtbMessage.Font = new System.Drawing.Font("微軟正黑體", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
			this.rtbMessage.Location = new System.Drawing.Point(67, 89);
			this.rtbMessage.Name = "rtbMessage";
			this.rtbMessage.ReadOnly = true;
			this.rtbMessage.Size = new System.Drawing.Size(748, 508);
			this.rtbMessage.TabIndex = 5;
			this.rtbMessage.Text = "";
			// 
			// MessageForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(820, 602);
			this.Controls.Add(this.tlpMain);
			this.Font = new System.Drawing.Font("新細明體", 10F);
			this.Name = "MessageForm";
			this.Text = "訊息視窗";
			this.tlpMain.ResumeLayout(false);
			this.tlpMain.PerformLayout();
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.TableLayoutPanel tlpMain;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label lblTime;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label lblMachine;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.RichTextBox rtbMessage;
	}
}