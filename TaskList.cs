using static System.Net.Mime.MediaTypeNames;

class TaskList
{
    private static string[] comand = new string[4] {"listTask", "newTask", "openTask-No-", "editTask-No-"};
    private List<TaskProperties> task = new List<TaskProperties>();

    static void Main(string[] args)
    {
        TaskList pr = new TaskList();

        Console.WriteLine("здравствуйте это задачник вы можете использовать команды:");

        for(int i = 0; i < comand.Length; i++)
        {
            Console.WriteLine(comand[i]);
        }

        pr.ConsoleCommand();
    }

    private void ConsoleCommand()
    {

        while (true)
        {
            Console.WriteLine("вы на домашней странице введите команду");
            string? userCommand = Console.ReadLine();

            if(userCommand != null)
            {

                if (userCommand == comand[0])
                {
                    ListTask();
                }
                else if (userCommand == comand[1])
                {
                    NewTask();
                }
                else if (userCommand.StartsWith(comand[2]))
                {
                    OpenTask(userCommand);
                }
                else if (userCommand.StartsWith(comand[3]))
                {
                    EditTask(userCommand);
                }
                else
                {
                    Console.WriteLine("здравствуйте это задачник вы можете использовать команды:");

                    for (int i = 0; i < comand.Length; i++)
                    {
                        Console.WriteLine(comand[i]);
                    }

                }

            }

        }

    }

    private void ListTask()
    {
        Console.WriteLine("вот список ваших задач:");

        for(int i = 0; i < task.Count; i++)
        {
            Console.WriteLine("No:" + i + "_" + task[i].accessNameTask());
        }

    }

    private void NewTask()
    {
        string[] paramTask = ParametersTask();

        task.Add(new TaskProperties(paramTask[0], paramTask[1]));
        ListTask();
    }

    private void OpenTask(string command)
    {
        TaskProperties task = TextSlize(command);
        Console.WriteLine($"вы открыли задачу - {task.accessNameTask}");
        Console.WriteLine(task.accessContentTask());
    }

    private void EditTask(string command)
    {
        TaskProperties task = TextSlize(command);
        Console.WriteLine($"текушие свойства задачи:name-{task.accessNameTask} content- {task.accessContentTask} _обновите свойства");
        string[] newParam = ParametersTask();
        NewParametersSize(command, newParam);
    }

    private string[] ParametersTask()
    {
        string[] parametersTask = new string[2];

        Console.WriteLine("введите название вашей задачи");
        parametersTask[0] = Console.ReadLine();

        Console.WriteLine("введите содержание задачи");
        parametersTask[1] = Console.ReadLine();

        return parametersTask;
    }

    private void NewParametersSize(string text, string[] newP)
    {
        TaskProperties Task = TextSlize(text);
        Task.newContent(newP[0], newP[1]);
    }

    private TaskProperties TextSlize(string text)
    {
        string[] parts = text.Split('-');
        TaskProperties anyTask = task[Convert.ToInt32(parts[1])];
        return anyTask;
    }

}