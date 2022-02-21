string location = "c:\\Users\\cherr\\Downloads\\1";
SaveDir(location, "Directory_tree.txt", 0);
Console.ReadKey();
//Сохраняет дерево каталогов с помощью рекурскии
static void SaveDir(string path, string name, int level)
{
    string[] filesFull = Directory.EnumerateFiles(path).ToArray();
    string[] directoriesFull = Directory.EnumerateDirectories(path).ToArray();
    if(filesFull.Length==0 &&directoriesFull.Length==0)
    {
        for (int e = 0; e < level; e++)
        {
            File.AppendAllText(name, "\t");
        }
        File.AppendAllText(name, "\"Папка пуста\"");
        File.AppendAllText(name, Environment.NewLine);
    }    
    string[] files = new string[filesFull.Length];
    for (int j = 0; j < filesFull.Length; j++)
    {
        for (int b = 0; b < level; b++)
        {
            File.AppendAllText(name, "\t");
        }
        files[j] = filesFull[j].Substring(path.Length + 1);
        File.AppendAllText(name, files[j]);
        File.AppendAllText(name, Environment.NewLine);
    }
    string[] directories = new string[directoriesFull.Length];
    for (int i = 0; i < directoriesFull.Length; i++)
    {
        directories[i] = directoriesFull[i].Substring(path.Length + 1);
        for (int c = 0; c < level; c++)
        {
            File.AppendAllText(name, "\t");
        }
        File.AppendAllText(name, $"{directories[i]}:");
        File.AppendAllText(name, Environment.NewLine);
        SaveDir(directoriesFull[i], name, ++level);
        level--;
    }
}
SaveDirectoryWithoutRec(location, "Tree.txt");
//Сохраняет дерево каталогов без рекурскии
static void SaveDirectoryWithoutRec (string path, string name)
{
    string[] filesFull = Directory.EnumerateFiles(path).ToArray();
    string[] directoriesFull = Directory.EnumerateDirectories(path).ToArray();
    string[] files = new string[filesFull.Length];
    for (int j = 0; j < filesFull.Length; j++)
    { 
        files[j] = filesFull[j].Substring(path.Length + 1);
        File.AppendAllText(name, files[j]);
        File.AppendAllText(name, Environment.NewLine);
    }
    string[] directories = new string[directoriesFull.Length];
    for(int i=0; i<directoriesFull.Length; i++)
    {
        directories[i] = directoriesFull[i].Substring(path.Length + 1);
        if (Directory.GetFiles(directoriesFull[i]).Length==0 && Directory.GetDirectories(directoriesFull[i]).Length==0)
        {
            File.AppendAllText(name, directories[i]);
            File.AppendAllText(name, Environment.NewLine);
            continue;
        }
        File.AppendAllText(name, $"{directories[i]}:");
        File.AppendAllText(name, Environment.NewLine);
        string[] filesFullLevel2 = Directory.EnumerateFiles(directoriesFull[i]).ToArray();
        string[] directoriesFullLevel2 = Directory.EnumerateDirectories(directoriesFull[i]).ToArray();
        string[] filesLevel2 = new string[filesFullLevel2.Length];
        for (int j = 0; j<filesFullLevel2.Length;j++)
        {
            filesLevel2[j] = filesFullLevel2[j].Substring(directoriesFull[i].Length+1);
            File.AppendAllText(name, "\t");
            File.AppendAllText(name, filesLevel2[j]);
            File.AppendAllText(name, Environment.NewLine);
        }
        string[] directoriesLevel2 = new string[directoriesFullLevel2.Length];
        for (int a=0; a<directoriesFullLevel2.Length;a++)
        {
            directoriesLevel2[a] = directoriesFullLevel2[a].Substring(directoriesFull[i].Length + 1);
            File.AppendAllText(name, "\t");
            File.AppendAllText(name, directoriesLevel2[a]);
            File.AppendAllText(name, Environment.NewLine);
        }
    }
}
