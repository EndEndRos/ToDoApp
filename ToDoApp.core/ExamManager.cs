namespace ToDoApp.core
{
    public class ExamManager
    {
        private List<Exam> Exams { get; set; }

        private string FileExam { get; set; } = "ExamsFile.txt";

        public ExamManager()
        {
            Exams = new List<Exam>();

            if (!File.Exists(FileExam))
            {
                return;
            }

            var fileLines = File.ReadAllLines(FileExam);

            
            foreach (var line in fileLines)
            {
                var lineItems = line.Split(';');

                if (int.TryParse(lineItems[1], out var dateInIntDay))
                {
                    if (int.TryParse(lineItems[2], out var dateInIntMonth))
                    {
                        if (int.TryParse(lineItems[3], out var dateInIntYear))
                        {
                            if (int.TryParse(lineItems[4], out var dateInIntHour))
                            {
                                if (int.TryParse(lineItems[5], out var dateInIntMinute))
                                {

                                    AddExam(lineItems[0], dateInIntDay, dateInIntMonth, dateInIntYear, dateInIntHour, dateInIntMinute, false);
                                }
                            }
                        }
                    }
                }   
            }
            
        }

        public void AddExam(string examTitle, int dayOfExam, int monthOfExam, int yearOfExam, int hourOfExam, int minuteOfExam, bool shouldSaveToFile = true)
        {
            var exam = new Exam
            {
                ExamTitle = examTitle,
                DayOfExam = dayOfExam,
                MonthOfExam = monthOfExam,
                YearOfExam = yearOfExam,
                HourOfExam = hourOfExam,
                MinuteOfExam = minuteOfExam

            };

            Exams.Add(exam);

            if (shouldSaveToFile)
            {
                File.AppendAllLines(FileExam, new List<string> { exam.ToString() });
            }
        }
        public void UncheckExam(string examTitle, bool shouldSaveToFile = true)
        {
            foreach (var exam in Exams)
            {
                if (exam.ExamTitle == examTitle)
                {
                    Exams.Remove(exam);
                    break;
                }
            }

            if (shouldSaveToFile)
            {
                var examToSave = new List<string>();

                foreach (var exam in Exams)
                {
                    examToSave.Add(exam.ToString());
                }

                File.Delete(FileExam);
                File.WriteAllLines(FileExam, examToSave);
            }
         
        }

        public List<string> ListExam()
        {
            var examStrings = new List<string>();
            var index = 1;

            foreach (var exam in Exams)
            {
                var examString = index + ". " + exam.ExamTitle + " - " + exam.HourOfExam + ":" + exam.MinuteOfExam + " | " + exam.DayOfExam + "/" + exam.MonthOfExam + "/" + exam.YearOfExam;
                index++;

                examStrings.Add(examString);
            }

            return examStrings;
        }
    }
}
