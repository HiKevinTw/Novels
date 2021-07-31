
using Newtonsoft.Json;
using NLog;
using Novels.Machine.App_Code;
using Novels.Machine.App_Start;
using Novels.Machine.Forms.Settings;
using Novels.Machine.Jobs;
using Novels.Machine.ViewModels;

using Novels.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using Novels.Log;
using Novels.Machine.Forms.Dialog;

namespace Novels.Machine
{
	public partial class MainForm : Form
	{
		// Crawler Novels //
		#region 屬性、欄位、物件

		private const string ApplicationName = "NovelsMachine";
		private static readonly Color[] Colors =
			{
				Color.FromArgb(255, 255, 255),  // 白
                Color.FromArgb(255, 0, 255),    // 桃紅
                Color.FromArgb(255, 128, 0),    // 橙
                Color.FromArgb(0, 255, 0),      // 綠
                Color.FromArgb(0, 255, 128),    // 淺綠
                Color.FromArgb(0, 0, 255),      // 藍
                Color.FromArgb(0, 128, 255),    // 淺藍
                Color.FromArgb(0, 128, 128),    // 藍綠
                Color.FromArgb(64, 0, 128),     // 紫
                Color.FromArgb(128, 128, 192)   // 淺紫
            };
		private static readonly Logger Log = LogManager.GetLogger("MainForm");
		private Task waitJobStopped;

		List<Novel> Novels { get { return DB.Novel.Query(new NovelQueryCondition() { IsFinish = 0 }).QueryResult.ToList(); } }		
		List<Job> Jobs
		{
			get
			{
				List<Job> result = new List<Job>();

				var CheckedNovels =
						checkedListBox1.CheckedItems
						.Cast<KeyValuePair<string, object>>()
						.Select(x => (Novel)x.Value)
						.ToList();

				result.Add(new ConvertChaptersJob(CheckedNovels));

				return result;
			}
		}
		WindowAppearance WindowAppearance
		{
			get
			{
				return
					new WindowAppearance()
					{
						X = this.Location.X < 0 ? 0 : this.Location.X,
						Y = this.Location.Y < 0 ? 0 : this.Location.Y,
						Width = this.Width,
						Height = this.Height
					};
			}

			set
			{
				if (value == null)
				{
					value =
						new WindowAppearance()
						{
							X = 0,
							Y = 0,
							Width = 0,
							Height = 0
						};
				}

				this.Location = new Point(value.X, value.Y);
				this.Width = value.Width;
				this.Height = value.Height;
			}
		}
		DataGridViewAppearance MessageAppearance
		{
			get
			{
				return
					new DataGridViewAppearance()
					{
						MaxRows = 1000,
						ColumnAppearances = MessageGridView.Columns.Cast<DataGridViewColumn>().Select(c => new DataGridColumnAppearance(c.Name, c.Width)).ToList()
					};
			}

			set
			{
				if (value == null)
				{
					value =
						new DataGridViewAppearance()
						{
							MaxRows = 1000,
							ColumnAppearances =
								new List<DataGridColumnAppearance>()
								{
									new DataGridColumnAppearance("TimeColumn", 100),
									new DataGridColumnAppearance("StatusColumn", 60),
									new DataGridColumnAppearance("MessageColumn", 500)
								}
						};
				}

				value.ColumnAppearances.ForEach((c) =>
				{
					MessageGridView.Columns[c.Name].Width = c.Width;
				});
			}
		}
		DataGridViewAppearance ErrorAppearance
		{
			get
			{
				return
					new DataGridViewAppearance()
					{
						MaxRows = 500,
						ColumnAppearances = ErrorGridView.Columns.Cast<DataGridViewColumn>().Select(c => new DataGridColumnAppearance(c.Name, c.Width)).ToList()
					};
			}

			set
			{
				if (value == null)
				{
					value =
						new DataGridViewAppearance()
						{
							MaxRows = 1000,
							ColumnAppearances =
								new List<DataGridColumnAppearance>()
								{
									new DataGridColumnAppearance("HandleColumn", 25),
									new DataGridColumnAppearance("ErrorTimeColumn", 100),
									new DataGridColumnAppearance("ErrorMessageColumn", 550)
								}
						};
				}

				value.ColumnAppearances.ForEach((c) =>
				{
					ErrorGridView.Columns[c.Name].Width = c.Width;
				});
			}
		}
		enum ThenExecute
		{
			Stop,
			Exit
		}

