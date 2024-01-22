using System;

namespace Program{
    internal class Program{
        static string? Menu(){
            Console.WriteLine("Welcome To Canvas");
            Console.WriteLine("A - Create A Course");
            Console.WriteLine("B - Create A Student");
            Console.WriteLine("C - Add Student To Course");
            Console.WriteLine("D - Remove Student From Course");
            Console.WriteLine("E - List All Courses");
            Console.WriteLine("F - Search For Course By Name or Desc");
            Console.WriteLine("G - List All Students");
            Console.WriteLine("H - Search For A Student By Name");
            Console.WriteLine("I - List All Courses A Student Is Taking");
            Console.WriteLine("J - Update Courses Information");
            Console.WriteLine("K - Update Students Information");
            Console.WriteLine("L - Create An Assignment");
            Console.WriteLine("M - Course List?"); // come back for clarification
            Console.WriteLine("N - Clear Console");

            return (Console.ReadLine()).ToUpper();
        }
        static void Main(string[] args){
           // Temporary I/O for the project, switch + while loop
           
            string UserInput;
            bool ProgramRunning = true;
            Canvas canvas = new Canvas();
            while(ProgramRunning){
                switch (UserInput = Menu())
                {
                    case "A":
                    // Get User Input on Course Details
                        Console.WriteLine("Enter Course Name");
                        string? CourseName = Console.ReadLine();
                        Console.WriteLine("Enter Course Code");
                        string? CourseCode = Console.ReadLine();
                        Console.WriteLine("Enter Course Description");
                        string? CourseDescription = Console.ReadLine();
                        canvas.AddCourse(CourseName, CourseCode, CourseDescription);
                        break;

                    case "B":
                        Console.WriteLine("Enter The Student Name");
                        string? StudentName = Console.ReadLine();
                        Console.WriteLine("Enter Freshman, Softmore, Junior, Senior");
                        string? StudentGrade = Console.ReadLine();
                        Person.Classification grade = new Person.Classification(){};

                        // get the students grade
                        if(StudentGrade == "Senior"){grade = Person.Classification.Senior;}
                        else if(StudentGrade == "Junior"){grade = Person.Classification.Junior;}
                        else if(StudentGrade == "Softmore"){grade = Person.Classification.Softmore;}
                        else{grade = Person.Classification.Freshman;}

                        canvas.CreateStudent(StudentName ,grade);
                        break;

                    case "C":
                        Console.WriteLine("Enter Course Code");
                        canvas.Add_Student_To_Course(Console.ReadLine()); // reads in student name in the call
                        break;

                    case "D":
                        Console.WriteLine("Enter Course Code");
                        canvas.Remove_Student_From_Course(Console.ReadLine()); 
                        break;

                    case "E":
                        canvas.List_All_Courses();
                        break;

                    case "F":
                        Console.WriteLine("Would You Like To Search By Name or Desc");
                        if(Console.ReadLine() == "Name"){
                            Console.WriteLine("Enter Name");
                            canvas.Search_For_Course(Console.ReadLine());
                        }
                        else {
                            Console.WriteLine("Enter Desc");
                            canvas.Search_For_Course_By_Desc(Console.ReadLine());
                        }
                        break;
                    case "G":
                        canvas.List_All_Students();
                        break;
                    case "H":
                        Console.WriteLine("Enter Student Name");
                        // need clarification on function
                        break;
                    case "I":
                        canvas.List_All_Courses_Student_Taking();
                        break;
                    case "J":
                        Console.WriteLine("Enter Course Code");
                        canvas.UpdateCourseInfo(Console.ReadLine());
                        break;
                    case "K":
                        canvas.Update_Student_Info();
                        break;
                    case "L":
                        
                        break;
                    case "M":
                        break;
                    case "N":
                        Console.Clear();
                        break;
                    default:
                        ProgramRunning =false;
                        break;
                }   
                Console.WriteLine("\n\n");
            }
        }
    }
}