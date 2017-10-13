/*
 * Class:       Deck
 * Description: This class models a deck of playing cards, of any size, but has been updated to include methods specific to a game of Go Fish.
 *              A deck of cards is defined as a List of Card objects.  This class contains methods get the number of cards in the deck,
 *              add and remove cards from the deck, shuffling, sorting, and viewing the cards in the deck.  This class has a specific 
 *              method, HasBook(), that will check to see if a deck contains four of a kind.
 * 
 * Author:      Aaron Baker, Tampa, FL, 2017
 */

using System;
using System.Collections.Generic;

namespace Go_Fish
{
	class Deck
	{
		private List<Card> cards; // this is a deck of playing cards
		private Random random = new Random( ); // random used to shuffle deck

		// The Count property simple returns the number of Card objects contained in the deck.
		public int Count { get { return cards.Count; } }

		// This is the constructor for a full deck of cards.  Each deck contains 52 cards - 4 suits and 13 cards (Ace - King) per suit.
		// Each card has two numerical values.  The first defines its suit and the second its value.
		public Deck()
		{
			cards = new List<Card>();
			for (int suit = 0; suit <= 3; suit++)
			{
				 for (int value = 1; value <= 13; value++)
				{
					cards.Add( new Card( (Suits) suit , (Values) value ) );	 
				}
			}
		}

		// This overloaded constructor builds a new deck of cards from the list of initialCards (ex. a player's hand).
		public Deck( IEnumerable<Card> initialCards )
		{
			cards = new List<Card>( initialCards );
		}


		// The Add method simply adds a card to the deck.
		public void Add( Card card )
		{
			cards.Add( card );
		}


		// This method rearranges the cards in a random order.
		// A card is randomly removed from the existing deck and placed into a new one.  This repeats until no cards are left 
		// in the original deck.  The object reference for the original deck is set to the new, shuffled deck.
		public void Shuffle( )
		{
			List<Card> shuffledDeck = new List<Card>( );
			while ( cards.Count > 0 )
			{
				int moveCard = random.Next( cards.Count );
				shuffledDeck.Add( cards[ moveCard ] );
				cards.RemoveAt( moveCard );
			}
			cards = shuffledDeck;
		}


		// This method simply iterates through the deck of cards and stores the name of each card in an
		// array which it then returned.  IEnumerable is used so that cards can be sorted by their names.
		public IEnumerable<string> GetCardNames( )
		{
			string[ ] cardNames = new string[ cards.Count ]; // array will hold all cards in the deck
			for ( int i = 0; i < cards.Count; i++ )
			{
				cardNames[ i ] = cards[ i ].Name;
			}
			return cardNames;
		}


		// This method sorts the cards by their suit and then by their value.
		public void Sort( )
		{
			cards.Sort( new CardComparer_bySuit( ) );
		}


		// The Deal method deals the card located at the specified index in the cards list.
		public Card Deal( int index )
		{
			Card dealCard = cards[ index ];
			cards.RemoveAt( index );
			return dealCard;
		}


		// This overloaded Deal method simply deals the card from the top of the deck if no 
		// index is specified.
		public Card Deal( )
		{
			return Deal( 0 );
		}


		// Peek at one of the cards in the deck.
		public Card Peek( int cardNumber )
		{
			return cards[ cardNumber ];
		}


		// The ContainsValue method searches through the entire deck of cards for a card that matches
		// the desired value.  Return true if card is found and false if not.
		public bool ContainsValue( Values value )
		{
			foreach ( Card card in cards )
			{
				if ( card.Value == value )
					return true;
			}
			return false;
		}


		// The PullOutValues pulls all of the cards matching the specified value out of the deck and places
		// them in a new deck which is then returned.
		public Deck PullOutValues( Values value )
		{
			// Create the deck to be returned
			Deck returnDeck = new Deck( new Card[ ] { } );
			// Go through the entire deck and if a matching card is found add it to the returnDeck
			for ( int i = cards.Count - 1; i >= 0; i-- )
			{
				if ( cards[i].Value == value )
				{
					returnDeck.Add( Deal( i ) );
				}
			}

			return returnDeck;
		}


		// The HasBook method checks a deck of cards to see if it contains a set of four cards of a matching value (a book).
		public bool HasBook( Values value )
		{
			int numberOfCards = 0;
			// Go through the entire deck of cards and count the number of cards that match the specified value.
			foreach ( Card card in cards )
			{
				if ( card.Value == value )
					numberOfCards++;
			}
			// If four matching cards are found the deck contains a complete book of that card.
			if ( numberOfCards == 4 )
				return true;
			else
				return false;	
		}


		// This sorts the cards in the deck by their numerical values, and then but their suit.
		public void SortByValue( )
		{
			cards.Sort( new CardComparer_byValue( ) );
		}


		// This sorts the cards in the deck by their suits, and then by value.
		public void SortBySuit( )
		{
			cards.Sort( new CardComparer_bySuit( ) );
		}

	} // end Deck class
}
