using Novels.Machine.App_Code;
using Novels.Model;
using System;
using System.Windows.Forms;

namespace Novels.Machine.Forms.Settings
{
	public partial class WebSiteEdit : Form
	{
		#region 屬性、欄位、物件
		public HtmlRule htmlRule { get; set; }

		#endregion

		public WebSiteEdit(HtmlRule htmlRule)
		{
			this.htmlRule = htmlRule;

			InitializeComponent();

			ConfirmButton.DialogResult = DialogResult.OK;

			CancelButton.DialogResult = DialogResult.Cancel;

			LoadData();
		}

		private void LoadData()
		{
			if (htmlRule != null)
			{

				textBox1.DataBindings.Add("Text", htmlRule, "Name");
				textBox2.DataBindings.Add("Text", htmlRule, "SiteTitle");
				textBox3.DataBindings.Add("Text", htmlRule, "ListXPath");
				textBox4.DataBindings.Add("Text", htmlRule, "ListTag");
				textBox5.DataBindings.Add("Text", htmlRule, "ListTagFilter");
				textBox6.DataBindings.Add("Text", htmlRule, "TextXPath");
				textBox7.DataBindings.Add("Text", htmlRule, "TextTag");
				textBox8.DataBindings.Add("Text", htmlRule, "TextTagFilter");

				textBox9.Text = @"https://tw.hjwzw.com/Book/Chapter/43237";
			}
		}

		#region EventHandler
		private void TestButton_Click(object sender, EventArgs e)
		{
			MessageBox.Show(htmlRule.Test(textBox9.Text, textBox10.Text));
		}

		#endregion
	}
}
