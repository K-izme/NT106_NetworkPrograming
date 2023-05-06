// See https://aka.ms/new-console-template for more information
// Online C# Editor for free
// Write, Edit and Run your C# code using C# Online Compiler

using System;
using System.Data;
using System.Text;



String makeFlag(String s)
{
    String a = "" + s[5];
    String _b = s[2] + "";
    for (int s_ = 0; s_ < s.Length; s_++)
    {
        String b = _b.Substring(_b.Length - s_) + _b.Substring(s_);
        String _b2 = s_ >= 3 ? _b + s[s_ - 3] + "" : _b + s[s.Length - (3 - s_)] + "";
        if (s_ >= _b2.Length)
        {
            _b = _b2 + s[s_ - _b2.Length] + "";
        }
        else if (s.Length >= _b2.Length - s_)
        {
            _b = _b2 + s[s.Length - (_b2.Length - s_)] + "";
        }
        else
        {
            _b = _b2 + s[s.Length - ((_b2.Length - s_) - s.Length)] + "";
        }
        a = a + b[(((s.Length + _b.Length) * s_) + _b.Length) % b.Length];
    }
    return a.Substring(0, 2) + s[3] + a[3] + '0' + a.Substring(5, 7);
}

string seed = "7f0f007a";

Console.WriteLine(makeFlag(seed));
int x = 83150421;
Console.WriteLine(x.ToString());
 