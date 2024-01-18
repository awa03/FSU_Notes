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
                course.AddStudent(GetStudent());
            }
        }
    }

    public bool Remove_From_Course(string? courseCode, string? studentName)
    {
        foreach (var course in CourseList)
        {
            if (course.CourseCode == courseCode)
            {
                return course.RemoveStudent(GetStudent());
            }
        }
        return false;
    }

    private Person GetStudent()
    {
        Console.WriteLine("Enter The Student Name");

        int i = 0;
        foreach (var student in StudentList)
        {
            Console.WriteLine($"{i + 1}: {student.PersonName}, {student.GradeLevel}");
            i++;
        }

        // Ensure Return Is Not Out Of Bounds
        if (Convert.ToInt32(Console.ReadLine()) < i)
        {
            return StudentList[i - 1];
        }
        // Default Return 
        else
        {
            return new Person() { PersonName = "Default", GradeLevel = Person.Classification.Freshman };
        }
    }
}
