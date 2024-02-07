using System;
using System.Collections.Generic;
using System.IO;

namespace TeacherRecordLibrary
{
    public class TeacherDataHandler : ITeacherDataHandler 
    {
        public void AddTeacher()
        {
            FileStream fs = new FileStream("TeacherRecord.txt", FileMode.Append, FileAccess.Write);
            StreamWriter sw = new StreamWriter(fs) { AutoFlush = true };

            Console.WriteLine("Enter the ID of the teacher");
            int id = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Enter the Name of the teacher");
            string Name = Console.ReadLine();
            Console.WriteLine("Enter the Class of the teacher");
            string Class = Console.ReadLine();

            sw.WriteLine($"ID:{id}, Name: {Name}, Class: {Class}");
            sw.Close();
            fs.Close();
        }
        public void DisplayTeacher()
        {
            FileStream fs = new FileStream("TeacherRecord.txt", FileMode.Open, FileAccess.Read);
            StreamReader sr = new StreamReader(fs);
            string contents = sr.ReadToEnd();
            Console.WriteLine(contents);
            sr.Close();
            fs.Close();
        }

        public void UpdateTeacher()
        {
            string filePath = "TeacherRecord.txt";

            string[] allLines = File.ReadAllLines(filePath);

            Console.WriteLine("Enter the ID of the teacher to update:");
            int idToUpdate = Convert.ToInt32(Console.ReadLine());

            bool teacherFound = false;

            List<string> updatedData = new List<string>();

            foreach (string line in allLines)
            {
                string[] parts = line.Split(',');

                int id = 0;
                id = Convert.ToInt32(parts[0].Substring(3));
                if (id == idToUpdate)
                {
                    Console.WriteLine("Enter the new Name of the teacher:");
                    string newName = Console.ReadLine();
                    Console.WriteLine("Enter the new Class of the teacher:");
                    string newClass = Console.ReadLine();
                    
                    updatedData.Add($"ID:{id}, Name: {newName}, Class: {newClass}");
                    teacherFound = true;
                }
                else
                {
                    updatedData.Add(line);
                }
            }

            if (!teacherFound)
            {
                Console.WriteLine($"Teacher with ID {idToUpdate} not found.");
                return;
            }

            // Write the updated data back to the file
            File.WriteAllLines(filePath, updatedData);

            Console.WriteLine("Teacher updated successfully.");
            
        }



    }
}
