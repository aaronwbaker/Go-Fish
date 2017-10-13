/*
 * Class:       Player
 * Description: This class models an individual playing a game of Go Fish.  It includes methods to remove completed books (four of a kind) from
 *              the player's hand, ask if other players have a card, and methods to look at the cards in the player's hand and get their information.
 *              This class also updates the game status text box on the MainForm that the user interacts with.
 * 
 * Author:      Aaron Baker, Tampa, FL, 2017
 */

using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace Go_Fish
{
	class Player
	{
		// All Player fields are private
		private Random random;
		private Deck cards;
		private TextBox textOnForm;

		// Players have two read only properties.  The Name is set when a Player is instantiated.
		public string Name { get; private set; }
		public int CardCount { get { return cards.Count; } }


		// This class has a single constructor which requires the name, random object, and text box object to be passed to it
		// from the form.  A new deck of cards is created for the player as well.  The textbox on the form is updated to show
		// that the player has joined the game.
		public Player( string name , Random random , TextBox textOnForm )
		{
			Name = name;
			this.random = random;
			this.textOnForm = textOnForm;
			cards = new Deck( new Card[]{} ); // player starts with an empty deck - Deck(args) must be used as no-arg method creates full deck of 52 cards

			textOnForm.Text += Name + " has joined the game." + Environment.NewLine;
		}


		// This method iterates through the player's deck to see if they have four cards of the same value.
		// If they do a book has been completed and will be removed from the player's hand and the textbox on the form will be updated.
		public IEnumerable<Values> RemoveBooks( )
		{ 
			List<Values> books = new List<Values>();
			// Go through the deck for each possible value of a card.
			for ( int i = 0; i <= 13; i++ )
			{
				Values value = (Values) i; // cast the number to a Value enum as each card is defined by its Suit and a Value enums
				int numMatched = 0; // number of cards with a matching value

				for ( int card = 0; card < cards.Count; card++ ) // for every card in the player's deck...
				{
					if ( cards.Peek(card).Value == value ) // ...look at the card value
					{
						numMatched++; // if it matches what we are looking for, increment numMatched
					}
					if ( numMatched == 4 ) // if there are four cards of the same value we have a completed book
					{
						textOnForm.Text += Name + " completed a book of " + Card.Plural(cards.Peek( card ).Value) + Environment.NewLine; // ex. Bob completed a book of Jacks
						books.Add( value ); // add that value to the list of completed books...
						cards.PullOutValues( value ); // ...and remove the book from the player's deck						
					}
				}
			}
			return books;
		}


		// This method returns a random Value, but the Value must match the Value of one of the cards in the player's deck.
		// The method is used by the opponents to AskForCard().
		public Values GetRandomValue( )
		{ 
			Values value = new Values(); // the value enum to be returned
			bool legalValue = false; // flag shows whether randomly generated value matches Value of a card in the player's deck

			// Generate a random Value and see if the player has a card with that Value in their deck.
			// Continue generating a random Value until a matching value card is found.
			while ( !legalValue )
			{
				Values randomValue = (Values)random.Next( 1 , 13 ); // card Values may be 1 to 13
				// go through the player's deck to see if they have a card with a matching value
				if ( cards.ContainsValue(randomValue) ) // if it does
				{
					legalValue = true; // a legal value was found
					value = randomValue; // set the value to be returned to the randomValue
				}
			}
			return value;
		}


		// This method allows an opponent to ask the player if they have any cards with a certain Value.
		// If they do the cards with the Value are pulled from the player's deck and given to the player that
		// requested them.  The text box showing the game progress is updated with the result.
		public Deck DoYouHaveAny( Values value )
		{
			Deck cardsPulled = cards.PullOutValues( value ); // this will hold the cards pulled from the player's hand - if any
			// show the cards received from the other players...
			textOnForm.Text += Name + " had " + cardsPulled.Count + " " + Card.Plural( value ) + Environment.NewLine; // ex. Bob had 3 Kings
			// ...and give them to the player that requested them
			return cardsPulled;
		}


		// This method is used by the opponents to request a random card from the other players.  The card value they request must be that 
		// of a card in their hand.
		public void AskForACard( List<Player> players , int myIndex , Deck stockDeck )
		{
			if ( stockDeck.Count > 0 ) // this ensures that none of the methods try to pull from an empty stock pile
			{
				// If a player is out of cards, and there are still cards in the stock pile, they are dealt a new hand.
				if( stockDeck.Count > 0 )
					cards.Add( stockDeck.Deal( ) );

				// Otherwise select a random card value and request that card from the other players.
				Values randomValue = GetRandomValue( );
				AskForACard( players, myIndex, stockDeck, randomValue );

				// There is the possibility that the user has their last card taken by an opponent.
				// Draw a card from the stock if that is the case.
				if ( players[0].cards.Count == 0 && stockDeck.Count > 0 )
				{
					players[ 0 ].cards.Add( stockDeck.Deal( ) );
				}
			}
		}


		// This overloaded method asks another player if they have any cards with a specific value.
		public void AskForACard( List<Player> players , int myIndex , Deck stockDeck , Values value )
		{
			// Ask the other players if they have that card.
			textOnForm.Text += Name + " asks if anyone has a " + value + ":" + Environment.NewLine;

			// Then go through the list of players and see if they do...
			int countNewCards = 0; // this will track how many cards the player receives from the others
			for ( int index = 0; index < players.Count; index++ )
			{
				if ( index != myIndex ) // a player cannot ask for a card from themself
				{
					Player player = players[ index ];
					Deck cardsToAdd = player.DoYouHaveAny( value ); // if another player has cards with the requested value they will return a deck of those cards
					countNewCards += cardsToAdd.Count; // count how many cards the player received
					// If cards were received deal them into the player's deck one by one
					while ( cardsToAdd.Count > 0 )
					{
						cards.Add( cardsToAdd.Deal( ) );
					}
				}
			}

			// If no cards were received then the player has to draw a card from the stock.
			if ( countNewCards == 0 && stockDeck.Count > 0 )
			{
				cards.Add( stockDeck.Deal( ) );
				textOnForm.Text += Name + " has to draw from the stock." + Environment.NewLine;
			}
		}


		// Add a card to the player's deck
		public void TakeCard(Card card)
		{
			cards.Add( card );	
		}


		// Get the names for all of the cards in the player's deck
		public IEnumerable<string> GetCardNames( )
		{
			return cards.GetCardNames( );
		}


		// Look at the specified card
		public Card Peek( int cardNumber )
		{
			return cards.Peek( cardNumber );
		}


		// Sort the cards in the player's deck by their value
		public void SortHand( )
		{
			cards.SortByValue( );
		}

	} // end Player class
}
