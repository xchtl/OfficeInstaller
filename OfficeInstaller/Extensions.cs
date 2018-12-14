using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using System.Text;

namespace System.Windows.Forms
{
	public static class Extensions
	{
		public static void TryInvoke(this Control control, Action action)
		{
			if (control.InvokeRequired)
			{
				control.Invoke(action);
			}
			else
				action();
		}

		public static T TryInvoke<T>(this Control control, Func<T> action)
		{
			if (control.InvokeRequired)
			{
				return (T)control.TryInvoke(new Func<T>(action));
			}
			else
				return action();
		}

		public static string GetDescription(this Enum obj)
		{
			string objName = obj.ToString();
			Type t = obj.GetType();
			FieldInfo fi = t.GetField(objName);

			DescriptionAttribute[] arrDesc = (DescriptionAttribute[])fi.GetCustomAttributes(typeof(DescriptionAttribute), false);
			if (arrDesc != null && arrDesc.Length > 0)
				return arrDesc[0].Description;
			else
				return obj.ToString();
		}
	}
}
