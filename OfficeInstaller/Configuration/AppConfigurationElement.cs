using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;

namespace OfficeInstaller.Configuration
{
	public class AppConfigurationElement : ConfigurationElement, IConfigurationElementCollectionItem
	{
		[ConfigurationProperty("id", IsRequired = true)]
		public string ID
		{
			get { return (string)this["id"]; }
			set { this["id"] = value; }
		}

		public object Key
		{
			get
			{
				return ID;
			}
		}

		[ConfigurationProperty("name", IsRequired = true)]
		public string Name
		{
			get { return (string)this["name"]; }
			set { this["name"] = value; }
		}

		[ConfigurationProperty("checked", IsRequired = false, DefaultValue = false)]
		public bool Checked
		{
			get { return (bool)this["checked"]; }
			set { this["checked"] = value; }
		}
	}
}
