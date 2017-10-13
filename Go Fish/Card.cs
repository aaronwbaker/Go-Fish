/* Class:       Card
 * Description: This class models an individual playing card.  Cards are defined by their Suit and Value (both are enums) and these properties
 *              are set when a Card is created.  Once set the properties are read only.
 *
 * Author:      Aaron Baker, Tampa, FL, 2017
*/ 

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Go_Fish
{
	class Card
	{
		public Suits Suit{ get; private set; } // may be between 0-3, settor is private as card suit defined when it is created
		public Values Value { get; private set; } // may be between 1-13, settor is private as card suit defined when it is created

		// A Card has a single constructor which requires a suit and value to be assigned as this is what defines a card.
		public Card( Suits suit , Values value )
		{
			Suit = suit;
			Value = value;
		}


		// The Name property simply returns the card as a number and suit ex. 8 of Spades.
		public string Name
		{
			get
			{
				return Value.ToString( ) + " of " + Suit.ToString( );
			}
		}


		// Override the ToString() method to have the Card return its Name.
		public override string ToString( )
		{
			return Name;
		}


		// This method formats and returns the plural for each card value - ex. Queens, Sixes.
		// Method needed as plural of six is "es" while all other cards simply have an "s" after their value.
		public static string Plural( Values value )
		{
			if ( value == Values.Six )
			{
				return "Sixes";
			}
			else
			{
				return value.ToString( ) + "s";
			}
		}

	} // end Card class
}
