using Assignment6AirlineReservation;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Text;
using System.Windows.Threading;
using static Assignment5.Game;

namespace Assignment5
{
    internal static class Game
    {
        /// <summary>
        /// The math operation currently being used
        /// </summary>
        private static GameType gameType;
        /// <summary>
        /// Tracks how long they have been playing
        /// </summary>
        private static DispatcherTimer timer = new DispatcherTimer();
        /// <summary>
        /// Tracks when they start the game
        /// </summary>
        private static DateTime startTime;
        /// <summary>
        /// Records when the game is ended
        /// </summary>
        private static DateTime endTime;
        /// <summary>
        /// Counts how many questions they have gotten right so far
        /// </summary>
        private static int score = 0;
        /// <summary>
        /// Counts the current question we are on
        /// </summary>
        private static int questionNum = -1;
        /// <summary>
        /// An array of all questions for this game
        /// </summary>
        private static question[] questions = new question[10];

        /// <summary>
        /// Sets up the game by resetting values and creating new questions
        /// </summary>
        /// <param name="type"></param>
        public static void startGame(GameType type)
        {
            try
            {
                gameType = type;

                // reset all data
                timer = new DispatcherTimer();
                startTime = new DateTime();
                endTime = new DateTime();
                score = 0;
                questionNum = -1;
                questions = new question[10];

                // Set up all game quesions
                Random random = new Random();
                for (int i = 0; i < 10; i++)
                {
                    int num1 = random.Next(1, 11);
                    int num2 = random.Next(1, 11);

                    switch (gameType)
                    {
                        case (GameType.ADDITION):
                            questions[i] = new question(num1, num2, num1 + num2);
                            break;
                        case (GameType.SUBTRACTION):
                            if (num1 >= num2) questions[i] = new question(num1, num2, num1 - num2);
                            else questions[i] = new question(num2, num1, num2 - num1);
                            break;
                        case (GameType.MULTIPLICATION):
                            questions[i] = new question(num1, num2, num1 * num2);
                            break;
                        case (GameType.DIVISION):
                            questions[i] = new question(num1 * num2, num1, num2);
                            break;
                    }
                }
            }
            catch (Exception ex) 
            { 
                ErrorHandling.throwError(MethodInfo.GetCurrentMethod(), ex);
            }
        }

        /// <summary>
        /// Starts the game timer
        /// </summary>
        /// <param name="onTimer"></param>
        public static void setTimer(EventHandler onTimer)
        { 
            try { 
                // Start the timer
                startTime = DateTime.Now;
                timer = new DispatcherTimer();
                timer.Interval = TimeSpan.FromSeconds(1);
                timer.Tick += onTimer;
                timer.Start();
            }
            catch (Exception ex)
            {
                ErrorHandling.throwError(MethodInfo.GetCurrentMethod(), ex);
            }
        }

        /// <summary>
        /// Records the end of the game and ends the game timer
        /// </summary>
        public static void endGame()
        {
            try { 
                endTime = DateTime.Now;
                timer.Stop();
            }
            catch (Exception ex)
            {
                ErrorHandling.throwError(MethodInfo.GetCurrentMethod(), ex);
            }
        }

        /// <summary>
        /// Returns how long the player took to play the game
        /// </summary>
        /// <returns></returns>
        public static TimeSpan getGameTime()
        {
            TimeSpan gameTime = TimeSpan.Zero;
            try { 
                gameTime = endTime - startTime;
            }
            catch (Exception ex)
            {
                ErrorHandling.throwError(MethodInfo.GetCurrentMethod(), ex);
            }
            return gameTime;
        }

        /// <summary>
        /// Returns how long it has been since they started the game
        /// </summary>
        /// <returns></returns>
        public static TimeSpan getCurrentTime()
        {
            TimeSpan gameTime = TimeSpan.Zero;
            try
            {
                gameTime = DateTime.Now - startTime;
            }
            catch (Exception ex)
            {
                ErrorHandling.throwError(MethodInfo.GetCurrentMethod(), ex);
            }
            return gameTime;
        }

