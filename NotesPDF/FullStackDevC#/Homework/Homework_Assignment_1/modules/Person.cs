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
            if(course.CourseCode == AddCourse.CourseCode){
                return false;
            }
        }
        StudentsCourse.Add(AddCourse);
        return true;
    }

    public void List_All_Courses(){
        int i =1;
        foreach(var course in StudentsCourse){
            Console.WriteLine($"{i}: {course.CourseToString()}");
        }
    }

    public void ModifyStudent(){
        Console.WriteLine("Would You Like To Modify The Name or Grade Level");
        if(Console.ReadLine().ToUpper() == "NAME"){
            Console.WriteLine("Enter The New Student Name");
            PersonName = Console.ReadLine();
        }
        else{
            Console.WriteLine("Enter Freshman, Softmore, Junior, or Senior");
            switch(Console.ReadLine().ToUpper()){
                case "SENIOR":
                    GradeLevel = Classification.Senior;
                    break;

                case "JUNIOR":
                    GradeLevel = Classification.Junior;
                    break;

                case "SOFTMORE":
                    GradeLevel = Classification.Softmore;
                    break;

                default:
                    GradeLevel = Classification.Freshman;
                    break;
            }
        }
    }

    public enum Classification{
        Freshman,
        Softmore,
        Junior,
        Senior
    } 

}