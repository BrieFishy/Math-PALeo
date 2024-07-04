using Assignment6AirlineReservation;
using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Linq;
using System.Media;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Assignment5
{
    /// <summary>
    /// Interaction logic for GameWindow.xaml
    /// </summary>
    public partial class GameWindow : Window
    {
        /// <summary>
        /// Saves the operand for this game to use in building equation strings
        /// </summary>
        private String oper;
        /// <summary>
        /// The chime sound that plays when the player answers correctly
        /// </summary>
        private SoundPlayer correctSound = new SoundPlayer(Environment.CurrentDirectory + @"\sounds\correct.wav");
        /// <summary>
        /// The drum sound that plays when the player answers incorrectly
        /// </summary>
        private SoundPlayer incorrectSound = new SoundPlayer(Environment.CurrentDirectory + @"\sounds\incorrect.wav");
        
        /// <summary>
        /// Opens the game window and initializes some variables
        /// </summary>
        public GameWindow()
        {
            try { 
                InitializeComponent();

                startButtonBorder.Visibility = Visibility.Visible;
                gameBoardStackpanel.Visibility = Visibility.Collapsed;

                switch (Game.getGameType())
                {
                    case Game.GameType.ADDITION:
                        oper= "+";
                        break;
                    case Game.GameType.SUBTRACTION:
                        oper= "−";
                        break;
                    case Game.GameType.MULTIPLICATION:
                        oper= "×";
                        break;
                    case Game.GameType.DIVISION:
                        oper= "÷";
                        break;
                }
            }
            catch (Exception ex)
            {
                ErrorHandling.handleError(MethodInfo.GetCurrentMethod(), ex);
            }
        }

        /// <summary>
        /// Called when the user clicks the button to start the game, starts the timer and shows the first question
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void startButton_Click(object sender, RoutedEventArgs e)
        {
            try { 
                // Get the first question and set it up
                setQuestion();

                // Start the timer
                Game.setTimer(new EventHandler(onTimer));

                startButtonBorder.Visibility = Visibility.Collapsed;
                gameBoardStackpanel.Visibility = Visibility.Visible;
            }
            catch (Exception ex)
            {
                ErrorHandling.handleError(MethodInfo.GetCurrentMethod(), ex);
            }
        }

        /// <summary>
        /// Gets the next question and displays it
        /// </summary>
        private void setQuestion()
        {
            try
            {
                int[] operands = Game.nextQuestion();
                equationLabel.Content = operands[0] + " " + oper + " " + operands[1] + " =";
            }
            catch (Exception ex)
            {
                ErrorHandling.throwError(MethodInfo.GetCurrentMethod(), ex);
            }
        }

        /// <summary>
        /// Updates the timer on the screen every second
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void onTimer(object sender, EventArgs e)
        {
            try { 
                string timer = Game.getCurrentTime().ToString();
                timerLabel.Content = timer.Substring(1, timer.IndexOf('.') - 1);
            }
            catch (Exception ex)
            {
                ErrorHandling.handleError(MethodInfo.GetCurrentMethod(), ex);
            }
        }

        /// <summary>
        /// When the submit button is clicked, this calls the submit method
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void submitButton_Click(object sender, RoutedEventArgs e)
        {
            try { 
                submit();
            }
            catch (Exception ex)
            {
                ErrorHandling.handleError(MethodInfo.GetCurrentMethod(), ex);
            }
        }

        /// <summary>
        /// When the enter key is pressed, this calls the submit method
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OnKeyDown(object sender, KeyEventArgs e)
        {
            try { 
                if (e.Key == Key.Return)
                {
                    submit();
                }
            }
            catch (Exception ex)
            {
                ErrorHandling.handleError(MethodInfo.GetCurrentMethod(), ex);
            }
        }

        /// <summary>
        /// Handles submitting the question. Validates user input, sees if the answer is right,
        /// then updates the GUI accordingly
        /// </summary>
        private void submit()
        {
            try
            {
                // Check if input is good
                int answer;
                string feedback;
                if (answerTextBox.Text.Length == 0 || !int.TryParse(answerTextBox.Text, out answer))
                {
                    // There was no answer or it wasn't a number
                    feedback = "Enter a number.";
                }
                else
                {
                    // check if answer is right
                    if (Game.checkAnswer(answer))
                    {
                        feedback = "Good job!";
                        correctSound.Play();
                    }
                    else
                    {
                        feedback = "Not quite right. Try another one.";
                        incorrectSound.Play();
                    }

                    // empty answer box
                    answerTextBox.Text = "";

                    // Next question
                    if (Game.getQuestionNum() < 9)
                        setQuestion();
                    // If the game is over, close this window
                    else
                    {
                        Game.endGame();
                        this.Hide();
                        new FinalScore().ShowDialog();
                    }
                }
                // Update feedback 
                feedbackLabel.Content = feedback;
            }
            catch (Exception ex)
            {
                ErrorHandling.throwError(MethodInfo.GetCurrentMethod(), ex);
            }

        }

        /// <summary>
        /// Closes this window when the exit button is clicked
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void exitButton_Click(object sender, RoutedEventArgs e)
        {
            try { 
                this.Hide();
            }
            catch (Exception ex)
            {
                ErrorHandling.handleError(MethodInfo.GetCurrentMethod(), ex);
            }
        }

    }
}
