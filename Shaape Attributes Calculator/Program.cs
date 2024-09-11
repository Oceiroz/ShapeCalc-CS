using System;
using System.Collections.Generic;

namespace Shaape_Attributes_Calculator
{
    internal class Program
    {   
        static void Main(string[] args)
        {
            List<string> options = new List<string>() {"Circle", "Square", "Rectangle", "Equilateral Triangle", "Cube", "Cuboid", "Sphere", "Cylinder"};
            int shapeChoice = GetChoice("What shape would you like to calculate", options);
            if (shapeChoice == 2 || shapeChoice == 5 || shapeChoice == 7 || shapeChoice == 1)
            {
                OneValueEq(shapeChoice);
            }
            else if (shapeChoice == 3 || shapeChoice == 4 || shapeChoice == 8)
            {
                TwoValueEq(shapeChoice);
            }
            else if (shapeChoice == 6)
            {
                ThreeValueEq(shapeChoice);
            }
        }

        static double GetInput(string inputMessage)
        {
            double userInput = 0;
            while (true)
            {
                Console.WriteLine($"{inputMessage}\n");
                string rawInput = Console.ReadLine();
                try
                {
                    userInput = double.Parse(rawInput);
                    break;
                }
                catch (FormatException)
                {
                    Console.WriteLine("this is not a valid input");
                }
            }
            return userInput;
        }
        static int GetChoice(string inputMessage, List<string> options)
        {
            int choice = 0;
            while (true)
            {
                for (int i = 0; i < options.Count; i++)
                {
                    Console.WriteLine($"\n{i+1} ---> {options[i]}\n");
                }
                Console.WriteLine($"{inputMessage}\n");
                string rawInput = Console.ReadLine();
                try
                {
                    choice = int.Parse(rawInput);
                    if (choice > options.Count || choice <= 0)
                    {
                        throw new FormatException();
                    }
                    break;
                }
                catch (FormatException)
                {
                    Console.WriteLine("this is not a valid input");
                }
            }
            return choice;
        }
        //Area == width * height
        //perimeter == 2 * ((width) + (height))
        //volume == width * height * depth
        //surface area == 2 * ((width * height) + (width * depth) + (depth * height))
            
        
        static void ThreeValueEq(int shapeChoice)
        {
            double width, height, depth, volume, surfaceArea;
            width = GetInput("please input a width");
            depth = GetInput("please input a depth");
            height = GetInput("please input a height");
            volume = width * depth * height;
            surfaceArea = 2 * ((width * height) + (width * depth) + (depth * height));
            Console.WriteLine($"Volume is {volume}");
            Console.WriteLine($"Surface area is {surfaceArea}");
        }
        static void TwoValueEq(int shapeChoice)
        {
            double width, radius, height, areaRect, areaTria, perimRect, perimTria, volumeCyli, saCyli;
            if (shapeChoice == 3)
            {
                width = GetInput("please input a width");
                height = GetInput("please input a height");
                areaRect = width * height;
                perimRect = 2 * (width + height);
                Console.WriteLine($"Area is {areaRect}");
                Console.WriteLine($"perimeter is {perimRect}");
            }
            else if (shapeChoice == 4)
            {
                height = GetInput("please input a height");
                width = GetInput("please input a width");
                perimTria = 3 * width;
                areaTria = (width * height) / 2;
                Console.WriteLine($"Volume is {areaTria}");
                Console.WriteLine($"Surface Area is {perimTria}");
            }
            else if (shapeChoice == 8)
            {
                radius = GetInput("please input a radius");
                height = GetInput("please input a height");
                volumeCyli = Math.PI * radius * radius * height;
                saCyli = (2 * Math.PI * radius * radius) + (2 * Math.PI * radius * height);
                Console.WriteLine($"Volume is {volumeCyli}");
                Console.WriteLine($"Surface Area is {saCyli}");
            }
        }
        static void OneValueEq(int shapeChoice)
        {
            double width, radius, areaSquare, areaCircle, perimeter, circumference, volumeCube, volumeSphere, saCube, saSphere;
            if (shapeChoice == 2)
            {
                width = GetInput("please input a width");
                areaSquare = width * width;
                perimeter = width * 4;
                Console.WriteLine($"Area is {areaSquare}");
                Console.WriteLine($"perimeter is {perimeter}");
            }
            else if (shapeChoice == 5)
            {
                width = GetInput("please input a width");
                volumeCube = width * width * width;
                saCube = 6 * (width * width);
                Console.WriteLine($"Volume is {volumeCube}");
                Console.WriteLine($"Surface Area is {saCube}");
            }
            else if (shapeChoice == 7)
            {
                radius = GetInput("please input a radius");
                volumeSphere = 4 / 3 * Math.PI * radius * radius * radius;
                saSphere = 2 * Math.PI * radius * radius;
                Console.WriteLine($"Volume is {volumeSphere}");
                Console.WriteLine($"Surface Area is {saSphere}");
            }
            else if (shapeChoice == 1)
            {
                radius = GetInput("please input a radius");
                areaCircle = Math.PI * radius * radius;
                circumference = 2 * Math.PI * radius;
                Console.WriteLine($"Area is {areaCircle}");
                Console.WriteLine($"perimeter is {circumference}");
            }
        }
    }
}
