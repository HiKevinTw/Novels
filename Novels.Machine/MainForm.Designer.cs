
namespace Novels.Machine
{
	partial class MainForm
	{
		/// <summary>
		/// 設計工具所需的變數。
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// 清除任何使用中的資源。
		/// </summary>
		/// <param name="disposing">如果應該處置受控資源則為 true，否則為 false。</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing && (components != null))
			{
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Windows Form 設計工具產生的程式碼

		/// <summary>
		/// 此為設計工具支援所需的方法 - 請勿使用程式碼編輯器修改
		/// 這個方法的內容。
		/// </summary>
		private void InitializeComponent()
		{
			this.components = new System.ComponentModel.Container();
			System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
			this.HeartbeatTimer = new System.Windows.Forms.Timer(this.components);
			this.Clock = new System.Windows.Forms.Label();
			this.ExitButton = new System.Windows.Forms.Button();
			this.StopButton = new System.Windows.Forms.Button();
			this.StartButton = new System.Windows.Forms.Button();
			this.menuStrip1 = new System.Windows.Forms.MenuStrip();
			this.設置ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.網站ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.書籍ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.章節ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.AutoScrollCheckBox = new System.Windows.Forms.CheckBox();
			this.checkedListBox1 = new System.Windows.Forms.CheckedListBox();
			this.ErrorGridView = new System.Windows.Forms.DataGridView();
			this.HandleColumn = new System.Windows.Forms.DataGridViewButtonColumn();
			this.ErrorTimeColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.ErrorMessageColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.MessageGridView = new System.Windows.Forms.DataGridView();
			this.TimeColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.StatusColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.MessageColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.tlpMain = new System.Windows.Forms.TableLayoutPanel();
			this.panel1 = new System.Windows.Forms.Panel();
			this.splitContainer1 = new System.Windows.Forms.SplitContainer();
			this.menuStrip1.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.ErrorGridView)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.MessageGridView)).BeginInit();
			this.tlpMain.SuspendLayout();
			this.panel1.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
			this.splitContainer1.Panel1.SuspendLayout();
			this.splitContainer1.Panel2.SuspendLayout();
			this.splitContainer1.SuspendLayout();
			this.SuspendLayout();
			// 
			// HeartbeatTimer
			// 
			this.HeartbeatTimer.Enabled = true;
			this.HeartbeatTimer.Interval = 1000;
			this.HeartbeatTimer.Tick += new System.EventHandler(this.HeartbeatTimer_Tick);
			// 
			// Clock
			// 
			this.Clock.AutoSize = true;
			this.Clock.Cursor = System.Windows.Forms.Cursors.Default;
			this.Clock.Dock = System.Windows.Forms.DockStyle.Fill;
			this.Clock.Font = new System.Drawing.Font("微軟正黑體", 26.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
			this.Clock.Location = new System.Drawing.Point(3, 0);
			this.Clock.Name = "Clock";
			this.Clock.Size = new System.Drawing.Size(480, 70);
			this.Clock.TabIndex = 9;
			this.Clock.Text = "yyyy-MM-dd HH:mm:ss";
			this.Clock.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// ExitButton
			// 
			this.ExitButton.Location = new System.Drawing.Point(629, 3);
			this.ExitButton.Name = "ExitButton";
			this.ExitButton.Size = new System.Drawing.Size(64, 64);
			this.ExitButton.TabIndex = 8;
			this.ExitButton.Text = "離開";
			this.ExitButton.UseVisualStyleBackColor = true;
			this.ExitButton.Click += new System.EventHandler(this.ExitButton_Click);
			// 
			// StopButton
			// 
			this.StopButton.Location = new System.Drawing.Point(559, 3);
			this.StopButton.Name = "StopButton";
			this.StopButton.Size = new System.Drawing.Size(64, 64);
			this.StopButton.TabIndex = 7;
			this.StopButton.Text = "停止";
			this.StopButton.UseVisualStyleBackColor = true;
			this.StopButton.Click += new System.EventHandler(this.StopButton_Click);
			// 
			// StartButton
			// 
			this.StartButton.Location = new System.Drawing.Point(489, 3);
			this.StartButton.Name = "StartButton";
			this.StartButton.Size = new System.Drawing.Size(64, 64);
			this.StartButton.TabIndex = 6;
			this.StartButton.Text = "開始";
			this.StartButton.UseVisualStyleBackColor = true;
			this.StartButton.Click += new System.EventHandler(this.StartButton_Click);
			// 
			// menuStrip1
			// 
			this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.設置ToolStripMenuItem});
			this.menuStrip1.Location = new System.Drawing.Point(0, 0);
			this.menuStrip1.Name = "menuStrip1";
			this.menuStrip1.Size = new System.Drawing.Size(696, 24);
			this.menuStrip1.TabIndex = 10;
			this.menuStrip1.Text = "menuStrip1";
			// 
			// 設置ToolStripMenuItem
			// 
			this.設置ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.網站ToolStripMenuItem,
            this.書籍ToolStripMenuItem,
            this.章節ToolStripMenuItem});
			this.設置ToolStripMenuItem.Name = "設置ToolStripMenuItem";
			this.設置ToolStripMenuItem.Size = new System.Drawing.Size(43, 20);
			this.設置ToolStripMenuItem.Text = "設置";
			// 
			// 網站ToolStripMenuItem
			// 
			this.網站ToolStripMenuItem.Name = "網站ToolStripMenuItem";
			this.網站ToolStripMenuItem.Size = new System.Drawing.Size(98, 22);
			this.網站ToolStripMenuItem.Text = "網站";
			this.網站ToolStripMenuItem.Click += new System.EventHandler(this.網站ToolStripMenuItem_Click);
			// 
			// 書籍ToolStripMenuItem
			// 
			this.書籍ToolStripMenuItem.Name = "書籍ToolStripMenuItem";
			this.書籍ToolStripMenuItem.Size = new System.Drawing.Size(98, 22);
			this.書籍ToolStripMenuItem.Text = "書籍";
			this.書籍ToolStripMenuItem.Click += new System.EventHandler(this.書籍ToolStripMenuItem_Click);
			// 
			// 章節ToolStripMenuItem
			// 
			this.章節ToolStripMenuItem.Name = "章節ToolStripMenuItem";
			this.章節ToolStripMenuItem.Size = new System.Drawing.Size(98, 22);
			this.章節ToolStripMenuItem.Text = "章節";
			this.章節ToolStripMenuItem.Click += new System.EventHandler(this.章節ToolStripMenuItem_Click);
			// 
			// AutoScrollCheckBox
			// 
			this.AutoScrollCheckBox.Anchor = System.Windows.Forms.AnchorStyles.Left;
			this.AutoScrollCheckBox.AutoSize = true;
			this.AutoScrollCheckBox.Checked = true;
			this.AutoScrollCheckBox.CheckState = System.Windows.Forms.CheckState.Checked;
			this.AutoScrollCheckBox.Location = new System.Drawing.Point(6, 174);
			this.AutoScrollCheckBox.Margin = new System.Windows.Forms.Padding(6, 3, 3, 3);
			this.AutoScrollCheckBox.Name = "AutoScrollCheckBox";
			this.AutoScrollCheckBox.Size = new System.Drawing.Size(125, 22);
			this.AutoScrollCheckBox.TabIndex = 12;
			this.AutoScrollCheckBox.Text = "自動捲動訊息列";
			this.AutoScrollCheckBox.UseVisualStyleBackColor = true;
			// 
			// checkedListBox1
			// 
			this.checkedListBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.checkedListBox1.FormattingEnabled = true;
			this.checkedListBox1.Location = new System.Drawing.Point(6, 3);
			this.checkedListBox1.Name = "checkedListBox1";
			this.checkedListBox1.Size = new System.Drawing.Size(687, 84);
			this.checkedListBox1.TabIndex = 14;
			// 
			// ErrorGridView
			// 
			this.ErrorGridView.AllowUserToAddRows = false;
			this.ErrorGridView.AllowUserToDeleteRows = false;
			this.ErrorGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.ErrorGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.HandleColumn,
            this.ErrorTimeColumn,
            this.ErrorMessageColumn});
			this.ErrorGridView.Dock = System.Windows.Forms.DockStyle.Fill;
			this.ErrorGridView.Location = new System.Drawing.Point(0, 0);
			this.ErrorGridView.MultiSelect = false;
			this.ErrorGridView.Name = "ErrorGridView";
			this.ErrorGridView.RowHeadersWidth = 10;
			dataGridViewCellStyle2.BackColor = System.Drawing.Color.Red;
			this.ErrorGridView.RowsDefaultCellStyle = dataGridViewCellStyle2;
			this.ErrorGridView.RowTemplate.Height = 24;
			this.ErrorGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
			this.ErrorGridView.Size = new System.Drawing.Size(690, 96);
			this.ErrorGridView.TabIndex = 15;
			this.ErrorGridView.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.ErrorGridView_CellContentClick);
			// 
			// HandleColumn
			// 
			this.HandleColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
			this.HandleColumn.Frozen = true;
			this.HandleColumn.HeaderText = "刪除";
			this.HandleColumn.Name = "HandleColumn";
			this.HandleColumn.Resizable = System.Windows.Forms.DataGridViewTriState.True;
			this.HandleColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
			this.HandleColumn.Width = 61;
			// 
			// ErrorTimeColumn
			// 
			this.ErrorTimeColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
			this.ErrorTimeColumn.Frozen = true;
			this.ErrorTimeColumn.HeaderText = "時間";
			this.ErrorTimeColumn.Name = "ErrorTimeColumn";
			this.ErrorTimeColumn.Width = 61;
			// 
			// ErrorMessageColumn
			// 
			this.ErrorMessageColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
			this.ErrorMessageColumn.HeaderText = "訊息";
			this.ErrorMessageColumn.Name = "ErrorMessageColumn";
			// 
			// MessageGridView
			// 
			this.MessageGridView.AllowUserToAddRows = false;
			this.MessageGridView.AllowUserToDeleteRows = false;
			this.MessageGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.MessageGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.TimeColumn,
            this.StatusColumn,
            this.MessageColumn});
			this.MessageGridView.Dock = System.Windows.Forms.DockStyle.Fill;
			this.MessageGridView.Location = new System.Drawing.Point(0, 0);
			this.MessageGridView.MultiSelect = false;
			this.MessageGridView.Name = "MessageGridView";
			this.MessageGridView.ReadOnly = true;
			this.MessageGridView.RowHeadersWidth = 10;
			this.MessageGridView.RowTemplate.Height = 24;
			this.MessageGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
			this.MessageGridView.Size = new System.Drawing.Size(690, 108);
			this.MessageGridView.TabIndex = 16;
			this.MessageGridView.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.MessageGridView_CellContentClick);
			this.MessageGridView.RowsAdded += new System.Windows.Forms.DataGridViewRowsAddedEventHandler(this.MessageGridView_RowsAdded);
			// 
			// TimeColumn
			// 
			this.TimeColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
			this.TimeColumn.Frozen = true;
			this.TimeColumn.HeaderText = "時間";
			this.TimeColumn.Name = "TimeColumn";
			this.TimeColumn.ReadOnly = true;
			this.TimeColumn.Width = 61;
			// 
			// StatusColumn
			// 
			this.StatusColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
			this.StatusColumn.Frozen = true;
			this.StatusColumn.HeaderText = "狀態";
			this.StatusColumn.Name = "StatusColumn";
			this.StatusColumn.ReadOnly = true;
			this.StatusColumn.Width = 61;
			// 
			// MessageColumn
			// 
			this.MessageColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
			this.MessageColumn.HeaderText = "訊息";
			this.MessageColumn.Name = "MessageColumn";
			this.MessageColumn.ReadOnly = true;
			// 
			// tlpMain
			// 
			this.tlpMain.ColumnCount = 4;
			this.tlpMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
			this.tlpMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 70F));
			this.tlpMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 70F));
			this.tlpMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 70F));
			this.tlpMain.Controls.Add(this.AutoScrollCheckBox, 0, 2);
			this.tlpMain.Controls.Add(this.StartButton, 1, 0);
			this.tlpMain.Controls.Add(this.StopButton, 2, 0);
			this.tlpMain.Controls.Add(this.ExitButton, 3, 0);
			this.tlpMain.Controls.Add(this.panel1, 0, 1);
			this.tlpMain.Controls.Add(this.splitContainer1, 0, 3);
			this.tlpMain.Controls.Add(this.Clock, 0, 0);
			this.tlpMain.Dock = System.Windows.Forms.DockStyle.Fill;
			this.tlpMain.Location = new System.Drawing.Point(0, 24);
			this.tlpMain.Name = "tlpMain";
			this.tlpMain.RowCount = 4;
			this.tlpMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 70F));
			this.tlpMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 100F));
			this.tlpMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
			this.tlpMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
			this.tlpMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
			this.tlpMain.Size = new System.Drawing.Size(696, 414);
			this.tlpMain.TabIndex = 19;
			// 
			// panel1
			// 
			this.tlpMain.SetColumnSpan(this.panel1, 4);
			this.panel1.Controls.Add(this.checkedListBox1);
			this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.panel1.Location = new System.Drawing.Point(0, 70);
			this.panel1.Margin = new System.Windows.Forms.Padding(0);
			this.panel1.Name = "panel1";
			this.panel1.Size = new System.Drawing.Size(696, 100);
			this.panel1.TabIndex = 10;
			// 
			// splitContainer1
			// 
			this.tlpMain.SetColumnSpan(this.splitContainer1, 4);
			this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.splitContainer1.Location = new System.Drawing.Point(3, 203);
			this.splitContainer1.Name = "splitContainer1";
			this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
			// 
			// splitContainer1.Panel1
			// 
			this.splitContainer1.Panel1.Controls.Add(this.ErrorGridView);
			// 
			// splitContainer1.Panel2
			// 
			this.splitContainer1.Panel2.Controls.Add(this.MessageGridView);
			this.splitContainer1.Size = new System.Drawing.Size(690, 208);
			this.splitContainer1.SplitterDistance = 96;
			this.splitContainer1.TabIndex = 11;
			// 
			// MainForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 17F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(696, 438);
			this.Controls.Add(this.tlpMain);
			this.Controls.Add(this.menuStrip1);
			this.Font = new System.Drawing.Font("微軟正黑體", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
			this.MainMenuStrip = this.menuStrip1;
			this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
			this.Name = "MainForm";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "MainForm";
			this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.MainForm_FormClosed);
			this.LocationChanged += new System.EventHandler(this.MainForm_LocationChanged);
			this.Resize += new System.EventHandler(this.MainForm_Resize);
			this.menuStrip1.ResumeLayout(false);
			this.menuStrip1.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.ErrorGridView)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.MessageGridView)).EndInit();
			this.tlpMain.ResumeLayout(false);
			this.tlpMain.PerformLayout();
			this.panel1.ResumeLayout(false);
			this.splitContainer1.Panel1.ResumeLayout(false);
			this.splitContainer1.Panel2.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
			this.splitContainer1.ResumeLayout(false);
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion
		private System.Windows.Forms.Timer HeartbeatTimer;
		private System.Windows.Forms.Label Clock;
		private System.Windows.Forms.Button ExitButton;
		private System.Windows.Forms.Button StopButton;
		private System.Windows.Forms.Button StartButton;
		private System.Windows.Forms.MenuStrip menuStrip1;
		private System.Windows.Forms.ToolStripMenuItem 設置ToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem 網站ToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem 書籍ToolStripMenuItem;
		private System.Windows.Forms.CheckBox AutoScrollCheckBox;
		private System.Windows.Forms.CheckedListBox checkedListBox1;
		private System.Windows.Forms.DataGridView ErrorGridView;
		private System.Windows.Forms.DataGridViewButtonColumn HandleColumn;
		private System.Windows.Forms.DataGridViewTextBoxColumn ErrorTimeColumn;
		private System.Windows.Forms.DataGridViewTextBoxColumn ErrorMessageColumn;
		private System.Windows.Forms.DataGridView MessageGridView;
		private System.Windows.Forms.DataGridViewTextBoxColumn TimeColumn;
		private System.Windows.Forms.DataGridViewTextBoxColumn StatusColumn;
		private System.Windows.Forms.DataGridViewTextBoxColumn MessageColumn;
		private System.Windows.Forms.TableLayoutPanel tlpMain;
		private System.Windows.Forms.Panel panel1;
		private System.Windows.Forms.SplitContainer splitContainer1;
		private System.Windows.Forms.ToolStripMenuItem 章節ToolStripMenuItem;
	}
}

