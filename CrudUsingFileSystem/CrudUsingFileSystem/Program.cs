using System;
using TeacherRecordLibrary;

namespace TeacherRecordApp
{
    class Program
    {
        static void Main(string[] args)
        {

            TeacherDataHandler teacherDataHandler = new TeacherDataHandler();
            bool isContinue = true;

            while (isContinue)
            {
                Console.WriteLine("Enter your preference: 1) Create Teacher Record 2) Read Teacher Record  3) Update Teacher Record");
                string selectedOption = Console.ReadLine();
                switch (selectedOption)
                {
                    case "1":
                        teacherDataHandler.AddTeacher();
                        Console.WriteLine("Record added!");
                        isContinue = Confirmation();
                        break;

                    case "2":
                        teacherDataHandler.DisplayTeacher();
                        isContinue = Confirmation();
                        break;

                    case "3":
                        teacherDataHandler.UpdateTeacher();
                        isContinue = Confirmation();
                        Console.WriteLine("Record updated successfully");
                        break;

                    default:
                        Console.WriteLine("Invalid option. Please choose 1, 2, or 3.");
                        isContinue = Confirmation();
                        break;
                }
            }
        }

        public static bool Confirmation()
        {
            Console.WriteLine("Do you want to Continue (yes/no)?:");
            string confirmationResult = Console.ReadLine();

            if (confirmationResult == "yes" || confirmationResult == "y" || confirmationResult == "YES" || confirmationResult == "Yes" || confirmationResult == "Y")
            {
                return true;
            }
            else if (confirmationResult == "no" || confirmationResult == "n" || confirmationResult == "NO" || confirmationResult == "N" || confirmationResult == "No")
            {
                return false;
            }
            else
            {
                Console.WriteLine("Please enter valid input");
                return Confirmation();
            }
        }
    }
}
