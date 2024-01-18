class Course {
    public Course(){
        Assignments = new List<>(){};
    }

    // Course Code For Identifying Indivdual Course
    public string? CourseCode{ 
        get;
        set;
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
    private List<Assignment> Assignments;
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
}