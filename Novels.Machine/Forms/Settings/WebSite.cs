using Novels.Machine.App_Code;
using Novels.Machine.App_Start;

using Novels.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace Novels.Machine.Forms.Settings
{
	public partial class WebSite : Form
	{
		#region 屬性、欄位、物件

		List<HtmlRule> HtmlRules { get { return DB.HtmlRule.Query(new HtmlRuleQueryCondition()).QueryResult.ToList(); } }

		#endregion

		public WebSite()
		{
			InitializeComponent();

			ConfirmButton.DialogResult = DialogResult.OK;

			LoadData();
		}

		private void LoadData()
		{
			listBox1.DataSource = new BindingSource(HtmlRules.ToDictionary("Name"), null);
			listBox1.DisplayMember = "Key";
			listBox1.ValueMember = "Value";
		}

		#region EventHandler

		private void AddButton_Click(object sender, EventArgs e)
		{
			var htmlRule = new HtmlRule()
			{
				ID = HtmlRules.Max(x => x.ID) + 1,
				Sort = HtmlRules.Max(x => x.Sort) + 1
			};

			var form = new WebSiteEdit(htmlRule);

			if (form.ShowDialog(this) == DialogResult.OK)
			{
				htmlRule = form.htmlRule;

				htmlRule.Ver();

				DB.HtmlRule.Create(htmlRule);

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

			var htmlRule = (HtmlRule)listBox1.SelectedValue;

			var form = new WebSiteEdit(htmlRule);

			if (form.ShowDialog(this) == DialogResult.OK)
			{
				try
				{
					htmlRule = form.htmlRule;

					htmlRule.Ver();

					DB.HtmlRule.Modify(htmlRule);

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

			var sourceObj = (HtmlRule)listBox1.SelectedValue;

			sourceObj.Sort--;

			DB.HtmlRule.Modify(sourceObj);

			var targetObj = (HtmlRule)((KeyValuePair<string, object>)listBox1.Items[listBox1.SelectedIndex - 1]).Value;

			targetObj.Sort++;

			DB.HtmlRule.Modify(targetObj);

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

			if (listBox1.SelectedIndex + 1 >= HtmlRules.Count)
			{
				MessageBox.Show("超出範圍");
				return;
			}

			var sourceObj = (HtmlRule)listBox1.SelectedValue;

			sourceObj.Sort++;

			DB.HtmlRule.Modify(sourceObj);

			var targetObj = (HtmlRule)((KeyValuePair<string, object>)listBox1.Items[listBox1.SelectedIndex + 1]).Value;

			targetObj.Sort--;

			DB.HtmlRule.Modify(targetObj);

			LoadData();

			listBox1.SelectedIndex++;
		}

		#endregion

	}
}
