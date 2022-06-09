using ToDoApp.core;

namespace ToDoApp
{
    class Program
    {
        static void Main(string[] args)
        {
            var toDo = new ToDo();
            toDo.IntroduceToDoApp();
            toDo.AskForAction();
        }
    }
}