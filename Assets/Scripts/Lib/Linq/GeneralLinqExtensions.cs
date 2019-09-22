using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Scripts.Lib.Linq
{
	public static class GeneralLinqExtensions
	{
		public static TValue TryGetValueOrDefault<TKey, TValue>(this Dictionary<TKey, TValue> dict, TKey keyToCheck, TValue defaultValue = default)
		{
			TValue result = defaultValue;

			if (!dict.TryGetValue(keyToCheck, out result))
			{
				result = defaultValue;
			}

			return result;
		}
	}
}