		#endregion

		public MainForm()
		{
			InitializeComponent();

			#region 直接設定 Nlog 不讀 nlog.config 
			//MethodCallTarget target = new MethodCallTarget();
			//target.ClassName = typeof(ShowLogAppender).AssemblyQualifiedName;
			//target.MethodName = "LogMethod";
			//target.Parameters.Add(new MethodCallParameter("${level}"));
			//target.Parameters.Add(new MethodCallParameter("${message}"));
			//SimpleConfigurator.ConfigureForTargetLogging(target, LogLevel.Debug);
			#endregion

			ShowLogAppender.ShowLogHandler = this.ShowWorkingMessage;

			LoadJob();

			// 視窗標題
			this.Text = string.Format("{0} v{1}", ApplicationName, Application.ProductVersion);

			// 時間 bar 初始化
			Clock.Text = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
			Clock.BackColor = Colors[new Random(Guid.NewGuid().GetHashCode()).Next(Colors.Length)];

			// 訊息視窗不自動產生欄位
			this.MessageGridView.AutoGenerateColumns = false;
			this.ErrorGridView.AutoGenerateColumns = false;

			this.MessageGridView.RowsAdded += this.MessageGridView_RowsAdded;

			// 載入畫面設定
			this.WindowAppearance = WindowAppearance.Parse(Properties.Settings.Default.WindowAppearance);
			this.MessageAppearance = DataGridViewAppearance.Parse(Properties.Settings.Default.MessageAppearance);
			this.ErrorAppearance = DataGridViewAppearance.Parse(Properties.Settings.Default.ErrorAppearance);

			// 註冊畫面變動相關事件
			this.LocationChanged += this.MainForm_LocationChanged;
			this.Resize += this.MainForm_Resize;


			//if (Novels != null)
			//{
			//	foreach (var item in Novels[0].Chapters)
			//	{
			//		item.UpdateTime = DateTime.Now;

			//		DB.Chapter.Modify(item);
			//	}

			//	Novels[0].UpdateTime = DateTime.Now;

			//	DB.Novel.Modify(Novels[0]);
			//}
			
		}

		#region 訊息處理

		// 顯示訊息在訊息清單上
		private void ShowWorkingMessage(string logLevel, string logMessage)
		{
			this.InvokeIfNecessary(() =>
			{
				this.MessageGridView.Rows.Add(DateTime.Now, logLevel, logMessage);

				if (this.AutoScrollCheckBox.Checked)
				{
					// 若 MaxRows 設定大於 0，則從第1筆訊息逐筆刪除超過設定的最大訊息列數。
					while (this.MessageGridView.Rows.Count > this.MessageAppearance.MaxRows)
					{
						this.MessageGridView.Rows.RemoveAt(0);
					}

					// 移至最後1筆記錄
					this.MessageGridView.FirstDisplayedScrollingRowIndex = this.MessageGridView.Rows.Count - 1;
				}

				if (logLevel == "Error")
				{
					this.ErrorGridView.Rows.Add("刪除", DateTime.Now, logMessage);
				}
			});
		}

		#endregion

		#region 工作狀態處理

		public void LoadJob()
		{
			checkedListBox1.DataSource = new BindingSource(Novels.ToDictionary("Name"), null);
			checkedListBox1.DisplayMember = "Key";
			checkedListBox1.ValueMember = "Value";
		}

		private void StartJob()
		{
			this.SwitchStartingState();

			// 作業開始
			this.Jobs.ForEach((job) =>
			{
				job.Start();
			});

			Log.Info("作業開始");
		}

		private void StopJob()
		{
			this.Jobs.ForEach((job) =>
			{
				if (job.IsExecuting)
				{
					job.Stop();
				}
			});
		}

