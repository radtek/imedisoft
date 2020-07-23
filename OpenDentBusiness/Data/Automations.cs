using Imedisoft.Data;
using Imedisoft.Data.Cache;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Reflection;
using System.Windows.Forms;

namespace OpenDentBusiness
{
    public partial class Automations
	{
		[CacheGroup(nameof(InvalidType.Automation))]
		private class AutomationCache : ListCache<Automation>
		{
            protected override IEnumerable<Automation> Load() 
				=> SelectMany("SELECT * FROM automations");
		}

		private static readonly AutomationCache cache = new AutomationCache();

		public static List<Automation> GetDeepCopy() 
			=> cache.GetAll();

		public static Automation GetFirstOrDefault(Predicate<Automation> predicate) 
			=> cache.FirstOrDefault(predicate);

		public static void RefreshCache() 
			=> cache.Refresh();
	}
}
