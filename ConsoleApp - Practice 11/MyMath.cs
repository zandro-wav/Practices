using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PracticesConsoleApp;

public class MyMath
{
    // ── მათემატიკური მეთოდები ────────────────────────────────────────────────

    // ორი მნიშვნელობიდან პატარას აბრუნებს
    public static int Min(int a, int b) => a < b ? a : b;

    public static double Min(double a, double b) => a < b ? a : b;

    // ორი მნიშვნელობიდან დიდს აბრუნებს
    public static int Max(int a, int b) => a > b ? a : b;

    public static double Max(double a, double b) => a > b ? a : b;

    // ზღუდავს მნიშვნელობას [min, max] დიაპაზონში
    public static int Clamp(int value, int min, int max)
    {
        if (value < min) return min;
        if (value > max) return max;
        return value;
    }

    public static double Clamp(double value, double min, double max)
    {
        if (value < min) return min;
        if (value > max) return max;
        return value;
    }

    // კვადრატულ ფესვს იანგარიშებს ნიუტონ-რაფსონის მეთოდით
    // უარყოფითი რიცხვისთვის აბრუნებს 0-ს
    public static double Sqrt(double value)
    {
        if (value <= 0) return 0;

        double guess = value / 2.0;
        for (int i = 0; i < 100; i++)
            guess = (guess + value / guess) / 2.0;
        return guess;
    }

    // ამაღლებს ბაზას ხარისხში (მთელი ხარისხი)
    public static double Pow(double baseValue, int exponent)
    {
        if (exponent == 0) return 1;

        // უარყოფითი ხარისხის შემთხვევაში ვიანგარიშებთ 1/baseValue^|exponent|
        bool negative = exponent < 0;
        int absExp = negative ? -exponent : exponent;

        double result = 1;
        for (int i = 0; i < absExp; i++) result *= baseValue;

        return negative ? 1.0 / result : result;
    }

    // ამრგვალებს უახლოეს მთელ რიცხვამდე (0.5-ზე - წყვილისკენ)
    public static int Round(double value)
    {
        int floor = (int)value;
        double fraction = value - floor;
        if (fraction > 0.5) return floor + 1;
        if (fraction < 0.5) return floor;
        // ზუსტად 0.5 - ვამრგვალებთ წყვილ რიცხვამდე
        return (floor % 2 == 0) ? floor : floor + 1;
    }

    // აბრუნებს მოცემული რიცხვის ქვემოთ მდებარე უახლოეს მთელ რიცხვს
    public static int Floor(double value)
    {
        int truncated = (int)value;
        return (value < 0 && value != truncated) ? truncated - 1 : truncated;
    }

    // აბრუნებს მოცემული რიცხვის ზემოთ მდებარე უახლოეს მთელ რიცხვს
    public static int Ceiling(double value)
    {
        int truncated = (int)value;
        return (value > 0 && value != truncated) ? truncated + 1 : truncated;
    }

    // აბრუნებს რიცხვის აბსოლუტურ (დადებით) მნიშვნელობას
    public static int Abs(int value) => value < 0 ? -value : value;

    public static double Abs(double value) => value < 0 ? -value : value;
}