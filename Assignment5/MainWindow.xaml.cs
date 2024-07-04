using Assignment6AirlineReservation;
using System;
using System.Reflection;
using System.Windows;
using System.Windows.Input;

namespace Assignment5
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        /// <summary>
        /// Opens up the MainWindow panel
        /// </summary>
        public MainWindow()
        {
            try
            {
                InitializeComponent();

                Application.Current.ShutdownMode = ShutdownMode.OnMainWindowClose;
            } catch (Exception ex)
            {
                ErrorHandling.handleError(MethodInfo.GetCurrentMethod(), ex);
            }
        }

        /// <summary>
        /// Called when the play button is clicked. It validates all input then sets up the game and opens the GameWindow
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void PlayButton_Click(object sender, RoutedEventArgs e)
        {
            try { 
                // Validate input
                string errorMessage = "";
                string playerName = "";
                int age = -1;
                Game.GameType gameType = Game.GameType.ADDITION;
                if (NameInputTxt.Text == "" || NameInputTxt.Text == "Name")
                {
                    errorMessage = "Please Input a name";
                }
                else if (!int.TryParse(AgeInputTxt.Text, out age) || (int.TryParse(AgeInputTxt.Text, out age) && (age < 3 || age > 10)))
                {
                    errorMessage = "Input an age between 3 and 10";
                }
                else
                {
                    // Check which radioButton is selected
                    if (AddRadio.IsChecked == true) { gameType = Game.GameType.ADDITION; }
                    else if (SubRadio.IsChecked == true) { gameType = Game.GameType.SUBTRACTION; }
                    else if (MultRadio.IsChecked == true) { gameType = Game.GameType.MULTIPLICATION; }
                    else if (DivRadio.IsChecked == true) { gameType = Game.GameType.DIVISION; }
                    else { errorMessage = "Choose a game type"; }
                    playerName = NameInputTxt.Text;
                }

                if (errorMessage.Length > 0)
                {
                    // If there is an error, show it and don't move on
                    ErrorLabel.Content = errorMessage;
                    ErrorLabel.Visibility = Visibility.Visible;
                }
                else
                {
                    // If there isn't an error, start the game
                    ErrorLabel.Visibility = Visibility.Hidden;
                    // Start the game
                    Game.startGame(gameType);
                    User.setUserInfo(playerName, age);
                    // Close this window, open the other, start the game
                    this.Hide();
                    new GameWindow().ShowDialog();
                    this.Show();
                }
            }
            catch (Exception ex)
            {
                ErrorHandling.handleError(MethodInfo.GetCurrentMethod(), ex);
            }
        }
    }


}
