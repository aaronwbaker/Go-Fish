/*
 * Class:       CardComparer_byValue
 * Description: This class defines the method to compare playing cards by their value, and then by their suit.
 * Author:      Aaron Baker, Tampa, FL, 2017
 */

using System.Collections.Generic;

namespace Go_Fish
{
	// This class defined the method to compare two playing cards by their value, and then by their suit.
	class CardComparer_byValue : IComparer<Card>
	{
		// A card is defined by two numerical values, its Suit which can be between 0 and 3, and its Value
		// which can be between 1 and 13.  Return 1 or -1 indicating if Card A is higher or lower than Card B
		// or return 0 if they are equivalent (i.e. the same card).
		public int Compare( Card a , Card b )
		{
			if ( a.Value > b.Value )
				return 1;
			if ( a.Value < b.Value )
				return -1;
			if ( a.Suit > b.Suit )
				return 1;
			if ( a.Suit < b.Suit )
				return -1;
			else
				return 0;
		}
	}
}
