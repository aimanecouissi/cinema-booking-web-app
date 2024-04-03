using System.ComponentModel.DataAnnotations;
using System.Reflection;

namespace CineAimane.Helpers
{
	public static class EnumHelper
	{
		public static string GetDisplayName(this Enum @enum)
		{
			return @enum.GetType()?.GetMember(@enum.ToString())?.First()?.GetCustomAttribute<DisplayAttribute>()?.GetName() ?? string.Empty;
		}
	}
}
