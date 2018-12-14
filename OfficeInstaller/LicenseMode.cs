using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;

namespace OfficeInstaller
{
	[Flags]
	public enum LicenseMode
	{
		[Description("无")]
		None = 0,

		[Description("零售")]
		Retail = 1,

		[Description("批量")]
		Volume = 2,

		[Description("全部")]
		All = Retail | Volume
	}
}