		private void JobStopping(ThenExecute thenExecute)
		{
			if (this.waitJobStopped == null || this.waitJobStopped.Status != TaskStatus.Running)
			{
				this.waitJobStopped = new Task(() =>
				{
					while (Jobs.Any((job) => job.IsExecuting))
					{
						Thread.Sleep(1000);
					}
				});

				this.waitJobStopped.ContinueWith((wAitjobStopped) =>
				{
					this.InvokeIfNecessary(() =>
					{
						switch (thenExecute)
						{
							case ThenExecute.Stop:
								{
									Log.Info("作業停止");
									this.SwitchStoppedState();
								}

								break;
							case ThenExecute.Exit:
								{
									Application.Exit();
								}

								break;
						}
					});
				});

				this.waitJobStopped.Start();
			}
		}

		private void ExitApplication()
		{
			this.InvokeIfNecessary(() =>
			{
				Log.Info("工作執行完畢");
				MessageBox.Show("工作執行完畢，即將關閉視窗！", "訊息", MessageBoxButtons.OK, MessageBoxIcon.Information);
				Application.Exit();
			});
		}

		#endregion

		#region 按鈕狀態處理

		private void SwitchStartingState()
		{
			checkedListBox1.Enabled = false;
			StartButton.Enabled = false;
			StopButton.Enabled = true;
		}

		private void SwitchStoppedState()
		{
			checkedListBox1.Enabled = true;
			StartButton.Enabled = true;
			StopButton.Enabled = false;
		}

		#endregion

		#region EventHandler

		/// <summary>
		/// 開始按鈕
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void StartButton_Click(object sender, EventArgs e)
		{
			Log.Info("使用者點擊開始");

			if (this.Jobs.Count > 0)
			{
				this.StartJob();
			}
			else
			{
				MessageBox.Show("請至少選擇一個作業！", "警告", MessageBoxButtons.OK, MessageBoxIcon.Warning);
			}
		}

		/// <summary>
		/// 停止按鈕
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void StopButton_Click(object sender, EventArgs e)
		{
			Log.Info("使用者點擊停止");

			this.StopJob();

			if (this.Jobs.All((job) => !job.IsExecuting))
			{
				Log.Info("作業停止");
				this.SwitchStoppedState();
			}
			else
			{
				this.JobStopping(ThenExecute.Stop);

				MessageBox.Show("部分作業尚未結束，待結束後會立即停止作業 !!", "警告", MessageBoxButtons.OK, MessageBoxIcon.Warning);
			}
		}

		/// <summary>
		/// 離開按鈕
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void ExitButton_Click(object sender, EventArgs e)
		{
			Log.Info("使用者點擊離開");

			this.StopJob();

			if (this.Jobs.Count == 0 || this.Jobs.All((job) => !job.IsExecuting))
			{
				Application.Exit();
			}
			else
			{
				this.JobStopping(ThenExecute.Exit);

				MessageBox.Show("部分作業尚未結束，待結束後會立即關閉程式 !!", "警告", MessageBoxButtons.OK, MessageBoxIcon.Warning);
			}
		}

		/// <summary>
		///		程式心跳 Timer Event
		/// </summary>
		/// <remarks>
		///		Enabled = True
		///		Interval = 1000
		/// </remarks>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void HeartbeatTimer_Tick(object sender, EventArgs e)
		{
			if (DateTime.Now.Millisecond < 100)
			{
				return;
			}

			Clock.Text = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
			Clock.BackColor = Colors[(new Random(Guid.NewGuid().GetHashCode())).Next(Colors.Length)];

			Application.DoEvents();
		}

		/// <summary>
		/// 訊息狀態決定訊息列顯示的顏色
		/// </summary>
		private void MessageGridView_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
		{
			switch ((string)((DataGridView)sender).Rows[e.RowIndex].Cells["StatusColumn"].Value)
			{
				case "WARN":
					((DataGridView)sender).Rows[e.RowIndex].DefaultCellStyle.BackColor = Color.Yellow;
					break;
				case "ERROR":
					((DataGridView)sender).Rows[e.RowIndex].DefaultCellStyle.BackColor = Color.Red;
					break;
			}
		}

