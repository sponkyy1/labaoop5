using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.ComponentModel.DataAnnotations;
//Один з методів індивідуального завдання зробити віртуальним. 
//Сумарна кількість слухачів, день з найбільшою кількістю слухачів, довжина прізвища
namespace laba5._1
{
    abstract class Poet
    {

        public string surname; //ім'я         
        public string language;     // вік         
        public int number_of_collections;

        public virtual int Get_Lengths(string Surname)
        {
            int k = 0;
            return k;
        }

        abstract public string Day_of_larges_number(int a, int b, string c);
    }
    //---------------------------------------------------------------------------------------------
    class Speech : Poet//, IComparable<Speech>
    {
        const int f_name = 20;
        public string date;
        public int place;
        public int number_of_listeners;

        public Speech(string S, string L, int NC, string D, int P, int NL)
        {
            surname = S;
            language = L;
            number_of_collections = NC;
            date = D;
            place = P;
            number_of_listeners = NL;
        }
        public int Compare(string surname) // порівняння прізвища         
        {
            return (string.Compare(this.surname, 0, surname + " ", 0, surname.Length + 1, StringComparison.OrdinalIgnoreCase));
        }
        public Speech(string s)
        {
            surname = s.Substring(0, f_name);
            language = (s.Substring(f_name, 7));
            number_of_collections = Convert.ToInt32(s.Substring(f_name + 7, 5));
            date = (s.Substring(f_name + 12, 8));
            place = Convert.ToInt32(s.Substring(f_name + 20, 3));
            number_of_listeners = Convert.ToInt32(s.Substring(f_name + 23));
            if (number_of_collections < 0) throw new FormatException();
            if (place < 0) throw new FormatException();
            if (number_of_listeners < 0) throw new FormatException();
        }
        public override string ToString()
        {
            return string.Format("Surname: {0,20} Language: {1:20,27} Number_of_collections: {2} Date: {3:32,41}  Place: {4} Number_of_listeners: {5} ", surname, language, number_of_collections, date, place, number_of_listeners);
        }

        public int Number_of_listeners
        {
            get { return number_of_listeners; }
            set
            {
                if (value > 0) number_of_listeners = value;
                else throw new FormatException();
            }
        }
        public string Date
        {
            get { return date; }
            set { date = value; }
        }

        public int Sumaty_number_of_listeners(int a)
        {
            int max = 0;
            max += a;
            return max;
        }

        public override string Day_of_larges_number(int a, int b, string c)
        {
            string max = "";
            if (b > a)
            {
                a = b;
                max = c;
            }

            return max;
        }

        public override int Get_Lengths(string Surname)
        {
            int k = 0;
            for (int i = 0; i <= Surname.Length; i++)
            {
                if (Surname == "/n")
                {
                    break;
                }
                k++;
            }
            k = k - 1;
            return k;
        }

    }
    class Adddel
    {
        public void AppendAllText(string path, string contents)
        {
            if (!File.Exists(path))
            {
                string createText = "Hello and Welcome" + Environment.NewLine;
                File.WriteAllText(path, createText);
            }

            string append = "\n";
            File.AppendAllText(path, append);
            File.AppendAllText(path, contents);
            string readText = File.ReadAllText(path);
            Console.WriteLine(readText);
            Console.WriteLine("Text add to file");
        }
        public void Delete(string path, int line)
        {
            if (!File.Exists(path))
            {
                string createText = "Hello and Welcome" + Environment.NewLine;
                File.WriteAllText(path, createText);
            }
            string[] fileLines = File.ReadAllLines(path);
            fileLines[line] = String.Empty; // deleting
            File.WriteAllLines(path, fileLines);
            string readText = File.ReadAllText(path);
            Console.WriteLine(readText);
            Console.WriteLine("Text delete to file");
        }
    }
    class Program
    {
        static void Main(string[] args)
        {

            List<Speech> list = new List<Speech>();
            int n = 0;
            StreamReader f = new StreamReader("dbase.txt");
            string s;
            int i = 0;
            try
            {
                while ((s = f.ReadLine()) != null)
                {
                    list.Add(new Speech(s));
                    ++i;
                }
                n = i - 1;


                foreach (var element in list)
                {
                    Console.WriteLine(element);
                }
                f.Close();
            }
            catch (FileNotFoundException e)
            {
                Console.WriteLine(e.Message);
                Console.WriteLine("Check the correct name and path to the file!");
                return;
            }
            catch (IndexOutOfRangeException)
            {
                Console.WriteLine("Very large file!");
                return;
            }
            catch (Exception e)
            {
                Console.WriteLine("Error: " + e.Message); return;
            }
            Console.WriteLine("Enter text for The total number of listeners:");
            string namee;
            while ((namee = Console.ReadLine()) != "")
            {
                int max = 0;
                bool not_found = true;
                for (int k = 0; k <= n; ++k)
                {
                    Speech pers = list[k];
                    int a = pers.Number_of_listeners;
                    max += pers.Sumaty_number_of_listeners(a);
                    not_found = false;
                }
                Console.WriteLine("The total number of listeners: ");
                Console.WriteLine(max);
                if (not_found)
                {
                    Console.WriteLine("There is no such information");
                }
            }


            Console.WriteLine("Enter text for date with the largest number of listeners:");
            string na;
            while ((na = Console.ReadLine()) != "")
            {
                bool not_found = true;
                Speech perss = list[0];
                int a = perss.Number_of_listeners;
                string max = "";
                for (int k = 0; k <= n; ++k)
                {

                    Speech pers = list[k];
                    int b = pers.Number_of_listeners;
                    string c = pers.Date;
                    max += pers.Day_of_larges_number(a, b, c);
                    if (max != "")
                    {
                        break;
                    }
                    not_found = false;
                }
                Console.WriteLine(max);
                if (not_found)
                {
                    Console.WriteLine("There is no such information");
                }
            }


            Console.WriteLine("Enter text to find out thr length of the Surname:");
            string name;
            while ((name = Console.ReadLine()) != "")
            {
                bool not_found = true;
                for (int k = 0; k <= n; ++k)
                {
                    Speech pers = list[k];
                    if (pers.Compare(name) == 0)
                    {
                        Console.WriteLine(pers);
                        int a = pers.Get_Lengths(name);
                        Console.WriteLine(a);
                        not_found = false;
                    }
                }
                if (not_found)
                {
                    Console.WriteLine("There is no such information");
                }
                Console.WriteLine("Enter the file creation_date for which you want to know the information Enter to complete");
            }
            Console.WriteLine("Enter text if you want to add a line in database: ");
            string names;
            while ((names = Console.ReadLine()) != "")
            {
                Adddel add = new Adddel();
                Console.WriteLine("Enter the line you want to delete: ");
                string numberOfLineToAdd = Console.ReadLine();
                add.AppendAllText("dbase.txt", numberOfLineToAdd);
            }


            Console.WriteLine("Enter text if you want to delete a line in database: ");
            string nam;
            while ((nam = Console.ReadLine()) != "")
            {
                Adddel del = new Adddel();
                Console.WriteLine("Enter the line you want to delete: ");
                int numberOfLineToDelete = Convert.ToInt32(Console.ReadLine());
                del.Delete("dbase.txt", numberOfLineToDelete);
            }
        }
    }
}

