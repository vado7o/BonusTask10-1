// Задача со звёздочкой 1: Задайте двумерный массив из целых чисел. Определите, есть столбец в массиве, сумма которого, 
// больше суммы элементов расположенных в четырех "углах" двумерного массива.

Console.Clear();
Console.WriteLine("Программа, определяющая наличие столбца в массиве, сумма элементов которого больше суммы элементов в углах");

int row = 0;
int column = 0;

AskForInput("row");
AskForInput("column");

int[,] array = FillArray(row, column, 0, 10);

Console.Write("\nCгенерированный массив: \n");
PrintArray(array);

int corner_sum = array[0, 0] + array[0, array.GetLength(1) - 1] + array[array.GetLength(0) - 1, 0] + array[array.GetLength(0) - 1, array.GetLength(1) - 1];
Console.WriteLine("Сумма угловых элементов массива равна " + corner_sum);

CheckForGrater(array);

///////////////// функции: //////////////////////////////
int[,] FillArray(int row, int column, int min, int max)
{
    int[,] filledArray = new int[row, column];
    for (int i = 0; i < row; i++)
    {
        for (int j = 0; j < column; j++)
        {
        filledArray[i, j] = new Random().Next(min, max);
        }
    }
    return filledArray;
}

void PrintArray(int[,] array)
{
    for (int i = 0; i < array.GetLength(0); i++)
    {
        for (int j = 0; j < array.GetLength(1); j++)
        {
            Console.Write(array[i,j] + " ");
        }
    Console.WriteLine();
    }   
}

void AskForInput(string str)
{
    while (true)
    {
        if(str == "row")
        {
            Console.Write("\nНапишите - из скольки строк должен состоять массив? :");
        }
        else if(str == "column") 
        {
            Console.Write("\nНапишите - из скольки столбцов должен состоять массив? :");
        }
        if (int.TryParse(Console.ReadLine(), out int number))
        {
            if (number > 0)
            {
                if(str == "row")
                {
                    row = number;
                }
                else if(str == "column")
                {
                    column = number;
                }
                break;
            }
            else Console.WriteLine("Некорректно указано количество строк массива!\n");
        }
        else Console.WriteLine("Некорректно указано количество строк массива!\n");
    }
}

void CheckForGrater(int[,] array)
{
    int sum = 0;
    int count = 1;
    for(int i = 0; i < array.GetLength(0); i++)
    {
        for(int j = 0; j < array.GetLength(1); j++)
        {
            sum += array[j, i];
        }
        if(sum > corner_sum)
        {
            Console.WriteLine("Сумма элементов столбца " + count + " больше суммы угловых элементов и равна " + sum);
            count = 0;
            break;
        }
        sum = 0;
        count++;
    }
    if(count != 0) Console.WriteLine("В массиве нет столбцов, сумма элементов которых была бы больше суммы угловых элементов!!");
}