using System.Linq.Expressions;
class Course {
    public Course(){
        Assignments = new List<Assignment>(){};
        CourseRoster = new List<Person>(){};
        Modules = new List<Module>(){};
        CourseID = Guid.NewGuid();
    }

    // Course Code For Identifying Indivdual Course
    public string? CourseCode{ 
        get;
        set;
    }
    public Guid CourseID{
        get;
        private set;
    }
    // Name of the Course
    public string? CourseName{
        get;
        set;
    }
    // Course Description
    public string? CourseDescription{
        get;
        set;
    }
    // List of students in the course
    private List<Person> CourseRoster;
    // List of Assignments
    public List<Assignment> Assignments{
        get; set;
    }
    // List of course modules
    private List<Module> Modules;

    
    public void AddStudent(Person student){
        CourseRoster.Add(student);
    }

    // abstracted for future use... 
    public bool RemoveStudent(Person student){
        foreach(var roster_student in CourseRoster){
            if(roster_student == student){
                CourseRoster.Remove(student);
                return true;
            }
        }
        return false;
    }
    
    public void ChangeInfo(){
        Console.WriteLine("Would You Like To Change The Name Or Description");
        if(Console.ReadLine().ToUpper() == "NAME"){
            Console.WriteLine("Enter New Course Name");
            CourseName = Console.ReadLine();
        }
        else{
            Console.WriteLine("Enter New Course Description");
            CourseDescription = Console.ReadLine();
        }
    }

    public string? CourseToString(){
        return $"{CourseCode}, {CourseName}\n {CourseDescription}";
    }

    public Assignment CreateAssignment(string assignmentName, string assignmentDesc, int availablePoints, Date dueDate){
        // Create New Assignment with variables added
        Assignment newAssignment = new Assignment(){
            AssignmentName = assignmentName, 
            AssignmentDesc = assignmentDesc, 
            AvailablePoints = availablePoints, 
            AssignmentDueDate = dueDate
        };
        
        Assignments.Add(newAssignment);
        return newAssignment;
    }

    public void ViewStudents(){
        int i =1;
        foreach(var student in CourseRoster){
            Console.WriteLine($" {i} : {student.Student_To_String()}");
            i++;
        }
    }
}