using OfficeInstaller.Configuration;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;

namespace OfficeInstaller
{
	public partial class FMain : Form
	{
		OfficeInstallerConfiguration Config = ConfigurationHelper.GetConfiguration<OfficeInstallerConfiguration>("officeInstaller");
		bool working;

		public FMain()
		{
			InitializeComponent();
        }

		private void FMain_Load(object sender, EventArgs e)
		{
			this.Text = $"{this.Text} Ver:{System.Reflection.Assembly.GetExecutingAssembly().GetName().Version}";
			ConfigProduct();
			ConfigLanguage();
			tbKMSServer.Text = Config.ActivationServer;
			if (Config.Edition == Edition.x86)
				rbx86.Checked = true;
			else
				rbx64.Checked = true;

			if (Config.LicenseMode == LicenseMode.Volume)
				rbVol.Checked = true;
			else
				rbRetail.Checked = true;
			tbSourcePath.Text = Config.SourcePath;
		}

		private void ConfigLanguage()
		{
			foreach (var language in Config.Languages.OfType<LanguageConfigurationElement>())
			{
				cbLanguage.Items.Add(new Language() { ID = language.ID, Name = language.Name });
			}

			cbLanguage.SelectedItem = cbLanguage.Items.OfType<Language>().FirstOrDefault(g => g.ID == Config.Languages.Default);
		}

		private void ConfigProduct(bool showHideedProduct = false)
		{
			foreach (var product in Config.Products.OfType<ProductConfigurationElement>().Where(g => g.Hide == showHideedProduct))
			{
				CheckBox cbProduct = new CheckBox();
				cbProduct.Text = product.Name;
				cbProduct.Tag = new Product() { ID = product.ID, Name = product.Name, LicenseMode = product.LicenseMode };
				cbProduct.AutoSize = true;
				cbProduct.TextAlign = ContentAlignment.MiddleLeft;
				cbProduct.CheckedChanged += CbProduct_CheckedChanged;
				flpProducts.Controls.Add(cbProduct);
				if (product.Checked)
					cbProduct.Checked = true;

				if (product.Applications.Count > 0)
				{
					FlowLayoutPanel flpApps = new FlowLayoutPanel();
					flpApps.AutoSize = true;
					flpApps.FlowDirection = FlowDirection.TopDown;
					flpApps.Padding = new Padding(10, 0, 0, 0);

					foreach (var app in product.Applications.OfType<AppConfigurationElement>())
					{
						CheckBox cbApp = new CheckBox();
						cbApp.Text = app.Name;
						cbApp.Tag = app.ID;
						cbApp.AutoSize = true;
						cbApp.TextAlign = ContentAlignment.MiddleLeft;
						cbApp.CheckedChanged += CbApp_CheckedChanged;

						flpApps.Controls.Add(cbApp);
						if (app.Checked)
							cbApp.Checked = true;
					}

					flpProducts.Controls.Add(flpApps);
					flpApps.Tag = cbProduct;
					flpApps.Enabled = cbProduct.Checked;
				}
			}
		}

		private void bBrowseSource_Click(object sender, EventArgs e)
		{
			FolderBrowserDialog fbd = new FolderBrowserDialog();
			fbd.SelectedPath = Path.GetFullPath(tbSourcePath.Text);
			if (fbd.ShowDialog(this) == DialogResult.OK)
			{
				tbSourcePath.Text = fbd.SelectedPath;
			}
		}

		private void CbApp_CheckedChanged(object sender, EventArgs e)
		{
			CheckBox cb = sender as CheckBox;

			if (!cb.Checked)
			{
				if (cb.Parent.Controls.OfType<CheckBox>().Count(g => g.Checked) == 0)
					cb.Checked = true;
			}
		}

		private void CbProduct_CheckedChanged(object sender, EventArgs e)
		{
			CheckBox cb = sender as CheckBox;

			var flp = flpProducts.Controls.OfType<FlowLayoutPanel>().FirstOrDefault(g => g.Tag == sender);

			if (flp != null)
				flp.Enabled = cb.Checked;
		}

		private void cbOnline_CheckedChanged(object sender, EventArgs e)
		{
			pSourcePath.Visible = !cbOnline.Checked;
		}

		private void rbVer_Click(object sender, EventArgs e)
		{
			pEdition.Tag = (sender as RadioButton).Tag;
		}

		private void rbLicenseMode_Click(object sender, EventArgs e)
		{
			pLicenseMode.Tag = (sender as RadioButton).Tag;
		}

