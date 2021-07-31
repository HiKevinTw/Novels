using Novels.Machine.App_Code;
using Novels.Machine.App_Start;
using Novels.Machine.Forms.Dialog;

using Novels.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace Novels.Machine.Forms.Settings
{
	public partial class ChaptersEdit : Form
	{
		#region 屬性、欄位、物件

		List<Novel> Novels { get { return DB.Novel.Query(new NovelQueryCondition()).QueryResult.ToList(); } }

		Novel EditNovel
		{
			get
			{
				if (string.IsNullOrEmpty(((KeyValuePair<string, object>)comboBox1.SelectedItem).Key))
				{
					return null;
				}
				else
				{
					return (Novel)comboBox1.SelectedValue;
				}
			}
		}

		#endregion

		public ChaptersEdit()
		{
			InitializeComponent();

			dataGridView1.MultiSelect = false;

			dataGridView1.ReadOnly = false;                             // 取消唯讀
			dataGridView1.EditMode = DataGridViewEditMode.EditOnEnter;  // 進入編輯模式
			dataGridView1.AllowDrop = true;                             // 允許拖曳

			LoadData();
		}

		protected void LoadData()
		{
			comboBox1.DataSource = new BindingSource(Novels.ToDictionary("Name", true), null);
			comboBox1.DisplayMember = "Key";
			comboBox1.ValueMember = "Value";
		}

		#region EventHandler

		private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
		{
			textBox1.DataBindings.Clear();
			textBox1.Clear();

			dataGridView1.DataSource = null;

			if (EditNovel != null)
			{
				var list = new BindingList<Chapter>(EditNovel.Chapters);
				dataGridView1.DataSource = list;

				dataGridView1.Columns["ID"].Visible = false;                // Columns[0]
				dataGridView1.Columns["NovelID"].Visible = false;           // Columns[1]
				dataGridView1.Columns["Sort"].ReadOnly = true;              // Columns[2] Sort 唯讀
				dataGridView1.Columns["Title"].Visible = true;             // Columns[3]
				dataGridView1.Columns["Content"].Visible = true;           // Columns[4]
																			//dataGridView1.Columns["WebLink"].Visible = false;			// Columns[5]
				dataGridView1.Columns["UpdateTime"].Visible = false;        // Columns[6]
			}

			//if (EditNovel != null)
			//{
			//	foreach (var item in EditNovel.Chapters)
			//	{
			//		item.UpdateTime = DateTime.Now;
			//	}

			//	EditNovel.UpdateTime = DateTime.Now;

			//	DB.Novel.Modify(EditNovel);
			//}
		}

		/// <summary>
		/// add
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void button5_Click(object sender, EventArgs e)
		{
			if (EditNovel != null)
			{
				int id = DB.Chapter.Query(new ChapterQueryCondition()).QueryResult.Max(x => x.ID) + 1;
				int sort = EditNovel.Chapters.Max(x => x.Sort) + 1;

				var form = new TextBoxDialog("請輸入數字", sort.ToString());

				form.ShowDialog();

				string resultString = form.inputText;

				if (!int.TryParse(resultString, out sort))
				{
					MessageBox.Show("輸入錯誤!");
					return;
				}

				var editChapters = EditNovel.Chapters.Where(x => x.Sort >= sort);

				if (editChapters.Count() > 0)
				{
					foreach (var item in editChapters)
					{
						item.Sort++;
						DB.Chapter.Modify(item);
					}
				}

				var Chapter = new Chapter()
				{
					ID = id,
					NovelID = EditNovel.ID,
					Sort = sort,
					UpdateTime = DateTime.Now
				};

				DB.Chapter.Create(Chapter);

				int ScrollingRowIndex = this.dataGridView1.FirstDisplayedScrollingRowIndex;

				int ComboBoxIndex = comboBox1.SelectedIndex;

				LoadData();

				comboBox1.SelectedIndex = ComboBoxIndex;

				dataGridView1.CurrentCell = dataGridView1.Rows[Chapter.Sort - 1].Cells[5];
				this.dataGridView1.FirstDisplayedScrollingRowIndex = ScrollingRowIndex;

			}
		}

		/// <summary>
		/// delete
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void button6_Click(object sender, EventArgs e)
		{
			if (dataGridView1.Focused || dataGridView1.CurrentCell.ColumnIndex > 0)
			{
				DialogResult result = MessageBox.Show("是否刪除該筆資料", "確認", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

				if (result == DialogResult.Yes)
				{
					int SourceIndex = dataGridView1.SelectedRows[0].Index;

					int RemoveSort = EditNovel.Chapters[SourceIndex].Sort;

					DB.Chapter.Remove(EditNovel.Chapters[SourceIndex]);

					//刪除之後，修改其他的排序
					var ModifyObj = EditNovel.Chapters.Where(x => x.Sort > RemoveSort);

					foreach (var item in ModifyObj)
					{
						item.Sort = item.Sort - 1;

						DB.Chapter.Modify(item);
					}

					int ScrollingRowIndex = this.dataGridView1.FirstDisplayedScrollingRowIndex;

					int ComboBoxIndex = comboBox1.SelectedIndex;

					if (SourceIndex > 0)
					{
						SourceIndex--;
					}

					LoadData();

					comboBox1.SelectedIndex = ComboBoxIndex;

					dataGridView1.CurrentCell = dataGridView1.Rows[SourceIndex].Cells[5];
					this.dataGridView1.FirstDisplayedScrollingRowIndex = ScrollingRowIndex;
				}
			}
		}

		/// <summary>
		/// Download
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void DownloadButton_Click(object sender, EventArgs e)
		{
			if (EditNovel == null)
			{
				MessageBox.Show("未選擇");
				return;
			}

			EditNovel.DownloadChapters();
		}

		/// <summary>
		/// 重置排序
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void button7_Click(object sender, EventArgs e)
		{
			if (EditNovel != null)
			{
				for (int i = 0; i < EditNovel.Chapters.Count; i++)
				{
					EditNovel.Chapters[i].Sort = i + 1;

					DB.Chapter.Modify(EditNovel.Chapters[i]);
				}
			}

			LoadData();
		}

		#endregion

		#region dataGridView EventHandler
		//清除預設的選取
		private void dataGridView1_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
		{
			dataGridView1.ClearSelection();
		}
		private void dataGridView1_SelectionChanged(object sender, EventArgs e)
		{
			textBox1.DataBindings.Clear();
			textBox1.Clear();

			if (dataGridView1.Focused || dataGridView1.CurrentCell.ColumnIndex > 0)
			{
				textBox1.DataBindings.Add("Text", dataGridView1.Rows[dataGridView1.CurrentRow.Index].Cells["Content"], "Value");
			}
		}

		private void dataGridView1_CellValueChanged(object sender, DataGridViewCellEventArgs e)
		{
			if (dataGridView1.Focused || dataGridView1.CurrentCell.ColumnIndex > 0)
			{
				int SourceIndex = dataGridView1.SelectedRows[0].Index;

				DB.Chapter.Modify(EditNovel.Chapters[SourceIndex]);
			}
		}

		private void dataGridView1_MouseDown(object sender, MouseEventArgs e)
		{
			if (dataGridView1.HitTest(e.X, e.Y).Type != DataGridViewHitTestType.Cell) return;

			if (e.Button == MouseButtons.Left)
			{
				if (dataGridView1.Rows[dataGridView1.HitTest(e.X, e.Y).RowIndex].IsNewRow) return;
			}
		}

		private void dataGridView1_MouseMove(object sender, MouseEventArgs e)
		{
			if (dataGridView1.HitTest(e.X, e.Y).Type != DataGridViewHitTestType.Cell) return;

			if (e.Button == MouseButtons.Left)
			{
				dataGridView1.Rows[dataGridView1.SelectedCells[0].RowIndex].Selected = true;
				dataGridView1.DoDragDrop(dataGridView1.SelectedRows[0], DragDropEffects.Move);
			}
		}

		private void dataGridView1_DragEnter(object sender, DragEventArgs e)
		{
			e.Effect = DragDropEffects.Move;
		}

		private void dataGridView1_DragDrop(object sender, DragEventArgs e)
		{
			if (((DataObject)e.Data).GetData(typeof(DataGridViewRow)) == null) return;

			// The mouse locations are relative to the screen, so they must be 
			// converted to client coordinates.
			Point TargetPoint = dataGridView1.PointToClient(new Point(e.X, e.Y));

			if ((dataGridView1.HitTest(TargetPoint.X, TargetPoint.Y).Type != DataGridViewHitTestType.Cell)) return;

			// Get the row index of the item the mouse is below. 
			int TargetIndex = dataGridView1.HitTest(TargetPoint.X, TargetPoint.Y).RowIndex;


			if ((dataGridView1.Rows[TargetIndex].IsNewRow) || (dataGridView1.SelectedRows.Contains(dataGridView1.Rows[TargetIndex]))) return;

			if (e.Effect == DragDropEffects.Move)
			{

				if (dataGridView1.DataSource == null)       // dataGridView 沒有 DataSource 本專案不適用
				{
					DataGridViewRow SourceRow = dataGridView1.SelectedRows[0];      // 被選取的 Row
					dataGridView1.Rows.Remove(SourceRow);                           // 從 dataGridView 刪掉 被選取的 Row
					dataGridView1.Rows.Insert(TargetIndex, SourceRow);           // 從 dataGridView 的指定位置 抽入 被選取的 Row
				}
				else
				{
					#region dataGridView DataSource 為 DataTable 的範例
					//// 驗證 dataGridView DataSource 物件
					//DataTable SourceData = dataGridView1.DataSource.GetType() == typeof(BindingSource) ? ((DataSet)((BindingSource)dataGridView1.DataSource).DataSource).Tables[0] : (DataTable)dataGridView1.DataSource;
					//SourceData.PrimaryKey = new DataColumn[] { SourceData.Columns[0] };

					//DataRow OriginRow = SourceData.Rows.Find(dataGridView1.SelectedRows[0].Cells[0].Value);
					//if (OriginRow == null) return;

					//DataRow SourceRow = SourceData.NewRow();
					//int InsertIndex = SourceData.Rows.IndexOf(SourceData.Rows.Find(dataGridView1.Rows[TargetRowIndex].Cells[0].Value));
					//SourceRow.ItemArray = OriginRow.ItemArray;
					//SourceData.Rows.Remove(OriginRow);
					//SourceData.Rows.InsertAt(SourceRow, InsertIndex);

					//SourceData.AcceptChanges();
					#endregion

					int SourceIndex = dataGridView1.SelectedRows[0].Index;

					if (SourceIndex > TargetIndex)
					{
						EditNovel.Chapters[SourceIndex].Sort = EditNovel.Chapters[TargetIndex].Sort;

						DB.Chapter.Modify(EditNovel.Chapters[SourceIndex]);

						for (int i = TargetIndex; i < SourceIndex; i++)
						{
							EditNovel.Chapters[i].Sort = EditNovel.Chapters[i].Sort + 1;

							DB.Chapter.Modify(EditNovel.Chapters[i]);
						}
					}

					else if (TargetIndex > SourceIndex)
					{
						EditNovel.Chapters[SourceIndex].Sort = EditNovel.Chapters[TargetIndex].Sort;

						DB.Chapter.Modify(EditNovel.Chapters[SourceIndex]);

						for (int i = TargetIndex; i > SourceIndex; i--)
						{
							EditNovel.Chapters[i].Sort = EditNovel.Chapters[i].Sort - 1;

							DB.Chapter.Modify(EditNovel.Chapters[i]);
						}
					}

					EditNovel.Chapters = EditNovel.Chapters.OrderBy(x => x.Sort).ToList();
					var list = new BindingList<Chapter>(EditNovel.Chapters);
					dataGridView1.DataSource = list;
				}
			}

			dataGridView1.CurrentCell = dataGridView1.Rows[TargetIndex].Cells[dataGridView1.CurrentCell.ColumnIndex];
		}

		#endregion
	}
}
