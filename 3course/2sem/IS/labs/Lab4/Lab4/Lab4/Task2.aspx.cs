using System;
using System.Collections.Generic;
using System.Web.UI.WebControls;

namespace Lab4
{
    public partial class Task2 : System.Web.UI.Page
    {
        protected void DateOfBirthValidator_ServerValidate(object source, ServerValidateEventArgs args)
        {
            string selectedDateStr = args.Value;
            DateTime selectedDateTemp = DateTime.Parse(selectedDateStr);
            DateTime today = DateTime.Now;

            DateTime currentDate = new DateTime(today.Year, today.Month, today.Day);
            DateTime selectedDate = new DateTime(selectedDateTemp.Year, selectedDateTemp.Month, selectedDateTemp.Day);

            int result = currentDate.CompareTo(selectedDate);

            args.IsValid = result == 1 ? true : false;
        }

        protected void PasswordLengthCustomValidator_ServerValidate(object source, ServerValidateEventArgs args)
        {
            string password = args.Value;
            if (password == null || password.Length < 7)
                args.IsValid = false;
            else
                args.IsValid = true;
        }

        protected void UniqueSymbolsInPasswordValidator_ServerValidate(object source, ServerValidateEventArgs args)
        {
            var password = args.Value;

            if (password == null)
                args.IsValid = false;
            else
            {
                Dictionary<char, bool> dictionary = new Dictionary<char, bool>();
                for (var z = 0; z < password.Length; ++z)
                {
                    var symbol = password[z];
                    if (dictionary.ContainsKey(symbol))
                    {
                        args.IsValid = false;
                        return;
                    }
                    else
                        dictionary[symbol] = true;
                }
                args.IsValid = true;
            }
        }
    }
}