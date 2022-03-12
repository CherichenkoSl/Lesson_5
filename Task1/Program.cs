Console.WriteLine("Введите всю необходимую информацию для записи");
string someInfo = Console.ReadLine();
File.WriteAllText("Text.txt", someInfo);

