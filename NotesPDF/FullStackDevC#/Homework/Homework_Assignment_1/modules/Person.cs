class Person{
    public string? PersonName{
        get;
        set;
    }

    public Classification GradeLevel{
        get;
        set;
    }

    public enum Classification{
        Freshman,
        Softmore,
        Junior,
        Senior
    } 
}