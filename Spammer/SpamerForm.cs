using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Spammer
{
	public partial class Multiline_spammer : Form
	{
		SpammerClass sc;
		private int rdbIndex;
        //private Color StartColor;
		public Multiline_spammer()
		{
			InitializeComponent();						
		}

		#region "QBOXES"

		private void qbWait_Click(object sender, EventArgs e)
		{
			MessageBox.Show("Enter a numeric value (seconds) to indicate how long the program has to wait before spamming.");
		}

		private void qbInterval_Click(object sender, EventArgs e)
		{
			MessageBox.Show("The amount of time the spammer wait between each line of text.");
		}

		private void qbTopMost_Click(object sender, EventArgs e)
		{
			MessageBox.Show("When checked, the spammer will try to always be on top of the active program.");
		}

		private void qbStartEnter_Click(object sender, EventArgs e)
		{
			MessageBox.Show("When checked the spammer will simulate the pressing of the enter key before and after each line of spamtext.\nWhen uncheck the spammer will only simulate the pressing of the enter key acfter each line of spamtext. \n TShis is useful for programs where the enter key has to open and close the chatbox.");
		}

		#endregion

		private void btnSpamStart_Click(object sender, EventArgs e)
		{
			btnSpamStart.Enabled = false;
			btnSpamStop.Enabled = true;

			gbSpammerSettings.Enabled = false;
			gbSpammerContent.Enabled = false;

			sc = new SpammerClass((int)nudWait.Value, (int)nudInterval.Value, chbStartEnter.Checked);

			//gegevens naar de spammer sturen
			string[] SpamContentBuffer = new string[11];
			
			for (int i = 1; i <= 10; i++)
			{
				SpamContentBuffer[i] = this.gbSpammerContent.Controls["SpammerContent" + i].Text;
			}
			rtbSpamDump.Focus();
            if (chbTopMost.Checked == true)
                this.TopMost = true;
			//rdb zoeken

			#region "RadioButtons"

            //if (rdb1.Checked == true)
            //    rdbIndex = 1;

            //if (rdb2.Checked == true)
            //    rdbIndex = 2;

            //if (rdb3.Checked == true)
            //    rdbIndex = 3;

            //if (rdb4.Checked == true)
            //    rdbIndex = 4;

            //if (rdb5.Checked == true)
            //    rdbIndex = 5;

            //if (rdb6.Checked == true)
            //    rdbIndex = 1;

            //if (rdb7.Checked == true)
            //    rdbIndex = 7;

            //if (rdb8.Checked == true)
            //    rdbIndex = 8;

            //if (rdb9.Checked == true)
            //    rdbIndex = 9;

            //if (rdb10.Checked == true)
            //    rdbIndex = 10;

            #endregion "RadioButtons"
            
            for (int i = 1; i <= 10; i++)
            {
                if (((RadioButton)this.gbSpammerContent.Controls["rdb" + i]).Checked == true)
                    rdbIndex = i;
            }

			sc.StartSpammer(SpamContentBuffer, rdbIndex);
		}
		
		private void Multiline_spammer_Load(object sender, EventArgs e)
		{
			btnSpamStop.Enabled = false;
            //StartColor = msSpammerForm.ForeColor;
            //msSpammerForm.ForeColor = Color.White;

			for (int i = 1; i <= 10; i++)
			{
				this.gbSpammerContent.Controls["SpammerContent" + i].Text = i.ToString();
			}
		}

		private void btnSpamStop_Click(object sender, EventArgs e)
		{
			btnSpamStart.Enabled = true;
			btnSpamStop.Enabled = false;

			gbSpammerSettings.Enabled = true;
			gbSpammerContent.Enabled = true;

			sc.StopSpammer();
		}

		private void btnEraseSpamDump_Click(object sender, EventArgs e)
		{
			rtbSpamDump.Clear();
			rtbSpamDump.Focus();
		}

        #region "ToolStripColors"

        private void FileToolStripMenuItem_DropDownOpening(object sender, EventArgs e)
        {
            FileToolStripMenuItem.ForeColor = Color.Black;
        }

        private void FileToolStripMenuItem_DropDownClosed(object sender, EventArgs e)
        {
            FileToolStripMenuItem.ForeColor = Color.White;
        }        

        private void helpToolStripMenuItem_DropDownOpening(object sender, EventArgs e)
        {
           HelpToolStripMenuItem.ForeColor = Color.Black;
        }

        private void helpToolStripMenuItem_DropDownClosed(object sender, EventArgs e)
        {
            HelpToolStripMenuItem.ForeColor = Color.White;
        }

        #endregion "ToolStripColors"

        private void quitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void rmbClickerToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }        

    }
}
