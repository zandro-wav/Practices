using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PracticesConsoleApp;

public class MyInt
{
    public int _value;

    // კონსტრუქტორი 1 პარამეტრით
    public MyInt(int value)
    {
        _value = value;
    }


    // int ტიპის მინიმალური მნიშვნელობა: -2 147 483 648
    public static int MinValue = -2147483648;

    // int ტიპის მაქსიმალური მნიშვნელობა: 2 147 483 647
    public static int MaxValue = 2147483647;


    // რიცხვს გარდაქმნის სტრინგად
    public override string ToString() => _value.ToString();

    // რიცხვს გარდაქმნის სტრინგად მოცემული ფორმატით
    public string ToString(string format) => _value.ToString(format);


    // ამოწმებს ემთხვევა თუ არა მნიშვნელობა სხვა რიცხვს
    public bool Equals(int other) => _value == other;

    // ადარებს მნიშვნელობას სხვა რიცხვთან, აბრუნებს -1, 0 ან 1
    public int CompareTo(int other)
    {
        if (_value < other) return -1;
        if (_value > other) return 1;
        return 0;
    }


    // სტრინგს გარდაქმნის MyInt-ად, არასწორი ფორმატის შემთხვევაში აბრუნებს 0-ს
    public static MyInt Parse(string s)
    {
        if (string.IsNullOrWhiteSpace(s)) return new MyInt(0);

        bool negative = false;
        int i = 0;

        if (s[0] == '-') { negative = true; i = 1; }
        else if (s[0] == '+') { i = 1; }

        int result = 0;
        for (; i < s.Length; i++)
        {
            // სიმბოლო არ არის ციფრი - ვაბრუნებთ 0-ს
            if (s[i] < '0' || s[i] > '9') return new MyInt(0);
            result = result * 10 + (s[i] - '0');
        }
        return new MyInt(negative ? -result : result);
    }

    // სტრინგს გარდაქმნის MyInt-ად, წარმატებისას აბრუნებს true, წარუმატებლობისას false
    public static bool TryParse(string s, out MyInt result)
    {
        result = new MyInt(0);
        if (string.IsNullOrWhiteSpace(s)) return false;

        bool negative = false;
        int i = 0;

        if (s[0] == '-') { negative = true; i = 1; }
        else if (s[0] == '+') { i = 1; }

        int value = 0;
        for (; i < s.Length; i++)
        {
            // სიმბოლო არ არის ციფრი - პარსინგი ვერ მოხერხდა
            if (s[i] < '0' || s[i] > '9') return false;
            value = value * 10 + (s[i] - '0');
        }

        result = new MyInt(negative ? -value : value);
        return true;
    }
}