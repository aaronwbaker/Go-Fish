/*
 * Class:       CardComparer_bySuit
 * Description: This class defines the method for comparing playing cards by their suit, and then by their value.
 * Author:      Aaron Baker, Tampa, FL, 2017
 */

using System.Collections.Generic;

namespace Go_Fish
{
	// This class defines the method for comparing playing cards by their suit, and then by their value.
	class CardComparer_bySuit : IComparer<Card>
	{
		// A card is defined by two numerical values, its Suit which can be between 0 and 3, and its Value
		// which can be between 1 and 13.  Return 1 or -1 indicating if Card A is higher or lower than Card B
		// or return 0 if they are equivalent (i.e. the same card).
		public int Compare( Card a , Card b )
		{
			if ( a.Suit > b.Suit )
				return 1;
			if ( a.Suit < b.Suit )
				return -1;
			if ( a.Value > b.Value )
				return 1;
			if( a.Value < b.Value )
				return -1;
			else
				return 0;
		}
	}
}