		/// <summary>
		/// 使用者點擊訊息
		/// </summary>
		private void MessageGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
		{
			// 若點擊訊息，則才處理後續工作。
			if (e.ColumnIndex == 2)
			{
				using (var messageForm = new MessageForm())
				{
					messageForm.Time = this.MessageGridView.Rows[e.RowIndex].Cells["TimeColumn"].Value.ToString();
					messageForm.Machine = Environment.MachineName;
					messageForm.Message = this.MessageGridView.Rows[e.RowIndex].Cells["MessageColumn"].Value.ToString();

					messageForm.ShowDialog();
				}
			}
		}

		/// <summary>
		/// 使用者點擊處理錯誤訊息的 CheckBox
		/// </summary>
		private void ErrorGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
		{
			// 若點擊 CheckBox，則才處理後續工作。
			if (e.ColumnIndex == 0)
			{
				DialogResult dialogResult = MessageBox.Show("確定問題已處理完成？", "詢問", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
				if (dialogResult == System.Windows.Forms.DialogResult.Yes)
				{
					Log.Info("使用者處理了錯誤訊息：" + this.ErrorGridView.Rows[e.RowIndex].Cells["ErrorMessageColumn"].Value);

					this.ErrorGridView.Rows.RemoveAt(e.RowIndex);
				}
			}
			else
			{
				using (var messageForm = new MessageForm())
				{
					messageForm.Time = this.ErrorGridView.Rows[e.RowIndex].Cells["ErrorTimeColumn"].Value.ToString();
					messageForm.Machine = Environment.MachineName;
					messageForm.Message = this.ErrorGridView.Rows[e.RowIndex].Cells["ErrorMessageColumn"].Value.ToString();

					messageForm.ShowDialog();
				}
			}
		}

		/// <summary>
		/// 儲存視窗位置
		/// </summary>
		private void MainForm_LocationChanged(object sender, EventArgs e)
		{
			Properties.Settings.Default.WindowAppearance = JsonConvert.SerializeObject(this.WindowAppearance);
			Properties.Settings.Default.Save();
		}

		/// <summary>
		/// 儲存視窗大小
		/// </summary>
		private void MainForm_Resize(object sender, EventArgs e)
		{
			Properties.Settings.Default.WindowAppearance = JsonConvert.SerializeObject(this.WindowAppearance);
			Properties.Settings.Default.Save();
		}

		/// <summary>
		/// 程式即將關閉
		/// </summary>
		private void MainForm_FormClosed(object sender, FormClosedEventArgs e)
		{
			Log.Info("使用者點擊關閉");

			this.StopJob();

			if (this.Jobs.All((job) => !job.IsExecuting))
			{
				Log.Info("作業停止");
				this.SwitchStoppedState();
			}
			else
			{
				//e.Cancel = true;

				this.JobStopping(ThenExecute.Exit);

				MessageBox.Show("部分作業尚未結束，待結束後會立即關閉程式 !!", "警告", MessageBoxButtons.OK, MessageBoxIcon.Warning);
			}

			//if (this.ErrorGridView.Rows.Count > 0 && MessageBox.Show("程式執行過程中有錯誤發生，確定要關閉程式？", "詢問", MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes)
			//{
			//	e.Cancel = true;

			//	this.InvokeIfNecessary(() =>
			//	{
			//		SwitchStoppedState();
			//	});
			//}
		}

		#endregion

		#region Forms
		private void 網站ToolStripMenuItem_Click(object sender, EventArgs e)
		{
			Form form = new WebSite();

			form.ShowDialog();
		}

		private void 書籍ToolStripMenuItem_Click(object sender, EventArgs e)
		{
			Form form = new Book();

			form.ShowDialog();

			LoadJob();
		}

		private void 章節ToolStripMenuItem_Click(object sender, EventArgs e)
		{
			Form form = new ChaptersEdit();

			form.ShowDialog();
		}

		#endregion

	}
}
