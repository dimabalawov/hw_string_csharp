using System;
using static System.Net.Mime.MediaTypeNames;

void ceasersEncrypt(int shift)
{
    Console.Write("Введите строку: ");
    string text = Console.ReadLine();
    char[] buffer = text.ToCharArray();

    for (int i = 0; i < buffer.Length; i++)
    {
        char letter = buffer[i];
        if (char.IsLetter(letter))
        {
            char offset = char.IsUpper(letter) ? 'A' : 'a';
            letter = (char)(((letter + shift - offset) % 26) + offset);
        }

        buffer[i] = letter;
    }
    string encrypted = new(buffer);
    Console.WriteLine($"Зашифрованная строка: {encrypted}");
}

void calculateString()
{
    Console.Write("Введите выражение: ");
    string text = Console.ReadLine();
    string[] parts = text.Split(new char[] { '+', '-' });
    int operLen = 0;
    foreach (char letter in text)
    {
        if (letter == '+' || letter == '-')
            operLen++;
    }
    char[] operators = new char[operLen];
    int index = 0;

    foreach (char letter in text)
    {
        if (letter == '+' || letter == '-')
        {
            operators[index] = letter;
            index++;
        }
    }
    int res = int.Parse(parts[0]);
    for (int i = 0; i < parts.Length - 1; i++)
    {
        if (operators[i] == '+')
            res += int.Parse(parts[i + 1]);
        else
            res -= int.Parse(parts[i + 1]);
    }
    Console.WriteLine($"Результат: {res}");
}

void capitalLetter(string text)
{
    string[] words = text.Split('.');
    for (int i = 0; i < words.Length; i++)
    {
        int j = 0;
        while (words[i][j] == ' ')
        { j++; }
        words[i] = char.ToUpper(words[i][j]) + words[i].Substring(1 + j);
    }
    string newText = string.Join(". ", words);
    Console.WriteLine(newText);
}
void censure(string text, string forbiddenWord)
{
    char[] newText = text.ToCharArray();
    int count = 0;
    int index = 0;

    while ((index = text.IndexOf(forbiddenWord, index, StringComparison.OrdinalIgnoreCase)) != -1)
    {
        for (int i = 0; i < forbiddenWord.Length; i++)
        {
            newText[index + i] = '*';
        }
        count++;
        index += forbiddenWord.Length;
    }

    string result = new string(newText);
    Console.WriteLine(result);
    Console.WriteLine($"Сколько раз это слово было найдено: {count}");
}
ceasersEncrypt(3);
calculateString();
capitalLetter("today is a good any for walking. i will try to walk near the sea");
string text = "To be, or not to be, that is the question ,\r\nWhether 'tis nobler in the mind to suffer\r\nThe slings and arrows of outrageous fortune,\r\nOr to take arms against a sea of troubles,\r\nAnd by opposing end them? To die: to sleep;\r\nNo more; and by a sleep to say we end\r\nThe heart-ache and the thousand natural shocks\r\nThat flesh is heir to, 'tis a consummation\r\nDevoutly to be wish'd. To die, to sleep";
censure(text,"die");
