using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;

namespace OfficeInstaller.Configuration
{
	public class ProductConfigurationElement : ConfigurationElement, IConfigurationElementCollectionItem
	{
		[ConfigurationProperty("id", IsRequired = true)]
		public string ID
		{
			get { return (string)this["id"]; }
			set { this["id"] = value; }
		}

		[ConfigurationProperty("name", IsRequired = true)]
		public string Name
		{
			get { return (string)this["name"]; }
			set { this["name"] = value; }
		}

		[ConfigurationProperty("applications")]
		public ConfigurationElementCollection<AppConfigurationElement> Applications
		{
			get { return (ConfigurationElementCollection<AppConfigurationElement>)this["applications"]; }
		}

		public object Key
		{
			get
			{
				return ID;
			}
		}

		[ConfigurationProperty("licenseMode", IsRequired = false, DefaultValue = LicenseMode.All)]
		public LicenseMode LicenseMode
		{
			get { return (LicenseMode)this["licenseMode"]; }
			set { this["licenseMode"] = value; }
		}

		[ConfigurationProperty("checked", IsRequired = false, DefaultValue = false)]
		public bool Checked
		{
			get { return (bool)this["checked"]; }
			set { this["checked"] = value; }
		}

		[ConfigurationProperty("hide", IsRequired = false, DefaultValue = false)]
		public bool Hide
		{
			get { return (bool)this["hide"]; }
			set { this["hide"] = value; }
		}
	}
}