        /// <summary>
        /// Returns how many questions they have gotten right
        /// </summary>
        /// <returns></returns>
        public static int gameScore()
        {
            try
            {
                return score;
            }
            catch (Exception ex)
            {
                ErrorHandling.throwError(MethodInfo.GetCurrentMethod(), ex);
            }
            return 0;
        }

        /// <summary>
        /// Returns true and increases their score if the answer is correct
        /// Returns false if it is incorrect
        /// </summary>
        /// <param name="answer"></param>
        /// <returns></returns>
        public static Boolean checkAnswer(int answer)
        {
            try
            {
                if (answer == questions[questionNum].getSolution())
                {
                    score++;
                    return true;
                }
            }
            catch (Exception ex)
            {
                ErrorHandling.throwError(MethodInfo.GetCurrentMethod(), ex);
            }
            return false;
        }

        /// <summary>
        /// Returns an array of 2 integers with the 2 operands for the next question
        /// </summary>
        /// <returns></returns>
        public static int[] nextQuestion()
        {
            try
            {
                questionNum++;
                int[] operands = { questions[questionNum].getFirstOperand(), questions[questionNum].getSecondOperand() };
                return operands;
            }
            catch (Exception ex)
            {
                ErrorHandling.throwError(MethodInfo.GetCurrentMethod(), ex);
            }
            return new int[2];
        }

        /// <summary>
        /// Returns the game type for the operator of this game
        /// </summary>
        /// <returns></returns>
        public static GameType getGameType() 
        {
            try
            {
                return gameType;
            }
            catch (Exception ex)
            {
                ErrorHandling.throwError(MethodInfo.GetCurrentMethod(), ex);
            }
            return GameType.ADDITION;
        }

        /// <summary>
        /// Returns the number of the question they are currently on
        /// </summary>
        /// <returns></returns>
        public static int getQuestionNum() 
        { 
            try
            {
                return questionNum;
            }
            catch (Exception ex)
            {
                ErrorHandling.throwError(MethodInfo.GetCurrentMethod(), ex);
            }
            return 0;
        }

        /// <summary>
        /// An enum that holds the 4 operators this game might use
        /// </summary>
        public enum GameType
        {
            ADDITION, SUBTRACTION, MULTIPLICATION, DIVISION
        }

        /// <summary>
        /// A class holding the questions for the game
        /// </summary>
        private class question {
            /// <summary>
            /// The first operator. The X in X + Y = Z
            /// </summary>
            private int operator1;
            /// <summary>
            /// The second operator. The Y in X + Y = Z
            /// </summary>
            private int operator2;
            /// <summary>
            /// The answer. The Z in X + Y = Z
            /// </summary>
            private int solution;

            /// <summary>
            /// Creates a new question
            /// </summary>
            /// <param name="operator1"></param>
            /// <param name="operator2"></param>
            /// <param name="solution"></param>
            public question(int operator1, int operator2, int solution)
            {
                try
                {
                    this.operator1 = operator1;
                    this.operator2 = operator2;
                    this.solution = solution;
                }
                catch (Exception ex)
                {
                    ErrorHandling.throwError(MethodInfo.GetCurrentMethod(), ex);
                }
            }

            /// <summary>
            /// Returns the first operand
            /// </summary>
            /// <returns></returns>
            public int getFirstOperand() 
            { 
                try
                {
                    return operator1;
                }
                catch (Exception ex)
                {
                    ErrorHandling.throwError(MethodInfo.GetCurrentMethod(), ex);
                }
                return 0;
            }

            /// <summary>
            /// Returns the second operand
            /// </summary>
            /// <returns></returns>
            public int getSecondOperand() 
            { 
                try
                {
                    return operator2;
                }
                catch (Exception ex)
                {
                    ErrorHandling.throwError(MethodInfo.GetCurrentMethod(), ex);
                }
                return 0;
            }

            /// <summary>
            /// Returns the answer to the question
            /// </summary>
            /// <returns></returns>
            public int getSolution() 
            { 
                try
                {
                    return solution;
                }
                catch (Exception ex)
                {
                    ErrorHandling.throwError(MethodInfo.GetCurrentMethod(), ex);
                }
                return 0;
            }

        }

    }
}
