using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Novels.Machine.Forms.Dialog
{
	public partial class MessageForm : Form
	{
		public MessageForm()
		{
			InitializeComponent();
		}

        /// <summary>
        /// 時間
        /// </summary>
        public string Time
        {
            set
            {
                this.lblTime.Text = value;
            }
        }

        /// <summary>
        /// 機器
        /// </summary>
        public string Machine
        {
            set
            {
                this.lblMachine.Text = value;
            }
        }

        /// <summary>
        /// 訊息
        /// </summary>
        public string Message
        {
            set
            {
                this.rtbMessage.Text = value;
            }
        }
    }
}
