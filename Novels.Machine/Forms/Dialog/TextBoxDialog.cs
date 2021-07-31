using System.Windows.Forms;

namespace Novels.Machine.Forms.Dialog
{
	public partial class TextBoxDialog : Form
	{
		public string inputText { get { return textBox1.Text; } }

		public TextBoxDialog(string title, string text)
		{
			InitializeComponent();

			this.Text = title;

			textBox1.Text = text;			

			button1.DialogResult = DialogResult.OK;
		}
	}
}
