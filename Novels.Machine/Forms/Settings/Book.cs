using Novels.Machine.App_Code;
using Novels.Machine.App_Start;
using Novels.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace Novels.Machine.Forms.Settings
{
	public partial class Book : Form
	{
		#region 屬性、欄位、物件

		List<Novel> Novels { get { return DB.Novel.Query(new NovelQueryCondition()).QueryResult.ToList(); } }

		#endregion

		public Book()
		{
			InitializeComponent();

			ConfirmButton.DialogResult = DialogResult.OK;

			LoadData();
		}

		private void LoadData()
		{
			listBox1.DataSource = new BindingSource(Novels.ToDictionary("Name"), null);
			listBox1.DisplayMember = "Key";
			listBox1.ValueMember = "Value";
		}

		#region EventHandler

		private void AddButton_Click(object sender, EventArgs e)
		{
			var novel = new Novel()
			{
				ID = Novels.Max(x => x.ID) + 1,
				Sort = Novels.Max(x => x.Sort) + 1
			};

			var form = new BookEdit(novel);

			if (form.ShowDialog(this) == DialogResult.OK)
			{
				try
				{
					novel = form.novel;

					novel.Ver();

					DB.Novel.Create(novel);
				}
				catch (Exception ex)
				{
					MessageBox.Show(ex.Message);
				}

				LoadData();
			}
		}

		private void ModifyButton_Click(object sender, EventArgs e)
		{
			if (listBox1.SelectedValue == null)
			{
				MessageBox.Show("未選擇");
				return;
			}

			var novel = (Novel)listBox1.SelectedValue;

			var form = new BookEdit(novel);

			if (new BookEdit(novel).ShowDialog(this) == DialogResult.OK)
			{
				try
				{
					novel = form.novel;

					novel.Ver();

					DB.Novel.Modify(novel);

				}
				catch (Exception ex)
				{
					MessageBox.Show(ex.Message);
				}

				LoadData();
			}
		}

		private void DelButton_Click(object sender, EventArgs e)
		{
			MessageBox.Show("還沒做好");
		}

		private void UpButton_Click(object sender, EventArgs e)
		{
			if (listBox1.SelectedValue == null)
			{
				MessageBox.Show("未選擇");
				return;
			}

			if (listBox1.SelectedIndex == 0)
			{
				MessageBox.Show("超出範圍");
				return;
			}

			var sourceObj = (Novel)listBox1.SelectedValue;

			DB.Novel.Modify(sourceObj);

			sourceObj.Sort--;

			var targetObj = (Novel)((KeyValuePair<string, object>)listBox1.Items[listBox1.SelectedIndex - 1]).Value;

			targetObj.Sort++;

			DB.Novel.Modify(targetObj);

			LoadData();

			listBox1.SelectedIndex--;
		}

		private void DownButton_Click(object sender, EventArgs e)
		{
			if (listBox1.SelectedValue == null)
			{
				MessageBox.Show("未選擇");
				return;
			}

			if (listBox1.SelectedIndex + 1 >= Novels.Count)
			{
				MessageBox.Show("超出範圍");
				return;
			}

			var sourceObj = (Novel)listBox1.SelectedValue;

			sourceObj.Sort++;

			DB.Novel.Modify(sourceObj);

			var targetObj = (Novel)((KeyValuePair<string, object>)listBox1.Items[listBox1.SelectedIndex + 1]).Value;

			targetObj.Sort--;

			DB.Novel.Modify(targetObj);

			LoadData();

			listBox1.SelectedIndex++;
		}

		private void DownloadButton_Click(object sender, EventArgs e)
		{
			if (listBox1.SelectedValue == null)
			{
				MessageBox.Show("未選擇");
				return;
			}

			var novel = (Novel)listBox1.SelectedValue;

			novel.DownloadChapters();
		}

		#endregion


	}
}
