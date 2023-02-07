using System;
using System.Collections.Generic;
using System.Text;

namespace EnumDateTime
{
    internal class Group
    {
        public string No;
        public GroupType Type;
        public DateTime StartDate;

        public void ShowInfo()
        {
            Console.WriteLine($"No: {No} - Type: {Type} - StartDate: {StartDate.ToString("dd.MM.yyyy HH:mm")}");
        }
    }
}