		private void bInstall_Click(object sender, EventArgs e)
		{
			if (pEdition.Tag != null)
			{
				if (CheckLicenseMode())
				{
					pMain.Enabled = false;
					ProgressBar.Visible = true;
					try
					{
						string id = Guid.NewGuid().ToString("N");
						//id = "andytemp";
						string path = Path.Combine(Path.GetTempPath(), id);

						Directory.CreateDirectory(path);
						GenerateInstallConfigureFile(path);
						GenerateFile(path, "setup.exe", Properties.Resources.Setup);
						Task task = new Task(() =>
						{
							working = true;
							Run(path, "setup.exe", "/Configure Configure.xml");
						});
						task.ContinueWith(t =>
						{
							Clean(path);
							this.TryInvoke(() =>
							{
								pMain.Enabled = true;
								ProgressBar.Visible = false;
								if (t.Exception != null)
									MessageBox.Show(this, t.Exception.ToString(), "发生异常", MessageBoxButtons.OK, MessageBoxIcon.Error);
							});
							working = false;
						});
						task.Start();
					}
					catch (Exception ex)
					{
						MessageBox.Show(this, ex.ToString(), "发生异常", MessageBoxButtons.OK, MessageBoxIcon.Error);
					}
				}					
            }
			else
				MessageBox.Show(this, "请选择要安装的版本架构（x86或x64）。", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
		}

		private void bUninstall_Click(object sender, EventArgs e)
		{
			cmsUninstall.Show(sender as Control, 0, 0);
		}

		private void tsmi_Uninstall_Click(object sender, EventArgs e)
		{
			Uninstall(false);
		}

		private void tsmi_UninstallAll_Click(object sender, EventArgs e)
		{
			Uninstall(true);
		}

		bool CheckLicenseMode()
		{
			LicenseMode mode;
			if (Enum.TryParse<LicenseMode>(pLicenseMode.Tag as string, out mode) && mode != LicenseMode.All && mode != LicenseMode.None)
			{
				foreach (var cbProduct in flpProducts.Controls.OfType<CheckBox>())
				{
					Product product = cbProduct.Tag as Product;
					if (cbProduct.Checked)
						if ((product.LicenseMode & mode) != mode)
						{
							MessageBox.Show(this, $"产品 \"{product.Name}\" 不支持 \"{mode.GetDescription()}\" 授权模式。", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
							return false;
						}
				}
				return true;
			}
			else
			{
				MessageBox.Show(this, $"无法识别的授权模式 {mode}。", "错误", MessageBoxButtons.OK, MessageBoxIcon.Warning);
				return false;
			}
		}

		private void Uninstall(bool all)
		{
			pMain.Enabled = false;
			ProgressBar.Visible = true;
			try
			{
				string id = Guid.NewGuid().ToString("N");
				//id = "andytemp";
				string path = Path.Combine(Path.GetTempPath(), id);

				Directory.CreateDirectory(path);
				GenerateUninstallConfigureFile(path, all);
				GenerateFile(path, "setup.exe", Properties.Resources.Setup);
				Task task = new Task(() =>
				{
					working = true;
					Run(path, "setup.exe", "/Configure Configure.xml");
                });
				task.ContinueWith(t =>
				{
					Clean(path);
					this.TryInvoke(() =>
					{
						pMain.Enabled = true;
						ProgressBar.Visible = false;
						if (t.Exception != null)
							MessageBox.Show(this, t.Exception.ToString(), "发生异常", MessageBoxButtons.OK, MessageBoxIcon.Error);
					});
					working = false;
				});
				task.Start();
			}
			catch (Exception ex)
			{
				MessageBox.Show(this, ex.ToString(), "发生异常", MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
		}

		private void bActivation_Click(object sender, EventArgs e)
		{
			cmsActivate.Show(sender as Control, 0, 0);
		}


		private void tsmi_Activate_KMS_Click(object sender, EventArgs e)
		{
			Activation_KMS();
		}

		private void tsmi_Activate_QAD_Click(object sender, EventArgs e)
		{
			Activation_QAD();
		}

		private void Activation_KMS()
		{
			if (!String.IsNullOrEmpty(tbKMSServer.Text))
			{
				ProgressBar.Visible = true;
				pMain.Enabled = false;
				string id = Guid.NewGuid().ToString("N");
				string path = Path.Combine(Path.GetTempPath(), id);
				string kmsServer = tbKMSServer.Text;
				try
				{
					Directory.CreateDirectory(path);
					GenerateFile(path, "activation.cmd", Properties.Resources.Activation);
					Task task = new Task(() =>
					{
						working = true;
						Run(path, "activation.cmd", kmsServer);
					});

					task.ContinueWith(t =>
					{
						Clean(path);
						this.TryInvoke(() =>
						{
							pMain.Enabled = true;
							ProgressBar.Visible = false;
							if (t.Exception != null)
								MessageBox.Show(this, t.Exception.ToString(), "发生异常", MessageBoxButtons.OK, MessageBoxIcon.Error);
						});
						working = false;
					});

					task.Start();
				}
				catch (Exception ex)
				{
					MessageBox.Show(this, ex.ToString(), "发生异常", MessageBoxButtons.OK, MessageBoxIcon.Error);
				}
				finally
				{
				}
			}
			else
			{
				MessageBox.Show(this, "请输入激活服务器地址。", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
				this.ActiveControl = tbKMSServer;
			}
		}

		private void Activation_QAD()
		{
			ProgressBar.Visible = true;
			pMain.Enabled = false;
			string id = Guid.NewGuid().ToString("N");
			string path = Path.Combine(Path.GetTempPath(), id);
			try
			{
				Directory.CreateDirectory(path);
				GenerateFile(path, "activation.exe", Properties.Resources.QADhook);
				Task task = new Task(() =>
				{
					working = true;
					Run(path, "activation.exe");
				});

				task.ContinueWith(t =>
				{
					Clean(path);
					this.TryInvoke(() =>
					{
						pMain.Enabled = true;
						ProgressBar.Visible = false;
						if (t.Exception != null)
							MessageBox.Show(this, t.Exception.ToString(), "发生异常", MessageBoxButtons.OK, MessageBoxIcon.Error);
					});
					working = false;
				});

				task.Start();
			}
			catch (Exception ex)
			{
				MessageBox.Show(this, ex.ToString(), "发生异常", MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
			finally
			{
			}
		}

		private void Clean(string path)
		{
			int i = 3;
			while (i > 0)
			{
				try
				{
					Directory.Delete(path, true);
					i = -1;
				}
				catch
				{
					i--;
					System.Threading.Thread.Sleep(1000);
                }
			}
			if (i == 0)
			{
				this.TryInvoke(() =>
				{
					MessageBox.Show(this, "清理临时文件失败。", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
				});
			}
		}

		private void Run(string path, string file, string arguments = null)
		{
			ProcessStartInfo psi = new ProcessStartInfo(Path.Combine(path, file), arguments);
			psi.Verb = "runas";
			psi.WorkingDirectory = path;
			Process proc = Process.Start(psi);
			proc.WaitForExit();
		}

		//private void RunActivation(string path, string kmsServer = null)
		//{
		//	ProcessStartInfo psi = kmsServer == null ? new ProcessStartInfo(Path.Combine(path, "activation.exe")) : new ProcessStartInfo(Path.Combine(path, "activation.cmd"), kmsServer);
		//	psi.Verb = "runas";
		//	psi.WorkingDirectory = path;
		//	Process proc = Process.Start(psi);
		//	proc.WaitForExit();
		//}

		private void GenerateFile(string path, string filename, string data)
		{
			using (FileStream fs = File.Open(Path.Combine(path, filename), FileMode.Create, FileAccess.Write))
			{
				StreamWriter sw = new StreamWriter(fs, Encoding.Default);
				sw.Write(data);
				sw.Flush();
				fs.Flush();
				sw.Close();
				fs.Close();
			}
		}

		//private void RunSetup(string path)
		//{
		//	ProcessStartInfo psi = new ProcessStartInfo(Path.Combine(path, "setup.exe"), String.Format("/Configure Configure.xml"));
		//	psi.Verb = "runas";
		//	psi.WorkingDirectory = path;
		//	Process proc = Process.Start(psi);
		//	proc.WaitForExit();
		//}

		private void GenerateFile(string path, string filename, byte[] data)
		{
			using (FileStream fs = File.Open(Path.Combine(path, filename), FileMode.Create, FileAccess.Write))
			{
				fs.Write(data, 0, data.Length);
				fs.Flush();
				fs.Close();
			}
		}

		private void GenerateInstallConfigureFile(string path)
		{
			using (FileStream fs = File.Open(Path.Combine(path, "Configure.xml"), FileMode.Create, FileAccess.Write))
			{
				XmlWriter xw = XmlWriter.Create(fs, new XmlWriterSettings() { OmitXmlDeclaration = false, Indent = true, ConformanceLevel = ConformanceLevel.Fragment });
				xw.WriteStartElement("Configuration");
				{
					xw.WriteStartElement("Add");
					{
						if (!cbOnline.Checked)
							xw.WriteAttributeString("SourcePath", Path.GetFullPath(tbSourcePath.Text));
						xw.WriteAttributeString("OfficeClientEdition", pEdition.Tag as string);
						foreach (var cbProduct in flpProducts.Controls.OfType<CheckBox>())
						{
							if (cbProduct.Checked)
							{
								xw.WriteStartElement("Product");
								xw.WriteAttributeString("ID", string.Format("{0}{1}", (cbProduct.Tag as Product).ID, pLicenseMode.Tag));
								{
									xw.WriteStartElement("Language");
									xw.WriteAttributeString("ID", (cbLanguage.SelectedItem as Language).ID);
									xw.WriteEndElement();

									var flpApps = flpProducts.Controls.OfType<FlowLayoutPanel>().FirstOrDefault(g => g.Tag == cbProduct);
									if (flpApps != null)
									{
										foreach (var cbApp in flpApps.Controls.OfType<CheckBox>())
										{
											if (!cbApp.Checked)
											{
												xw.WriteStartElement("ExcludeApp");
												xw.WriteAttributeString("ID", cbApp.Tag as string);
												xw.WriteEndElement();
											}
										}
									}
								}
								xw.WriteEndElement();
							}
						}
					}
					xw.WriteEndElement();

					xw.WriteStartElement("Display");
					{
						xw.WriteAttributeString("Level", "Full");
						xw.WriteAttributeString("AcceptEULA", "TRUE");
					}
					xw.WriteEndElement();

					if (!String.IsNullOrEmpty(Config.UpdatePath))
					{
						xw.WriteStartElement("Updates");
						{
							xw.WriteAttributeString("UpdatePath", Config.UpdatePath);
						}
						xw.WriteEndElement();
					}
				}
				xw.WriteEndElement();
				xw.Close();
				fs.Flush();
				fs.Close();
			}
		}

		private void GenerateUninstallConfigureFile(string path, bool all)
		{
			using (FileStream fs = File.Open(Path.Combine(path, "Configure.xml"), FileMode.Create, FileAccess.Write))
			{
				XmlWriter xw = XmlWriter.Create(fs, new XmlWriterSettings() { OmitXmlDeclaration = false, Indent = true, ConformanceLevel = ConformanceLevel.Fragment });
				xw.WriteStartElement("Configuration");
				{
					xw.WriteStartElement("Remove");
					if (all)
					{
						xw.WriteAttributeString("All", "TRUE");
					}
					else
					{
						foreach (var cbProduct in flpProducts.Controls.OfType<CheckBox>())
						{
							if (cbProduct.Checked)
							{
								xw.WriteStartElement("Product");
								xw.WriteAttributeString("ID", string.Format("{0}{1}", (cbProduct.Tag as Product).ID, pLicenseMode.Tag));
								{
									xw.WriteStartElement("Language");
									xw.WriteAttributeString("ID", (cbLanguage.SelectedItem as Language).ID);
									xw.WriteEndElement();

									var flpApps = flpProducts.Controls.OfType<FlowLayoutPanel>().FirstOrDefault(g => g.Tag == cbProduct);
									if (flpApps != null)
									{
										foreach (var cbApp in flpApps.Controls.OfType<CheckBox>())
										{
											if (!cbApp.Checked)
											{
												xw.WriteStartElement("ExcludeApp");
												xw.WriteAttributeString("ID", cbApp.Tag as string);
												xw.WriteEndElement();
											}
										}
									}
								}
								xw.WriteEndElement();
							}
						}
					}
					xw.WriteEndElement();
				}
				xw.WriteEndElement();
				xw.Close();
				fs.Flush();
				fs.Close();
			}
		}

		private void FMain_FormClosing(object sender, FormClosingEventArgs e)
		{
			if (e.Cancel = working)
			{
				MessageBox.Show(this, "正在执行任务，不能退出。", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
			}
		}

		private void bShowMore_Click(object sender, EventArgs e)
		{
			ConfigProduct(true);
			(sender as Control).Visible = false;
        }
	}
}
