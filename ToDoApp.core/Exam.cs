namespace ToDoApp.core
{
    public class Exam
    {
        public string ExamTitle { get; set; }
        public int DayOfExam { get; set; }
        public int MonthOfExam { get; set; }
        public int YearOfExam { get; set; }
        public int HourOfExam { get; set; }
        public int MinuteOfExam { get; set; }

        public override string ToString()
        {
            return ExamTitle + ";" + DayOfExam.ToString() + ";" + MonthOfExam.ToString() + ";" +YearOfExam.ToString() + ";" + HourOfExam.ToString() + ";" + MinuteOfExam.ToString();
        }
    }
}
