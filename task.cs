// See https://aka.ms/new-console-template for more information
namespace regexMain;
using System.Text.RegularExpressions;

class regexText
{
    public string input;
    string dest;

    public regexText(string input) { 
    this.input = input;
    
    }

    public string replace(string s, string s2) {
    
    return Regex.Replace(input, s, s2);    
    
    }

    public bool find(string s) {

        if (Regex.IsMatch(input, s))
        {
            return true;
        }
        return true;
    }
    public void mainLoop()
    {
        Console.WriteLine("Hello");
    }

}
