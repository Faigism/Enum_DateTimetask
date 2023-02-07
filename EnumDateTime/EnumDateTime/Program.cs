using System;
using System.Data;

namespace EnumDateTime
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Group[] gr = new Group[0];
            string op;
            do
            {
                Console.WriteLine("1. Qrup elave et");
                Console.WriteLine("2. Qruplara bax");
                Console.WriteLine("3. Type deyerine gore qruplara bax");
                Console.WriteLine("4. Bugunedek baslamis qruplara bax");
                Console.WriteLine("5. Son 2 ayda baslamis qruplara bax");
                Console.WriteLine("6. Bu ayın sonunadək yeni başlayacaq olan qruplara bax");
                Console.WriteLine("7. Verilmiş 2 tarix aralığnda başlamış olan qruplara bax");
                Console.WriteLine("0. Menudan cix");
                op = Console.ReadLine();

                switch (op)
                {
                    case "1":
                        Console.WriteLine("No:");
                        string no = Console.ReadLine();

                        Console.WriteLine("Type:");
                        foreach (var item in Enum.GetValues(typeof(GroupType)))
                        {
                            Console.WriteLine($"{(byte)item} - {item}");
                        }
                        string typeStr;
                        byte typeByte;
                        do
                        {
                            typeStr = Console.ReadLine();
                            typeByte = Convert.ToByte(typeStr);
                        } while (!Enum.IsDefined(typeof(GroupType),typeByte));
                        GroupType type = (GroupType)typeByte;

                        Console.WriteLine("Date:");
                        string dateStr = Console.ReadLine();
                        DateTime date = Convert.ToDateTime(dateStr);
                        Group gr2 = new Group()
                        {
                            No = no,
                            Type = type,
                            StartDate = date,
                        };
                        Array.Resize(ref gr, gr.Length + 1);
                        gr[gr.Length - 1] = gr2;
                        break;
                    case "2":
                        foreach (Group item in gr)
                        {
                            Console.WriteLine($"No: {item.No} - Type: {item.Type} - Date: {item.StartDate.ToString("dd.MM.yyyy HH:mm")}");
                        }
                        break;
                    case "3":
                        Console.WriteLine("Type deyeri daxil edin:");
                        typeStr = Console.ReadLine();
                        typeByte = Convert.ToByte(typeStr);
                        type = (GroupType)typeByte;
                        foreach (Group item in gr)
                        {
                            if (item.Type == type)
                            {
                                Console.WriteLine($"No: {item.No} - Type: {item.Type} - Date: {item.StartDate.ToString("dd.MM.yyyy HH:mm")}");
                            }
                        }
                        break;
                    case"4":
                        foreach (Group item in gr)
                        {
                            if (item.StartDate < DateTime.Now)
                            {
                                item.ShowInfo();
                            }
                        }
                        break;
                    case "5":
                        foreach (Group item in gr)
                        {
                            if (item.StartDate < DateTime.Now && item.StartDate>=DateTime.Now.AddMonths(-2))
                            {
                                item.ShowInfo();
                            }
                        }
                        break;
                    case "6":
                        foreach (Group item in gr)
                        {
                            //if (item.StartDate > DateTime.Now && )
                            //{
                            //    item.ShowInfo();
                            //}
                        }
                        break;
                    case "7":
                        Console.WriteLine("1-ci Tarixi qeyd edin");
                        string dateTime1=Console.ReadLine();
                        DateTime Date1=Convert.ToDateTime(dateTime1);

                        Console.WriteLine("2-ci Tarixi qeyd edin");
                        string dateTime2=Console.ReadLine();
                        DateTime Date2=Convert.ToDateTime(dateTime2);

                        foreach (Group item in gr)
                        {
                            if (item.StartDate > Date1 && item.StartDate < Date2)
                            {
                                item.ShowInfo();
                            }
                        }
                        break;
                    case "0":
                        Console.WriteLine("Program bitdi..");
                        break;
                    default:
                        Console.WriteLine("Yanlis secim etdiniz yeniden daxil edin");
                        break;
                }
            } while (op != "0");
        }
    }
}
