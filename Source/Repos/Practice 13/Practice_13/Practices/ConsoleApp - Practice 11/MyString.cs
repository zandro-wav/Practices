using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PracticesConsoleApp;

public class MyString
{
    public string _value;
    public int Length;

    // კონსტრუქტორი 1 პარამეტრით
    public MyString(string value)
    {
        _value = value;
        Length = GetLength();
    }

    // კონსტრუქტორი 2 პარამეტრით - სიმბოლო და რაოდენობა
    public MyString(char c, int count)
    {
        _value = "";
        for (int i = 0; i < count; i++) _value += c;
        Length = GetLength();
    }


    // ამოწმებს არის თუ არა სტრინგი null ან ცარიელი
    public static bool IsNullOrEmpty(string value)
    {
        return value == null || value == "";
    }


    // ამოწმებს ემთხვევა თუ არა სტრინგი სხვა სტრინგს
    public bool Equals(string other)
    {
        return _value == other;
    }

    // ადარებს სტრინგს სხვა სტრინგთან, აბრუნებს უარყოფითს, 0-ს ან დადებითს
    public int Compare(string other)
    {
        return string.Compare(_value, other);
    }

    // ადარებს სტრინგს სხვა სტრინგთან ანბანური თანმიმდევრობის მიხედვით
    public int CompareTo(string other)
    {
        return _value.CompareTo(other);
    }

    // ამოწმებს იწყება თუ არა სტრინგი მოცემული პრეფიქსით
    public bool StartsWith(string prefix)
    {
        if (prefix.Length > Length) return false;
        for (int i = 0; i < prefix.Length; i++)
            if (_value[i] != prefix[i]) return false;
        return true;
    }

    // ამოწმებს მთავრდება თუ არა სტრინგი მოცემული სუფიქსით
    public bool EndsWith(string suffix)
    {
        if (suffix.Length > Length) return false;
        int offset = Length - suffix.Length;
        for (int i = 0; i < suffix.Length; i++)
            if (_value[offset + i] != suffix[i]) return false;
        return true;
    }

    // ამოწმებს შეიცავს თუ არა სტრინგი მოცემულ ქვე-სტრინგს
    public bool Contains(string sub)
    {
        return IndexOf(sub) >= 0;
    }

    // პოულობს მოცემული ქვე-სტრინგის პირველ პოზიციას, -1 თუ ვერ იპოვა
    public int IndexOf(string sub)
    {
        for (int i = 0; i <= Length - sub.Length; i++)
        {
            bool found = true;
            for (int j = 0; j < sub.Length; j++)
            {
                if (_value[i + j] != sub[j]) { found = false; break; }
            }
            if (found) return i;
        }
        return -1;
    }

    // პოულობს მოცემული ქვე-სტრინგის ბოლო პოზიციას, -1 თუ ვერ იპოვა
    public int LastIndexOf(string sub)
    {
        int last = -1;
        for (int i = 0; i <= Length - sub.Length; i++)
        {
            bool found = true;
            for (int j = 0; j < sub.Length; j++)
            {
                if (_value[i + j] != sub[j]) { found = false; break; }
            }
            if (found) last = i;
        }
        return last;
    }


    // აბრუნებს ქვე-სტრინგს საწყისი ინდექსიდან ბოლომდე
    public MyString Substring(int startIndex)
    {
        string result = "";
        for (int i = startIndex; i < Length; i++) result += _value[i];
        return new MyString(result);
    }

    // აბრუნებს ქვე-სტრინგს საწყისი ინდექსიდან მოცემული სიგრძით
    public MyString Substring(int startIndex, int length)
    {
        string result = "";
        for (int i = startIndex; i < startIndex + length && i < Length; i++)
            result += _value[i];
        return new MyString(result);
    }

    // ცვლის ძველ მნიშვნელობას ახლით სტრინგში
    public MyString Replace(string oldValue, string newValue)
    {
        string result = "";
        int i = 0;
        while (i <= Length - oldValue.Length)
        {
            bool match = true;
            for (int j = 0; j < oldValue.Length; j++)
                if (_value[i + j] != oldValue[j]) { match = false; break; }

            if (match) { result += newValue; i += oldValue.Length; }
            else { result += _value[i]; i++; }
        }
        while (i < Length) { result += _value[i]; i++; }
        return new MyString(result);
    }

    // სტრინგში ჩასმა ინდექსის მიხედვით
    public MyString Insert(int startIndex, string value)
    {
        string newValue = "";
        for (int i = 0; i < startIndex; i++) newValue += _value[i];
        newValue += value;
        for (int i = startIndex; i < Length; i++) newValue += _value[i];
        return new MyString(newValue);
    }

    // შლის სტრინგს მოცემული ინდექსიდან ბოლომდე
    public MyString Remove(int startIndex)
    {
        string result = "";
        for (int i = 0; i < startIndex; i++) result += _value[i];
        return new MyString(result);
    }

    // შლის სტრინგის ნაწილს მოცემული ინდექსიდან და რაოდენობით
    public MyString Remove(int startIndex, int count)
    {
        string result = "";
        for (int i = 0; i < startIndex; i++) result += _value[i];
        for (int i = startIndex + count; i < Length; i++) result += _value[i];
        return new MyString(result);
    }

