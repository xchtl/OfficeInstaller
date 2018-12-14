using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;

namespace OfficeInstaller.Configuration
{
	public class OfficeInstallerConfiguration : ConfigurationSection
	{
		[ConfigurationProperty("edition", IsRequired = false, DefaultValue = Edition.x86)]
		public Edition Edition
		{
			get { return (Edition)this["edition"]; }
			set { this["edition"] = value; }
		}

		[ConfigurationProperty("licenseMode", IsRequired = false, DefaultValue = LicenseMode.Retail)]
		public LicenseMode LicenseMode
		{
			get { return (LicenseMode)this["licenseMode"]; }
			set { this["licenseMode"] = value; }
		}

		[ConfigurationProperty("sourcePath", IsRequired = false, DefaultValue = ".\\")]
		public string SourcePath
		{
			get { return (string)this["sourcePath"]; }
			set { this["sourcePath"] = value; }
		}

		[ConfigurationProperty("activationServer", IsRequired = false)]
		public string ActivationServer
		{
			get { return (string)this["activationServer"]; }
			set { this["activationServer"] = value; }
		}

		[ConfigurationProperty("updatePath", IsRequired = false)]
		public string UpdatePath
		{
			get { return (string)this["updatePath"]; }
			set { this["updatePath"] = value; }
		}

		[ConfigurationProperty("products")]
		public ConfigurationElementCollection<ProductConfigurationElement> Products
		{
			get { return (ConfigurationElementCollection<ProductConfigurationElement>)this["products"]; }
		}

		[ConfigurationProperty("languages")]
		public LanguagesConfigurationElement Languages
		{
			get { return (LanguagesConfigurationElement)this["languages"]; }
		}
	}
}
