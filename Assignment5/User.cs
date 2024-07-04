using Assignment6AirlineReservation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Documents.DocumentStructures;

namespace Assignment5
{
    internal static class User
    {
        /// <summary>
        /// Stores the player's name
        /// </summary>
        static private string name;
        /// <summary>
        /// Stores the player's age
        /// </summary>
        static private int age;
        
        /// <summary>
        /// Sets the player's name and age
        /// </summary>
        /// <param name="userName"></param>
        /// <param name="userAge"></param>
        public static void setUserInfo(string userName, int userAge) 
        {
            try
            {
                name = userName; 
                age = userAge;
            }
            catch (Exception ex)
            {
                ErrorHandling.throwError(MethodInfo.GetCurrentMethod(), ex);
            }
        }

        /// <summary>
        /// Returns the player's name
        /// </summary>
        /// <returns></returns>
        public static string getUserName () 
        { 
            try
            {
                return name;
            }
            catch (Exception ex)
            {
                ErrorHandling.throwError(MethodInfo.GetCurrentMethod(), ex);
            }
            return "error";
        }

        /// <summary>
        /// Returns the player's age
        /// </summary>
        /// <returns></returns>
        public static int getUserAge () 
        {
            try
            {
                return age; 
            }
            catch (Exception ex)
            {
                ErrorHandling.throwError(MethodInfo.GetCurrentMethod(), ex);
            }
            return 0;
        }
    }
}
