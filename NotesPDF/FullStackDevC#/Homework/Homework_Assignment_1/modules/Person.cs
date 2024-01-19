class Person{
    public Person(){
        StudentsCourse = new List<Course>(){};
    }
    public string? PersonName{
        get;
        set;
    }

    public Classification GradeLevel{
        get;
        set;
    }

    public string? Student_To_String(){
        return $"{PersonName}, {GradeLevel.ToString()}";
    }

    public List<Course> StudentsCourse;

    public bool AddCourse(Course AddCourse){
        foreach(var course in StudentsCourse){
            if(course == AddCourse){
                return false;
            }
        }
        StudentsCourse.Add(AddCourse);
        return true;
    }

    public void List_All_Courses(){
        foreach(var course in StudentsCourse){
            Console.WriteLine(course.CourseToString());
        }
    }

    public enum Classification{
        Freshman,
        Softmore,
        Junior,
        Senior
    } 

}