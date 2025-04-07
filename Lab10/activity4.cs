using System;
namespace oops
{
    class Student
    {
        // Properties
        public string Name { get; set; }
        public int ID { get; set; }
        public double Marks { get; set; }

        // Default constructor
        public Student()
        {
            Name = "Unknown";
            ID = 0;
            Marks = 0.0;
        }

        // Parameterized constructor
        public Student(string name, int id, double marks)
        {
            Name = name;
            ID = id;
            Marks = marks;
        }

        // Copy constructor
        public Student(Student other)
        {
            Name = other.Name;
            ID = other.ID;
            Marks = other.Marks;
        }

        // Method to get grade based on marks
        public string GetGrade()
        {
            if (Marks >= 90)
                return "A";
            else if (Marks >= 80)
                return "B";
            else if (Marks >= 70)
                return "C";
            else if (Marks >= 60)
                return "D";
            else
                return "F";
        }

        // Method to display student details
        public virtual void DisplayDetails()
        {
            Console.WriteLine("Student Details:");
            Console.WriteLine($"Name: {Name}");
            Console.WriteLine($"ID: {ID}");
            Console.WriteLine($"Marks: {Marks}");
            Console.WriteLine($"Grade: {GetGrade()}");
        }

        // Demo method instead of Main
        public static void DemoStudent()
        {
            // Create a student object
            Student student1 = new Student("Jiya Desai", 22110107, 85.5);

            // Display student details
            student1.DisplayDetails();

            // Create another student using copy constructor
            Student student2 = new Student(student1);
            student2.Name = "Shrishti Mishra";
            student2.ID = 22110246;

            // Display copied student details
            Console.WriteLine("\nCopied and Modified Student:");
            student2.DisplayDetails();
        }
    }

    class StudentIITGN : Student
    {
        // Additional property
        public string Hostel_Name_IITGN { get; set; }

        // Default constructor
        public StudentIITGN() : base()
        {
            Hostel_Name_IITGN = "Chimair"; // by default :)
        }

        // Parameterized constructor
        public StudentIITGN(string name, int id, double marks, string hostelName)
            : base(name, id, marks)
        {
            Hostel_Name_IITGN = hostelName;
        }

        // Override display method to include hostel information
        public override void DisplayDetails()
        {
            base.DisplayDetails();
            Console.WriteLine($"Hostel: {Hostel_Name_IITGN}");
        }

        // Demo method for StudentIITGN
        public static void DemoStudentIITGN()
        {
            // Create IITGN student object
            StudentIITGN studentIITGN = new StudentIITGN("Sujal Patel", 22110261, 92.5, "Jurqia");

            // Display IITGN student details
            studentIITGN.DisplayDetails();
        }

        // Main method - single entry point for the program
        public static void Main(string[] args)
        {

            Console.WriteLine("Demonstrating Student Class:");
            Student.DemoStudent();
            Console.WriteLine("Demonstrating StudentIITGN Class:");
            StudentIITGN.DemoStudentIITGN();
            Console.ReadKey();
        }
    }
}
