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
	class SpammerClass
	{
		private Timer spamTimer = new Timer();		
		private string[] spamText;
		
		private int WaitTime;
		private bool startEnter;
		private int rdbIndex;
		private int spamIndex = 1;
				
		public SpammerClass(int WaitTime, int Interval, bool StartEnter)
		{
			spamTimer.Interval = Interval;
			this.spamTimer.Tick += new System.EventHandler(SpamTimer_Tick);
			this.WaitTime = WaitTime;
			this.startEnter = StartEnter;
		}

		private void SpamTimer_Tick(object sender, EventArgs e)
		{

			if (startEnter == true)
				SendKeys.Send("{ENTER}");

			SendKeys.Send(spamText[spamIndex]);
			SendKeys.Send("{ENTER}");

			spamIndex = (spamIndex + 1) % (rdbIndex + 1);
			if (spamIndex < 1)
				spamIndex = 1;
		}

		public void StopSpammer()//wel nodig?
		{
			spamTimer.Stop();

		}

		public void StartSpammer(string[] Content, int LoopIndex)
		{
			this.rdbIndex = LoopIndex;
			spamText = new string[LoopIndex + 1];
			System.Threading.Thread.Sleep(WaitTime);
			for (int i = 1; i <= LoopIndex; i++)
			{
				spamText[i] = Content[i];
				//MessageBox.Show(spamText[i]);
			}

			spamTimer.Start();
		}
	}
}
