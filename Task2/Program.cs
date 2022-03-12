DateTime nowDate = DateTime.Now;
string date = nowDate.ToString();
File.AppendAllText("startup.txt", date);
File.AppendAllText("startup.txt", Environment.NewLine);
