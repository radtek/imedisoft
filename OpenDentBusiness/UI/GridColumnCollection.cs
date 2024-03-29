using System.Collections.Generic;

namespace OpenDental.UI
{
    public class GridColumnCollection : List<GridColumn>
	{
		/// <summary>
		/// Gets the index of the column with the specified heading.
		/// </summary>
		public int GetIndex(string headerText)
		{
			for (int i = 0; i < Count; i++)
			{
				if (this[i].HeaderText == headerText)
				{
					return i;
				}
			}

			return -1;
		}
	}
}
