using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;

namespace OfficeInstaller.Configuration
{
	public class LanguagesConfigurationElement : ConfigurationElementCollection<LanguageConfigurationElement>
	{
		[ConfigurationProperty("default", IsRequired = false, DefaultValue ="zh-CN")]
		public string Default
		{
			get { return (string)this["default"]; }
			set { this["default"] = value; }
		}
    }
}
