/*
 *	Class:          Game
 *	Description:    This class contains all of the logic for a game of Go Fish.  There are fields to track the players, which books (sets of 4 cards) have been completed,
 *                  the stockDeck (draw pile), and a reference to the text box that the game information will be displayed in.  There are methods to deal the first hand, 
 *               	play a round of Go Fish, remove any completed book, indicate which players have which books, and to determine who won the game.
 * 
 *	Author:         Aaron Baker, Tampa, FL, 2017
 */

using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace Go_Fish
{
	class Game
	{
		private List<Player> players; // this is a list of all of the players
		private Dictionary<Values , Player> completeBooks; // contains information on all of the completed book - which card values are out of play and which player has the book
		private Deck stockDeck; // this is the pile of cards that can be drawn from
		private TextBox textOnForm; // a reference to the text box on the form which will be updated with the current state of the game
		private Player user; // a reference to the players item that contains the user's info

		// This class has a single contructor which requires the user's name, any enumerable collection of opponent names, and a 
		// reference to the form's text box that will show the current state of the game.  All players are created at this time and all
		// fields are initialized.  A fresh, complete deck of cards is created as the stockDeck pile, and then is dealt to all players.  The player's
		// hand is also sorted by card value.
		public Game(string playerName, IEnumerable<string> opponentNames, TextBox gameProgress)
		{
			// Initialize fields
			players = new List<Player>( );
			completeBooks = new Dictionary<Values , Player>( );
			stockDeck = new Deck( );
			textOnForm = gameProgress;

			Random random = new Random( ); // random object must be passed to all Players

			// Create the players
			players.Add( new Player( playerName , random , textOnForm ) ); // the user is the first player in the list
			user = players[ 0 ];

			foreach ( string player in opponentNames ) // initialize the oppenents
			{
				players.Add( new Player( player , random , textOnForm ) );
			}

			DealFirstHand( );

			user.SortHand( );
		}


		// This method only runs when the game is first started.  The stockDeck is shuffled and five cards are dealt to each player.
		// If any player was lucky enough to be dealt a complete book they will remove it at this time.
		public void DealFirstHand( )
		{ 
			// Shuffle the deck...
			stockDeck.Shuffle( );
			// ... and deal five cards to each player.
			for ( int i = 0; i < 5; i++ )
			{
				foreach ( Player player in players )
				{
					player.TakeCard( stockDeck.Deal( ) ); // each player takes the top card from the stockDeck deck
				}
			}
			// Each player pulls out any complete books if they were lucky enough to be dealt one.
			foreach ( Player player in players )
			{
				player.RemoveBooks( );
			}
		}


		// This method runs through one round of Go Fish and uses the card that the player selected from their hand.  The user asks for the
		// selected card from the other players while the opponents request a random card.
		// If the stockDeck is out of cards the game is over and the method returns true.  Otherwise it returns false and the game continues.
		public bool PlayOneRound( int selectedCard )
		{
			

			// Go through all players and have them ask for a card.
			for ( int i = 0; i < players.Count; i++ )
			{
				if ( i == 0 ) // players[0] is the user
				{
					Values cardAskedFor = user.Peek( selectedCard ).Value;
					user.AskForACard( players , i , stockDeck, cardAskedFor ); // users ask for the specific card
				}
				else
				{
					players[ i ].AskForACard( players , i , stockDeck ); // opponents ask for a random card
				}

				// Each player pulls out any completed books.  If PullOutBooks returns true the player is out of cards
				// and they need to draw a new hand from the stock.
				if ( PullOutBooks(players[i]) )
				{
					textOnForm.Text += players[ i ].Name + " draws a new hand." + Environment.NewLine; // ex. Bob draws a new hand.
					int card = 1;
					// Draw five cards from the top of the deck or until their are no more cards to draw.
					while ( card <= 5 && stockDeck.Count > 0 )
					{
						players[ i ].TakeCard( stockDeck.Deal( ) );
						card++;
					}
				}

				// If the stockDeck is out of cards the game is over
				if ( stockDeck.Count == 0 )
				{
					textOnForm.Text = "There are no more cards in the draw pile." + Environment.NewLine;
					textOnForm.Text += "Game over!" + Environment.NewLine;
					return true;
				}
			}

			// Once all players have completed their turn the user's hand is sorted...
			user.SortHand( );
			// ...and the method returns false indicating that the game can continue.
			return false;
		} // end PlayOneRound method


		// This method pulls any complete books out of a player's hand and adds that book to the Game's completeBooks dictionary.
		// Return true if there are no more cards left in the player's hand.
		public bool PullOutBooks( Player player )
		{
			// Use the Player RemoveBooks method to search through the player's hand and remove any completed books.
			// The method returns a list of Values of the books that were found.
			IEnumerable<Values> booksPulled = player.RemoveBooks( );
			// Add each completed book to the completeBooks dictionary tracked by the game.
			foreach ( Values value in booksPulled )
			{
				completeBooks.Add( value , player );
			}
			// If the player is out of cards return true.
			if ( player.CardCount == 0 )
				return true;
			else
				return false;
		}


		// This method describes the books that have been completed based on what is contained in the completeBooks dictionary.
		// It outputs a single string, however, each book description is written on a new line.
		public string DescribeBooks( )
		{
			string booksDescription = "";
			// The completeBooks dictionary stores the card value as the key and the player as the value.
			// Go through the completeBooks and determine which player has which books.
			// Each description is on its own line.
			foreach ( Values value in completeBooks.Keys )
			{
				booksDescription += completeBooks[ value ].Name + " has a book of " + Card.Plural( value ) + "." + Environment.NewLine;
			}
			return booksDescription;
		}


		// This method is run when the game has ended.  It goes through the completeBooks dictionary to determine which player(s) had the most
		// books and then returns a string indicating who won and with how many books, and will indicate if the game ended in a tie.
		public string GetWinnerName( )
		{
			Dictionary<string, int> booksPerPlayer = new Dictionary<string,int>(); // this dictionary will hold the player name and the number of book they have

			// Go through the completeBooks dictionary to see which players have which books
			foreach ( Values value in completeBooks.Keys )
			{
				// Get the name of the player for the book
				string name = completeBooks[ value ].Name;
				// If booksPerPlayer already has this name increment their book total.
				// Otherwise add that name to booksPerPlayer.
				if ( booksPerPlayer.ContainsKey(name) )
				{
					booksPerPlayer[ name ]++;
				}				
				else
				{
					booksPerPlayer.Add( name , 1 ); // this is the first book the player has claimed
				}
			}
			
			// Go through booksPerPlayer to determine the highest number of book held by a player.
			int mostBooks = 0;
			foreach ( string name in booksPerPlayer.Keys )
			{
				if ( mostBooks < booksPerPlayer[ name ] )
					mostBooks = booksPerPlayer[ name ];
			}

			// Then determine which player had the mostBooks.
			// Since there is the possibility of a tie the name of each winner with mostBooks will be stored in a list.
			List<string> winners = new List<string>( ); ;
			// Go through each name in booksPerPlayer and see if that player had mostBooks.
			foreach ( string name in booksPerPlayer.Keys )
			{
				// If they did then the name needs to be added winners list.
				if ( booksPerPlayer[ name ] == mostBooks )
				{
					winners.Add( name );
				}
			}

			// Now that we have the winner(s) create the message indicating who the winner(s) were.
			// Add the first name to the message.
			string winnersMessage = winners[ 0 ];
			// If there was a tie...
			if ( winners.Count > 1 )
			{
				// ...add the other winner(s)
				for (int i = 1; i < winners.Count; i++)
				{
					winnersMessage += " and " + winners[ i ];
				}				
			}
			// Include how many books they won with.
			winnersMessage += " won the game with " + mostBooks + " books." + Environment.NewLine;
			// If there was a tie add that information to the message.
			if ( winners.Count > 1 )
			{
				winnersMessage += "There was a tie between " + winners[0];
				for ( int i = 1; i < winners.Count; i++ )
				{
					winnersMessage += " and " + winners[ i ];
				}				
			}

			return winnersMessage;
		} // end GetWinnerName method


		// This method gets the names of the cards in the player's deck
		public IEnumerable<string> GetPlayerCardNames( )
		{
			return players[ 0 ].GetCardNames( );
		}


		// Display the number of cards held by each player and number of cards still in the stockDeck pile.
		public string DescribeHands( )
		{
			string description = "";
			for ( int i = 0; i < players.Count; i++ )
			{
				description += players[ i ].Name + " has " + players[ i ].CardCount;
				if ( players[ i ].CardCount > 1 )
					description += " cards." + Environment.NewLine;
				else
					description += " card." + Environment.NewLine;
			}
			description += "There are still " + stockDeck.Count + " cards in the stock pile." + Environment.NewLine;
			return description;
		}

	} // end Game class
}
