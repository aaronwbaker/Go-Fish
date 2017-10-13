/*
 *	Program:	            Go Fish
 *	Program Description:    This application allows a user to play a game of Go Fish against a computer opponent.  An interactive form allows
 *	                        the user to select which card they want to request from their opponent.  The player can view their current hand as well as the
 *	                        current progress of the game on the form.  The object of the game is to get four cards of a matching value.  Four cards makes a
 *	                        book and each book is worth a point.  When there are no more cards in the community draw pile the game ends and the player with
 *	                        the most points wins.
 *	
 *	Author:	                Aaron Baker, Tampa, FL, 2017
 *	
 *	Included in Go Fish:	Card.cs
 *							CardComparer_bySuit.cs
 *							CardComparer_byValue.cs
 *							Deck.cs
 *							Player.cs
 *							Program.cs
 *							MainForm.cs
 *							Suits.cs
 *							Values.cs
 */

/* 
 * Class:   MainForm
 *          This interactive form allows a user to play a game of Go Fish against two computer opponents.  The form included information
 *          about the game and the user's hand of cards which is updated after each turn.
 */ 

using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace Go_Fish
{

	public partial class MainForm : Form
	{
		public MainForm( )
		{
			InitializeComponent( );
		}

		private Game game; // the Game class contains all of the logic for a game of Go Fish


		// This method updates the form with the current state of the game including the user's hand,
		// game progress, and books completed so far.
		private void UpdateForm( )
		{
			// Clear the previous list of cards and update it to match the player's current hand
			listHand.Items.Clear( );
			foreach ( String cardName in game.GetPlayerCardNames() )
				listHand.Items.Add( cardName );
			// Update the Complete completeBooks text box to list the completed books held by each player
			txtCompleteBooks.Text = game.DescribeBooks( );
			// Update the Game Progress text box for all players' current hands
			txtProgress.Text += game.DescribeHands( );
			// Deliniate turn info
			txtProgress.Text += "*******Turn Complete*******" + Environment.NewLine;
			// And set the initial view of the text box to display the most recent game progress
			txtProgress.SelectionStart = txtProgress.TextLength;
			txtProgress.ScrollToCaret( );			
		}


		// When the Ask button is clicked the game progresses through an entire turn.
		private void btnAsk_Click( object sender , EventArgs e )
		{
			// The player must select a card before asking the other players if they have it.  Display prompt if no selection made.
			// If a selection was made the selection is passed to the PlayOneRound method and a turn is completed.
			// If PlayOneRound returns true a player has won the game and the form is updated accordingly.
			// If no one has won the normal UpdateForm method is used to update the form to show the current state of the game.
			if ( listHand.SelectedIndex < 0 )
			{
				MessageBox.Show( "Please select a card to ask for." );
				return;
			}
			if ( game.PlayOneRound( listHand.SelectedIndex ) )
			{
				txtProgress.Text += "And the winner is..." + Environment.NewLine;
				txtProgress.Text += game.GetWinnerName( );
				txtCompleteBooks.Text = game.DescribeBooks( );
				btnAsk.Enabled = false;
				listHand.Enabled = false;
			}
			else
			{
				UpdateForm( );				
			}
		}


		// When the Start button is clicked a new game is started.
		private void btnStart_Click( object sender , EventArgs e )
		{
			// The player must enter their name before the game can start.
			if ( String.IsNullOrEmpty(txtName.Text) )
			{
				MessageBox.Show( "Please enter your name." , "We can't start the game yet..." );
				return;
			}

			// A new game object is created and the two opponents are set.
			game = new Game( txtName.Text , new List<string> { "Bri" , "Bug" } , txtProgress );

			// Enable/disable form controls as needed and update the form to show the current state of the game.
			txtName.Enabled = false; // name is locked in once the game starts
			btnStart.Enabled = false;
			listHand.Enabled = true;
			btnAsk.BackColor = Color.PaleGreen; // update the Ask button color to green when game is in progress
			btnAsk.Enabled = true;
			UpdateForm( );
		}

		private void btnQuit_Click( object sender , EventArgs e )
		{
			Close( );
		}


	} // end MainForm class
}
