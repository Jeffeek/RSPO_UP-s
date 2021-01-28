﻿using System;
using System.Collections.Generic;
using System.Linq;
using CyberMath.Structures.Matrices.Extensions;
using CyberMath.Structures.Matrices.JaggedMatrix;
using CyberMath.Structures.Matrices.Matrix;

namespace RSPO_UP_13
{
    class Program
    {
        static void Main(string[] args)
        {
            //FirstTask();
            //SecondTask();
        }

        static void FirstTask()
        {
	        var initialString = "1 2 3 4 5 6 7 8 9 10";
	        Console.WriteLine($"Входная строка: {initialString}");
	        var splitted = initialString.Split();
	        var result = String.Join(" ", splitted.Select((t, i) => t + (i != splitted.Length - 1 ? splitted[i + 1] : "")));
	        Console.WriteLine($"Result: {result}");
        }

        static void SecondTask()
        {
	        var test = "АБВГД";
	        var matrix = new Matrix<char>(3, 3)
	                     {
		                     [0, 0] = 'А', [0, 1] = 'Б', [0, 2] = 'В',
		                     [1, 0] = 'Г', [1, 1] = 'Д', [1, 2] = 'E',
		                     [2, 0] = 'И', [2, 1] = 'З', [2, 2] = 'Ж',
	                     };

	        var matAstr = String.Concat(matrix.Select(x => String.Concat(x)));
	        var result = test.All(x => matAstr.Contains(x));
	        Console.WriteLine(result);
        }
    }
}
