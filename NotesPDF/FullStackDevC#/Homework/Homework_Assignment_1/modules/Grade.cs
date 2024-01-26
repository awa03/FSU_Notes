class Grade
{
    private double _gradePercentage;

    public double GradePercentage
    {
        get
        {
            return _gradePercentage;
        }
        set
        {
            _gradePercentage = value;
            SetLetterGrade();
        }
    }

    public LetterGrade letterGrade
    {
        get;
        private set;
    }

    private void SetLetterGrade()
    {
        if (_gradePercentage >= 90)
        {
            letterGrade = LetterGrade.A;
        }
        else if (_gradePercentage >= 80)
        {
            letterGrade = LetterGrade.B;
        }
        else if (_gradePercentage >= 70)
        {
            letterGrade = LetterGrade.C;
        }
        else if (_gradePercentage >= 60)
        {
            letterGrade = LetterGrade.D;
        }
        else
        {
            letterGrade = LetterGrade.F;
        }
    }

    public enum LetterGrade
    {
        A,
        B,
        C,
        D,
        F
    }
}