    // შლის სფეისებს სტრინგის ორივე მხრიდან
    public MyString Trim()
    {
        int start = 0, end = Length - 1;
        while (start < Length && _value[start] == ' ') start++;
        while (end >= 0 && _value[end] == ' ') end--;
        return start > end ? new MyString("") : Substring(start, end - start + 1);
    }

    // შლის სფეისებს სტრინგის დასაწყისიდან
    public MyString TrimStart()
    {
        int start = 0;
        while (start < Length && _value[start] == ' ') start++;
        return Substring(start);
    }

    // შლის სფეისებს სტრინგის ბოლოდან
    public MyString TrimEnd()
    {
        int end = Length - 1;
        while (end >= 0 && _value[end] == ' ') end--;
        return end < 0 ? new MyString("") : Substring(0, end + 1);
    }

    // სტრინგის ყველა სიმბოლოს გადაყვანა დიდ ასოებზე
    public MyString ToUpper()
    {
        string result = "";
        foreach (char c in _value)
            result += (c >= 'a' && c <= 'z') ? (char)(c - 32) : c;
        return new MyString(result);
    }

    // სტრინგის ყველა სიმბოლოს გადაყვანა პატარა ასოებზე
    public MyString ToLower()
    {
        string result = "";
        foreach (char c in _value)
            result += (c >= 'A' && c <= 'Z') ? (char)(c + 32) : c;
        return new MyString(result);
    }


    // ყოფს სტრინგს ნაწილებად მოცემული გამყოფი სიმბოლოების მიხედვით
    public string[] Split(char[] separators)
    {
        var parts = new List<string>();
        string current = "";
        foreach (char c in _value)
        {
            bool isSep = false;
            foreach (char sep in separators) if (c == sep) { isSep = true; break; }
            if (isSep) { parts.Add(current); current = ""; }
            else current += c;
        }
        parts.Add(current);
        return parts.ToArray();
    }

    // აერთიანებს სტრინგების მასივს გამყოფით
    public static MyString Join(string separator, string[] parts)
    {
        string result = "";
        for (int i = 0; i < parts.Length; i++)
        {
            result += parts[i];
            if (i < parts.Length - 1) result += separator;
        }
        return new MyString(result);
    }


    // ფორმატის სტრინგში {0} და {1} ჩანაცვლება მნიშვნელობებით
    public static MyString Format(string template, object a, object b)
    {
        string result = template
            .Replace("{0}", a.ToString())
            .Replace("{1}", b.ToString());
        return new MyString(result);
    }

    // სტრინგად გარდაქმნა

    override // ToString მეთოდის override (არ მახსოვს გავიარეთ თუ არა override, ამიტომ ცოდნის გამო არ დამაკლოთ პლზ :) )
    public string ToString() => _value;

    // ავსებს სტრინგს სფეისებით მარცხნიდან მოცემულ სიგრძემდე
    public MyString PadLeft(int totalWidth)
    {
        string result = _value;
        while (result.Length < totalWidth) result = " " + result;
        return new MyString(result);
    }

    // ავსებს სტრინგს სფეისებით მარჯვნიდან მოცემულ სიგრძემდე
    public MyString PadRight(int totalWidth)
    {
        string result = _value;
        while (result.Length < totalWidth) result += " ";
        return new MyString(result);
    }


    // ამოწმებს ყველა სიმბოლო აკმაყოფილებს თუ არა მოცემულ პირობას
    public bool All(Func<char, bool> predicate)
    {
        foreach (char c in _value) if (!predicate(c)) return false;
        return true;
    }

    // ამოწმებს რომელიმე სიმბოლო მაინც აკმაყოფილებს თუ არა მოცემულ პირობას
    public bool Any(Func<char, bool> predicate)
    {
        foreach (char c in _value) if (predicate(c)) return true;
        return false;
    }

    // ადარებს ორ სტრინგს, ignoreCase=true-ის შემთხვევაში რეგისტრს უგულებელყოფს
    public static int Compare(string s1, string s2, bool ignoreCase)
    {
        return string.Compare(s1, s2, ignoreCase);
    }


    // სტრინგს გარდაქმნის სიმბოლოების მასივად
    public char[] ToCharArray()
    {
        char[] arr = new char[Length];
        for (int i = 0; i < Length; i++) arr[i] = _value[i];
        return arr;
    }

    // სტრინგის ნაწილს კოპირებს სხვა მასივში მოცემულ პოზიციაზე
    public void CopyTo(int sourceIndex, char[] destination, int destinationIndex, int count)
    {
        for (int i = 0; i < count; i++)
            destination[destinationIndex + i] = _value[sourceIndex + i];
    }

    // ქმნის სტრინგის ზუსტ ასლს
    public MyString Clone() => new MyString(_value);

    // ბრუნდება სტრინგის intern ვერსიას მეხსიერების ოპტიმიზაციისთვის
    public string Intern() => string.Intern(_value);

    // კლასისთვის შევქმენით, რომ Length სთვის მნიშვნელობა
    // მიგვენიჭებინა ობიექტის შექმნისთანავე
    private int GetLength()
    {
        int length = 0;
        foreach (char c in _value) length++;
        return length;
    }
}

//კომენტარებზე და ფორმატირებაზე ხელი შემივლო კლაუდმა
//Ft. Claude 