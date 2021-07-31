using Novels.Machine.App_Code;
using Novels.Machine.App_Start;
using Novels.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace Novels.Machine.Forms.Settings
{
	public partial class BookEdit : Form
	{
		#region 屬性、欄位、物件

		List<HtmlRule> HtmlRules { get { return DB.HtmlRule.Query(new HtmlRuleQueryCondition()).QueryResult.ToList(); } }

		public Novel novel { get; set; }

		#endregion

		public BookEdit(Novel novel)
		{
			this.novel = novel;

			InitializeComponent();

			ConfirmButton.DialogResult = DialogResult.OK;

			CancelButton.DialogResult = DialogResult.Cancel;

			LoadData();
		}

		private void LoadData()
		{
			var source = Util.ToDictionaryByEnum(typeof(ContentLinkMode));
			comboBox1.DataSource = new BindingSource(source, null);
			comboBox1.DisplayMember = "Key";
			comboBox1.ValueMember = "Value";

			var source2 = HtmlRules.ToDictionaryByObject("Name", "ID");
			comboBox2.DataSource = new BindingSource(source2, null);
			comboBox2.DisplayMember = "Key";
			comboBox2.ValueMember = "Value";

			if (novel != null)
			{
				textBox1.DataBindings.Add("Text", novel, "Name");
				textBox2.DataBindings.Add("Text", novel, "Author");
				textBox3.DataBindings.Add("Text", novel, "WebLink");
				textBox4.DataBindings.Add("Text", novel, "ContentLink");
				comboBox1.DataBindings.Add("SelectedValue", novel, "ContentLinkMode");
				comboBox2.DataBindings.Add("SelectedValue", novel, "HtmlRuleID");
				checkBox1.DataBindings.Add("Checked", novel, "IsFinish");
			}
		}

		#region EventHandler

		private void TestButton_Click(object sender, EventArgs e)
		{
			if (comboBox2.SelectedItem == null)
			{
				MessageBox.Show("未選擇");

				return;
			}

			novel.HtmlRule = DB.HtmlRule.Query(new HtmlRuleQueryCondition() { ID = novel.HtmlRuleID }).QueryResult.FirstOrDefault();

			MessageBox.Show(novel.Test());
		}

		#endregion
	}
}
