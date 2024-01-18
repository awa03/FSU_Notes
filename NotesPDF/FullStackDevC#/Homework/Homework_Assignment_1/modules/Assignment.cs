class Date{
    public int hour{
        get;
        set;
    }
    public int? minute{
        get; 
        set;
    }

    public int? day{
        get; 
        set;
    }

    public int? month{
        get; 
        set;
    }

    public int? year{
        get; 
        set;
    }

    public Date(){}

    public string DateToString(){
        // 3:45 1/2/23 - Example
        return $"{hour}:{minute} {month}/{day}/{year}";
    }


}

class Assignment{
    public string? AssignmentName{
        get; 
        set;
    }
    public string? AssignmentDesc{
        get; 
        set;
    }
    public int? AvailablePoints{
        get;
        set;
    }
}