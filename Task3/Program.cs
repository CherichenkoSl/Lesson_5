Console.WriteLine("Введите произвольный набор чисел от 0 до 255 через запятую:");
string numbers = Console.ReadLine();
string[] byteNumbers = numbers.Split(',');
byte[] bytes = new byte[byteNumbers.Length];
for(int i = 0; i < byteNumbers.Length; i++)
{
    bytes[i]= Convert.ToByte(byteNumbers[i]);
}
File.WriteAllBytes("bytes.bin", bytes);
