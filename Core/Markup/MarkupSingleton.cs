using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Markup;

namespace Core.Markup
{
	public class MarkupSingleton : MarkupExtension
	{
		private static Dictionary<Type, object> cache = new Dictionary<Type, object>();
		public override object ProvideValue(IServiceProvider serviceProvider)
		{
			var type = GetType();
			if (!cache.ContainsKey(type))
			{
				var constructors = type.GetConstructors();
				var instance = constructors.First().Invoke(null);
				cache.Add(type, instance);
			}
			return cache[type];
		}
	}
}
