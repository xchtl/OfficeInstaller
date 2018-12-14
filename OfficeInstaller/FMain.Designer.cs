namespace OfficeInstaller
{
	partial class FMain
	{
		/// <summary>
		/// 必需的设计器变量。
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// 清理所有正在使用的资源。
		/// </summary>
		/// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing && (components != null))
			{
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Windows 窗体设计器生成的代码

		/// <summary>
		/// 设计器支持所需的方法 - 不要修改
		/// 使用代码编辑器修改此方法的内容。
		/// </summary>
		private void InitializeComponent()
		{
			this.components = new System.ComponentModel.Container();
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FMain));
			this.bInstall = new System.Windows.Forms.Button();
			this.gbProducts = new System.Windows.Forms.GroupBox();
			this.flpProducts = new System.Windows.Forms.FlowLayoutPanel();
			this.groupBox1 = new System.Windows.Forms.GroupBox();
			this.flpOptions = new System.Windows.Forms.FlowLayoutPanel();
			this.pEdition = new System.Windows.Forms.Panel();
			this.rbx64 = new System.Windows.Forms.RadioButton();
			this.rbx86 = new System.Windows.Forms.RadioButton();
			this.label1 = new System.Windows.Forms.Label();
			this.cbOnline = new System.Windows.Forms.CheckBox();
			this.pSourcePath = new System.Windows.Forms.Panel();
			this.tbSourcePath = new System.Windows.Forms.TextBox();
			this.bBrowseSource = new System.Windows.Forms.ButtonEx();
			this.label2 = new System.Windows.Forms.Label();
			this.pLicenseMode = new System.Windows.Forms.Panel();
			this.rbVol = new System.Windows.Forms.RadioButton();
			this.rbRetail = new System.Windows.Forms.RadioButton();
			this.label3 = new System.Windows.Forms.Label();
			this.cbLanguage = new System.Windows.Forms.ComboBox();
			this.label4 = new System.Windows.Forms.Label();
			this.tbKMSServer = new System.Windows.Forms.TextBox();
			this.bUninstall = new System.Windows.Forms.Button();
			this.bActivation = new System.Windows.Forms.Button();
			this.pMain = new System.Windows.Forms.Panel();
			this.bShowMore = new System.Windows.Forms.ButtonEx();
			this.ProgressBar = new System.Windows.Forms.ProgressBar();
			this.cmsUninstall = new System.Windows.Forms.ContextMenuStrip(this.components);
			this.tsmi_Uninstall = new System.Windows.Forms.ToolStripMenuItem();
			this.tsmi_UninstallAll = new System.Windows.Forms.ToolStripMenuItem();
			this.cmsActivate = new System.Windows.Forms.ContextMenuStrip(this.components);
			this.tsmi_Activate_KMS = new System.Windows.Forms.ToolStripMenuItem();
			this.tsmi_Activate_QAD = new System.Windows.Forms.ToolStripMenuItem();
			this.gbProducts.SuspendLayout();
			this.groupBox1.SuspendLayout();
			this.flpOptions.SuspendLayout();
			this.pEdition.SuspendLayout();
			this.pSourcePath.SuspendLayout();
			this.pLicenseMode.SuspendLayout();
			this.pMain.SuspendLayout();
			this.cmsUninstall.SuspendLayout();
			this.cmsActivate.SuspendLayout();
			this.SuspendLayout();
			// 
			// bInstall
			// 
			this.bInstall.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.bInstall.Location = new System.Drawing.Point(12, 346);
			this.bInstall.Name = "bInstall";
			this.bInstall.Size = new System.Drawing.Size(150, 23);
			this.bInstall.TabIndex = 4;
			this.bInstall.Text = "安装";
			this.bInstall.UseVisualStyleBackColor = true;
			this.bInstall.Click += new System.EventHandler(this.bInstall_Click);
			// 
			// gbProducts
			// 
			this.gbProducts.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
			this.gbProducts.Controls.Add(this.flpProducts);
			this.gbProducts.Location = new System.Drawing.Point(12, 12);
			this.gbProducts.Name = "gbProducts";
			this.gbProducts.Size = new System.Drawing.Size(250, 321);
			this.gbProducts.TabIndex = 5;
			this.gbProducts.TabStop = false;
			this.gbProducts.Text = "产品选择";
			// 
			// flpProducts
			// 
			this.flpProducts.AutoScroll = true;
			this.flpProducts.Dock = System.Windows.Forms.DockStyle.Fill;
			this.flpProducts.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
			this.flpProducts.Location = new System.Drawing.Point(3, 17);
			this.flpProducts.Name = "flpProducts";
			this.flpProducts.Size = new System.Drawing.Size(244, 301);
			this.flpProducts.TabIndex = 6;
			this.flpProducts.WrapContents = false;
			// 
			// groupBox1
			// 
			this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.groupBox1.Controls.Add(this.flpOptions);
			this.groupBox1.Location = new System.Drawing.Point(269, 12);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new System.Drawing.Size(229, 321);
			this.groupBox1.TabIndex = 6;
			this.groupBox1.TabStop = false;
			this.groupBox1.Text = "选项";
			// 
			// flpOptions
			// 
			this.flpOptions.Controls.Add(this.pEdition);
			this.flpOptions.Controls.Add(this.label1);
			this.flpOptions.Controls.Add(this.cbOnline);
			this.flpOptions.Controls.Add(this.pSourcePath);
			this.flpOptions.Controls.Add(this.label2);
			this.flpOptions.Controls.Add(this.pLicenseMode);
			this.flpOptions.Controls.Add(this.label3);
			this.flpOptions.Controls.Add(this.cbLanguage);
			this.flpOptions.Controls.Add(this.label4);
			this.flpOptions.Controls.Add(this.tbKMSServer);
			this.flpOptions.Dock = System.Windows.Forms.DockStyle.Fill;
			this.flpOptions.Location = new System.Drawing.Point(3, 17);
			this.flpOptions.Name = "flpOptions";
			this.flpOptions.Size = new System.Drawing.Size(223, 301);
			this.flpOptions.TabIndex = 8;
			// 
			// pEdition
			// 
			this.pEdition.Controls.Add(this.rbx64);
			this.pEdition.Controls.Add(this.rbx86);
			this.pEdition.Location = new System.Drawing.Point(3, 3);
			this.pEdition.Name = "pEdition";
			this.pEdition.Size = new System.Drawing.Size(217, 24);
			this.pEdition.TabIndex = 0;
			this.pEdition.Tag = "";
			// 
			// rbx64
			// 
			this.rbx64.AutoSize = true;
			this.rbx64.Location = new System.Drawing.Point(92, 4);
			this.rbx64.Name = "rbx64";
			this.rbx64.Size = new System.Drawing.Size(41, 16);
			this.rbx64.TabIndex = 1;
			this.rbx64.Tag = "64";
			this.rbx64.Text = "x64";
			this.rbx64.UseVisualStyleBackColor = true;
			this.rbx64.CheckedChanged += new System.EventHandler(this.rbVer_Click);
			// 
			// rbx86
			// 
			this.rbx86.AutoSize = true;
			this.rbx86.Location = new System.Drawing.Point(3, 3);
			this.rbx86.Name = "rbx86";
			this.rbx86.Size = new System.Drawing.Size(41, 16);
			this.rbx86.TabIndex = 0;
			this.rbx86.Tag = "32";
			this.rbx86.Text = "x86";
			this.rbx86.UseVisualStyleBackColor = true;
			this.rbx86.CheckedChanged += new System.EventHandler(this.rbVer_Click);
			// 
			// label1
			// 
			this.label1.Location = new System.Drawing.Point(3, 33);
			this.label1.Margin = new System.Windows.Forms.Padding(3);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(71, 16);
			this.label1.TabIndex = 1;
			this.label1.Text = "安装源路径:";
			this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// cbOnline
			// 
			this.cbOnline.Location = new System.Drawing.Point(80, 33);
			this.cbOnline.Name = "cbOnline";
			this.cbOnline.Size = new System.Drawing.Size(104, 16);
			this.cbOnline.TabIndex = 8;
			this.cbOnline.Text = "在线安装";
			this.cbOnline.UseVisualStyleBackColor = true;
			this.cbOnline.CheckedChanged += new System.EventHandler(this.cbOnline_CheckedChanged);
			// 
			// pSourcePath
			// 
			this.pSourcePath.Controls.Add(this.tbSourcePath);
			this.pSourcePath.Controls.Add(this.bBrowseSource);
			this.pSourcePath.Location = new System.Drawing.Point(3, 55);
			this.pSourcePath.Name = "pSourcePath";
			this.pSourcePath.Size = new System.Drawing.Size(217, 21);
			this.pSourcePath.TabIndex = 2;
			// 
			// tbSourcePath
			// 
			this.tbSourcePath.Dock = System.Windows.Forms.DockStyle.Fill;
			this.tbSourcePath.Location = new System.Drawing.Point(0, 0);
			this.tbSourcePath.Name = "tbSourcePath";
			this.tbSourcePath.Size = new System.Drawing.Size(185, 21);
			this.tbSourcePath.TabIndex = 2;
			this.tbSourcePath.Text = ".\\";
			// 
			// bBrowseSource
			// 
			this.bBrowseSource.Dock = System.Windows.Forms.DockStyle.Right;
			this.bBrowseSource.Location = new System.Drawing.Point(185, 0);
			this.bBrowseSource.Name = "bBrowseSource";
			this.bBrowseSource.Selectable = false;
			this.bBrowseSource.Size = new System.Drawing.Size(32, 21);
			this.bBrowseSource.TabIndex = 3;
			this.bBrowseSource.Text = "...";
			this.bBrowseSource.UseVisualStyleBackColor = true;
			this.bBrowseSource.Click += new System.EventHandler(this.bBrowseSource_Click);
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(3, 79);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(59, 12);
			this.label2.TabIndex = 4;
			this.label2.Text = "授权模式:";
			// 
			// pLicenseMode
			// 
			this.pLicenseMode.Controls.Add(this.rbVol);
			this.pLicenseMode.Controls.Add(this.rbRetail);
			this.pLicenseMode.Location = new System.Drawing.Point(3, 94);
			this.pLicenseMode.Name = "pLicenseMode";
			this.pLicenseMode.Size = new System.Drawing.Size(217, 24);
			this.pLicenseMode.TabIndex = 5;
			this.pLicenseMode.Tag = "";
			// 
			// rbVol
			// 
			this.rbVol.AutoSize = true;
			this.rbVol.Location = new System.Drawing.Point(104, 3);
			this.rbVol.Name = "rbVol";
			this.rbVol.Size = new System.Drawing.Size(95, 16);
			this.rbVol.TabIndex = 1;
			this.rbVol.Tag = "Volume";
			this.rbVol.Text = "批量(Volume)";
			this.rbVol.UseVisualStyleBackColor = true;
			this.rbVol.CheckedChanged += new System.EventHandler(this.rbLicenseMode_Click);
			// 
			// rbRetail
			// 
			this.rbRetail.AutoSize = true;
			this.rbRetail.Location = new System.Drawing.Point(3, 3);
			this.rbRetail.Name = "rbRetail";
			this.rbRetail.Size = new System.Drawing.Size(95, 16);
			this.rbRetail.TabIndex = 0;
			this.rbRetail.Tag = "Retail";
			this.rbRetail.Text = "零售(Retail)";
			this.rbRetail.UseVisualStyleBackColor = true;
			this.rbRetail.CheckedChanged += new System.EventHandler(this.rbLicenseMode_Click);
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Location = new System.Drawing.Point(3, 121);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(35, 12);
			this.label3.TabIndex = 6;
			this.label3.Text = "语言:";
			// 
			// cbLanguage
			// 
			this.cbLanguage.DisplayMember = "Name";
			this.cbLanguage.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cbLanguage.FormattingEnabled = true;
			this.cbLanguage.Location = new System.Drawing.Point(3, 136);
			this.cbLanguage.Name = "cbLanguage";
			this.cbLanguage.Size = new System.Drawing.Size(217, 20);
			this.cbLanguage.TabIndex = 7;
			// 
			// label4
			// 
			this.label4.AutoSize = true;
			this.label4.Location = new System.Drawing.Point(3, 159);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(71, 12);
			this.label4.TabIndex = 9;
			this.label4.Text = "激活服务器:";
			// 
			// tbKMSServer
			// 
			this.tbKMSServer.Location = new System.Drawing.Point(3, 174);
			this.tbKMSServer.Name = "tbKMSServer";
			this.tbKMSServer.Size = new System.Drawing.Size(217, 21);
			this.tbKMSServer.TabIndex = 10;
			// 
			// bUninstall
			// 
			this.bUninstall.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.bUninstall.Location = new System.Drawing.Point(348, 346);
			this.bUninstall.Name = "bUninstall";
			this.bUninstall.Size = new System.Drawing.Size(150, 23);
			this.bUninstall.TabIndex = 7;
			this.bUninstall.Text = "卸载";
			this.bUninstall.UseVisualStyleBackColor = true;
			this.bUninstall.Click += new System.EventHandler(this.bUninstall_Click);
			// 
			// bActivation
			// 
			this.bActivation.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.bActivation.Location = new System.Drawing.Point(180, 346);
			this.bActivation.Name = "bActivation";
			this.bActivation.Size = new System.Drawing.Size(150, 23);
			this.bActivation.TabIndex = 8;
			this.bActivation.Text = "激活";
			this.bActivation.UseVisualStyleBackColor = true;
			this.bActivation.Click += new System.EventHandler(this.bActivation_Click);
			// 
			// pMain
			// 
			this.pMain.Controls.Add(this.bShowMore);
			this.pMain.Controls.Add(this.bActivation);
			this.pMain.Controls.Add(this.gbProducts);
			this.pMain.Controls.Add(this.bUninstall);
			this.pMain.Controls.Add(this.bInstall);
			this.pMain.Controls.Add(this.groupBox1);
			this.pMain.Dock = System.Windows.Forms.DockStyle.Fill;
			this.pMain.Location = new System.Drawing.Point(0, 0);
			this.pMain.Name = "pMain";
			this.pMain.Size = new System.Drawing.Size(510, 381);
			this.pMain.TabIndex = 9;
			// 
			// bShowMore
			// 
			this.bShowMore.Location = new System.Drawing.Point(76, 7);
			this.bShowMore.Name = "bShowMore";
			this.bShowMore.Selectable = false;
			this.bShowMore.Size = new System.Drawing.Size(86, 21);
			this.bShowMore.TabIndex = 9;
			this.bShowMore.Text = "显示更多产品";
			this.bShowMore.UseVisualStyleBackColor = true;
			this.bShowMore.Click += new System.EventHandler(this.bShowMore_Click);
			// 
			// ProgressBar
			// 
			this.ProgressBar.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.ProgressBar.Location = new System.Drawing.Point(12, 165);
			this.ProgressBar.Name = "ProgressBar";
			this.ProgressBar.Size = new System.Drawing.Size(486, 23);
			this.ProgressBar.Style = System.Windows.Forms.ProgressBarStyle.Marquee;
			this.ProgressBar.TabIndex = 10;
			this.ProgressBar.Visible = false;
			// 
			// cmsUninstall
			// 
			this.cmsUninstall.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmi_Uninstall,
            this.tsmi_UninstallAll});
			this.cmsUninstall.Name = "cmsUninstall";
			this.cmsUninstall.Size = new System.Drawing.Size(149, 48);
			// 
			// tsmi_Uninstall
			// 
			this.tsmi_Uninstall.Name = "tsmi_Uninstall";
			this.tsmi_Uninstall.Size = new System.Drawing.Size(148, 22);
			this.tsmi_Uninstall.Text = "卸载指定产品";
			this.tsmi_Uninstall.Click += new System.EventHandler(this.tsmi_Uninstall_Click);
			// 
			// tsmi_UninstallAll
			// 
			this.tsmi_UninstallAll.Name = "tsmi_UninstallAll";
			this.tsmi_UninstallAll.Size = new System.Drawing.Size(148, 22);
			this.tsmi_UninstallAll.Text = "全部卸载";
			this.tsmi_UninstallAll.Click += new System.EventHandler(this.tsmi_UninstallAll_Click);
			// 
			// cmsActivate
			// 
			this.cmsActivate.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmi_Activate_KMS,
            this.tsmi_Activate_QAD});
			this.cmsActivate.Name = "cmsActivate";
			this.cmsActivate.Size = new System.Drawing.Size(188, 48);
			// 
			// tsmi_Activate_KMS
			// 
			this.tsmi_Activate_KMS.Name = "tsmi_Activate_KMS";
			this.tsmi_Activate_KMS.Size = new System.Drawing.Size(187, 22);
			this.tsmi_Activate_KMS.Text = "使用KMS服务器激活";
			this.tsmi_Activate_KMS.Click += new System.EventHandler(this.tsmi_Activate_KMS_Click);
			// 
			// tsmi_Activate_QAD
			// 
			this.tsmi_Activate_QAD.Name = "tsmi_Activate_QAD";
			this.tsmi_Activate_QAD.Size = new System.Drawing.Size(187, 22);
			this.tsmi_Activate_QAD.Text = "使用本地KMS激活";
			this.tsmi_Activate_QAD.Click += new System.EventHandler(this.tsmi_Activate_QAD_Click);
			// 
			// FMain
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(510, 381);
			this.Controls.Add(this.ProgressBar);
			this.Controls.Add(this.pMain);
			this.DoubleBuffered = true;
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.MaximizeBox = false;
			this.Name = "FMain";
			this.Text = "Office 2016 Installer @BloodFlyFox";
			this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FMain_FormClosing);
			this.Load += new System.EventHandler(this.FMain_Load);
			this.gbProducts.ResumeLayout(false);
			this.groupBox1.ResumeLayout(false);
			this.flpOptions.ResumeLayout(false);
			this.flpOptions.PerformLayout();
			this.pEdition.ResumeLayout(false);
			this.pEdition.PerformLayout();
			this.pSourcePath.ResumeLayout(false);
			this.pSourcePath.PerformLayout();
			this.pLicenseMode.ResumeLayout(false);
			this.pLicenseMode.PerformLayout();
			this.pMain.ResumeLayout(false);
			this.cmsUninstall.ResumeLayout(false);
			this.cmsActivate.ResumeLayout(false);
			this.ResumeLayout(false);

		}

		#endregion
		private System.Windows.Forms.Button bInstall;
		private System.Windows.Forms.GroupBox gbProducts;
		private System.Windows.Forms.GroupBox groupBox1;
		private System.Windows.Forms.Panel pEdition;
		private System.Windows.Forms.RadioButton rbx64;
		private System.Windows.Forms.RadioButton rbx86;
		private System.Windows.Forms.TextBox tbSourcePath;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.ButtonEx bBrowseSource;
		private System.Windows.Forms.Panel pLicenseMode;
		private System.Windows.Forms.RadioButton rbVol;
		private System.Windows.Forms.RadioButton rbRetail;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.FlowLayoutPanel flpProducts;
		private System.Windows.Forms.ComboBox cbLanguage;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.FlowLayoutPanel flpOptions;
		private System.Windows.Forms.Panel pSourcePath;
		private System.Windows.Forms.CheckBox cbOnline;
		private System.Windows.Forms.Button bUninstall;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.TextBox tbKMSServer;
		private System.Windows.Forms.Button bActivation;
		private System.Windows.Forms.Panel pMain;
		private System.Windows.Forms.ProgressBar ProgressBar;
		private System.Windows.Forms.ContextMenuStrip cmsUninstall;
		private System.Windows.Forms.ToolStripMenuItem tsmi_Uninstall;
		private System.Windows.Forms.ToolStripMenuItem tsmi_UninstallAll;
		private System.Windows.Forms.ButtonEx bShowMore;
		private System.Windows.Forms.ContextMenuStrip cmsActivate;
		private System.Windows.Forms.ToolStripMenuItem tsmi_Activate_KMS;
		private System.Windows.Forms.ToolStripMenuItem tsmi_Activate_QAD;
	}
}

