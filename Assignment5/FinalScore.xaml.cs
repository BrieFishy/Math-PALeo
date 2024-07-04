using Assignment6AirlineReservation;
using System;
using System.Collections.Generic;
using System.Linq;
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
    /// Interaction logic for FinalScore.xaml
    /// </summary>
    public partial class FinalScore : Window
    {
        /// <summary>
        /// Opens the final score window and shows the game info
        /// </summary>
        public FinalScore()
        {
            try { 
                InitializeComponent();

                // Set up the data
                playerNameLabel.Content = User.getUserName();
                playerAgeLabel.Content = "Age: " + User.getUserAge();
                string timer = Game.getGameTime().ToString();
                timerLabel.Content = timer.Substring(1, timer.IndexOf('.')-1);

                correctScore.Content = Game.gameScore() + "/10";
                incorrectScore.Content = (10 - Game.gameScore()) + "/10";
            }
            catch (Exception ex)
            {
                ErrorHandling.handleError(MethodInfo.GetCurrentMethod(), ex);
            }
        }

        /// <summary>
        /// Closes this window when the exit button is clicked
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ExitButton_Click(object sender, RoutedEventArgs e)
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
