using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace System.Windows.Forms
{
	public class ButtonEx : Button
	{
		public ButtonEx()
		{
			SetStyle(ControlStyles.Selectable, selectable);
			SetStyle(ControlStyles.SupportsTransparentBackColor, true);
		}

		private bool selectable = false;
		public bool Selectable
		{
			get { return selectable; }
			set
			{
				selectable = value;
				SetStyle(ControlStyles.Selectable, value);
			}
		}
	}
}
