using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OfficeInstaller
{
	class Product
	{
		public string ID { get; set; }
		public string Name { get; set; }
		public LicenseMode LicenseMode { get; set; }
	}
}
