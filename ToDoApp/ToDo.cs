using ToDoApp.core;

namespace ToDoApp
{
    public class ToDo
    {
        public ExamManager ExamManager { get; set; } = new ExamManager();

        /// <summary>
        /// Metoda wstępna.
        /// </summary>
        public void IntroduceToDoApp()
        {
            Console.WriteLine("Ten program pomoże ci w zapamiętywaniu wszystkich zaliczń, egazaminów oraz kolowkiów na aktualny rok!");
        }

        /// <summary>
        /// Metoda dodająca nowe zadania.
        /// </summary>
        public void AddExam()
        {

            Console.WriteLine("Podaj przedmiot do dodania: ");

            var examTitle = Console.ReadLine();
            examTitle = examTitle.ToLower();

            Console.WriteLine("Podaj dzień: ");

            var dayOfExam = Console.ReadLine();

            Console.WriteLine("Podaj miesiąc: ");

            var monthOfExam = Console.ReadLine();

            Console.WriteLine("Podaj rok: ");

            var yearOfExam = Console.ReadLine();

            Console.WriteLine("Podaj godzinę: ");

            var hourOfExam = Console.ReadLine();

            Console.WriteLine("Podaj minutę: ");

            var minuteOfExam = Console.ReadLine();

            var examDate = hourOfExam + ":" + minuteOfExam + " | " + dayOfExam + '/' + monthOfExam + '/' + yearOfExam;


            var dayOfExamToInt = default(int);
            
            while (!int.TryParse(dayOfExam, out dayOfExamToInt) || dayOfExamToInt > 31)
            {
                Console.WriteLine("Podano niewłaściwą wartość, podaj dzień.");

                dayOfExam = Console.ReadLine();
            }


            var monthOfExamToInt = default(int);

            while (!int.TryParse(monthOfExam, out monthOfExamToInt) || monthOfExamToInt > 12)
            {
                Console.WriteLine("Podano niewłaściwą wartość, podaj miesiąc.");

                monthOfExam = Console.ReadLine();
            }


            var thisYear = DateTime.Now.Year;

            var yearOfExamToInt = default(int);

            while (!int.TryParse(yearOfExam, out yearOfExamToInt) || yearOfExamToInt != thisYear)
            {
                Console.WriteLine("Podano niewłaściwą wartość, podaj rok.");

                yearOfExam = Console.ReadLine();
            }

           
            var hourOfExamToInt = default(int);

            while (!int.TryParse(hourOfExam, out hourOfExamToInt) || hourOfExamToInt > 24)
            {
                Console.WriteLine("Podano niewłaściwą wartość, podaj godzinę.");

                hourOfExam = Console.ReadLine();
            }


            var minuteOfExamToInt = default(int);

            while (!int.TryParse(minuteOfExam, out minuteOfExamToInt) || minuteOfExamToInt > 59)
            {
                Console.WriteLine("Podano niewłaściwą wartość, podaj minutę.");

                minuteOfExam = Console.ReadLine();
            }

            

            ExamManager.AddExam(examTitle, dayOfExamToInt, monthOfExamToInt, yearOfExamToInt, hourOfExamToInt, minuteOfExamToInt);

            Console.WriteLine("Dodano termin.");
        }

        /// <summary>
        /// Metoda do odchaczania zadań.
        /// </summary>
        public void UnCheckExam()
        {
            Console.WriteLine("Podaj przedmiot do usunięcia: ");

            var examTitle = Console.ReadLine();
            examTitle = examTitle.ToLower();

            ExamManager.UncheckExam(examTitle);

            Console.WriteLine("Odznaczono termin.");
        }

        /// <summary>
        /// Metoda do wyświetlania zadań.
        /// </summary>
        public void ListToDo()
        {
            
            Console.WriteLine("Lista twoich zaliczeń: ");
            
            foreach (var exam in ExamManager.ListExam())
            {
                Console.WriteLine(exam);
            }
        }

        /// <summary>
        /// Metoda odpowiadająca za pytania do użytkownika.
        /// </summary>
        public void AskForAction()
        {
            Console.WriteLine("Lista komend: add, uncheck, list, exit");

            var userInput = default(string);

            while (userInput != "exit")
            {
                userInput = Console.ReadLine();
                userInput = userInput.ToLower();

                switch (userInput)
                {
                    case "add":
                        Console.Clear();
                        AddExam();
                        break;
                    case "uncheck":
                        Console.Clear();
                        UnCheckExam();
                        break;
                    case "list":
                        Console.Clear();
                        ListToDo();
                        break;
                    case "exit":
                        Console.Clear();
                        break;
                    default:
                        Console.Clear();
                        Console.WriteLine("Nie ma takiej komendy!");
                        Console.WriteLine("Lista komend: add, uncheck, list, exit");
                        break;
                }
            }
        }
    }
}
