using System;
using System.Collections.Generic;

class Canvas
{
    // Constructor
    public Canvas()
    {
        StudentList = new List<Person>();
        CourseList = new List<Course>();
    }

    private List<Person> StudentList;
    private List<Course> CourseList;

    public bool AddCourse(string? courseName, string? courseCode, string? courseDescription)
    {
        foreach (var course in CourseList)
        {
            if (course.CourseName == courseName || course.CourseCode == courseCode)
            {
                return false; // error course already present
            }
        }

        // Make The New Course
        Course NewCourse = new Course()
        {
            CourseName = courseName,
            CourseCode = courseCode,
            CourseDescription = courseDescription
        };

        CourseList.Add(NewCourse); // Add To The Roster
        return true;
    }

    public void CreateStudent(string? Name, Person.Classification gradeLevel)
    {
        Person NewStudent = new Person() { PersonName = Name, GradeLevel = gradeLevel };
        StudentList.Add(NewStudent); // Add the new student to the list
    }

    public void Add_Student_To_Course(string? CourseCode)
    {
        
        foreach (var course in CourseList)
        {
            if (course.CourseCode == CourseCode)
            {
                Person Student = GetStudent();
                course.AddStudent(Student);
                Student.AddCourse(course);
            }
        }
    }

    public bool RemoveStudentFromCourse(string? courseCode)
    {
        var course = CourseList.FirstOrDefault(c => c.CourseCode == courseCode);
        return course?.RemoveStudent(GetStudent()) ?? false;
    }

    public void List_All_Courses(){
        Console.WriteLine("\n");
        foreach(var course in CourseList){
            Console.WriteLine($"{course.CourseToString()}\n");
        }
    }

    public void Search_For_Course(string? CourseName){
        Console.WriteLine("\n");
        foreach(var course in CourseList){
            if(course.CourseName == CourseName){
                Console.WriteLine($"{course.CourseToString()}\n");
            }
        }
    }

    public void Search_For_Course_By_Desc(string? CourseDescription){
        Console.WriteLine("\n");
        foreach(var course in CourseList){
            if(course.CourseDescription == CourseDescription){
                Console.WriteLine($"{course.CourseToString()}\n");
            }
        }
    }

    public void List_All_Students(){
        foreach(var student in StudentList){
            Console.WriteLine(student.PersonName);
        }
    }

    public Person Get_Student_By_Name(string? StudentName){
        foreach(var student in StudentList){
            if(student.PersonName == StudentName){
                Console.WriteLine("Student Found");
                Console.WriteLine($"Student Info : {student.Student_To_String()}");
                return student;
            }
        }
        Console.WriteLine("No Student Found By That Name");
        return new Person(){}; // return null on no student found 
    }


    public Person GetStudent()
    {
        Console.WriteLine("Enter The Student Number: ");

        int i = 0;
        foreach (var student in StudentList)
        {
            Console.WriteLine($"{i + 1}: {student.PersonName}, {student.GradeLevel}");
            i++;
        }

        
        // Ensure Return Is Not Out Of Bounds
        int UserInput = Convert.ToInt32(Console.ReadLine());
        if (UserInput < i+1)
        {
            return StudentList[UserInput - 1];
        }
        // Default Return 
        else
        {
            Console.WriteLine("Invalid Input Returning Default Student");
            return new Person() { PersonName = "Default", GradeLevel = Person.Classification.Freshman };
        }
    }

    public void List_All_Courses_Student_Taking(){
        Person SearchStudent = GetStudent();
        foreach(var student in StudentList){
            if(student == SearchStudent){
                student.List_All_Courses();
            }
        }
    }

    public bool UpdateCourseInfo(string? CourseCode){
        foreach(var course in CourseList){
            if(course.CourseCode == CourseCode){
                course.ChangeInfo();
                return true;
            }
        }
        Console.WriteLine("Course Not Found");
        return false;
    }

    public void Update_Student_Info(){
        Person Student = GetStudent();
        Student.ModifyStudent();
    }

    public bool Create_Assignment(string? courseCode){
        foreach(var course in CourseList){
            if(course.CourseCode == courseCode){
                var PromptResponse = AssignmentPrompt();
                course.CreateAssignment(PromptResponse.Item1, PromptResponse.Item2, PromptResponse.Item3, PromptResponse.Item4);
                return true;
            }
        }
        
        return false; // Base Case
    }

    public void View_Course_Info(){
        Course SelectedCourse = SelectCourse();
        Console.WriteLine(SelectedCourse.CourseToString());
        SelectedCourse.ViewStudents();
    }

    public bool Set_Assignment_Grade_For_Student(Person? student, string? CourseCode, string? AssignmentName, Grade assignmentGrade)
    {
        if (student != null && CourseCode != null && AssignmentName != null)
        {
            IEnumerable<Course> result = student.StudentsCourse.Where(
                t =>
                    t.CourseCode != null && t.CourseCode.ToUpper().Contains(CourseCode.ToUpper())
            );


            if (result.Any())
            {
                Course studentCourse = result.First();

                IEnumerable<Assignment> assignmentsToModify = studentCourse.Assignments.Where(
                    c =>
                        c.AssignmentName != null && c.AssignmentName.ToUpper().Contains(AssignmentName.ToUpper())
                );

                foreach (var assignmentToModify in assignmentsToModify)
                {
                    assignmentToModify.AssignementGrade = assignmentGrade;
                }

                return true;
            }
        }

        return false;
    }



    public void View_Student_Grades(Person? StudentName){
        StudentName.View_Student_Grades();
    }

    private Course SelectCourse(){
        Console.WriteLine("Enter Course Number in the List: ");

        int i = 0;
        foreach (var course in CourseList)
        {
            Console.WriteLine($"{i + 1}: {course.CourseName}, {course.CourseCode}");
            i++;
        }

        
        // Ensure Return Is Not Out Of Bounds
        int UserInput = Convert.ToInt32(Console.ReadLine());
        if (UserInput < i+1)
        {
            return CourseList[UserInput - 1];
        }
        // Default Return 
        else
        {
            Console.WriteLine("Invalid Input Returning Default Student");
            return new Course(){}; // Default Return - Base Case
        }
    }

    private (string?, string?, int, Date?) AssignmentPrompt(){
        Console.WriteLine("Enter The Name Of The Assignment");
        string Name = Console.ReadLine();
        
        Console.WriteLine("Enter The Description Of The Assignment");
        string Desc = Console.ReadLine();

        Console.WriteLine("Enter The Possible Points");
        int availablePoints = int.Parse(Console.ReadLine());

        Date userDate = new Date();

        // Prompt the user for input
        Console.Write("Enter hour: ");
        userDate.hour = int.Parse(Console.ReadLine());

        Console.Write("Enter minute (press Enter for none): ");
        string minuteInput = Console.ReadLine();
        userDate.minute = Convert.ToInt32(minuteInput);

        Console.Write("Enter day (press Enter for none): ");
        string dayInput = Console.ReadLine();
        userDate.day = Convert.ToInt32(dayInput);

        Console.Write("Enter month (press Enter for none): ");
        string monthInput = Console.ReadLine();
        userDate.month = Convert.ToInt32(monthInput);

        Console.Write("Enter year (press Enter for none): ");
        string yearInput = Console.ReadLine();
        userDate.year = Convert.ToInt32(yearInput);

        return (Name, Desc, availablePoints, userDate);
    }


    



    

    

}
