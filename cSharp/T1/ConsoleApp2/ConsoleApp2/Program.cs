﻿// See https://aka.ms/new-console-template for more information

using System.Runtime.CompilerServices;
using inputHander;

namespace inputHander;
using System.IO;

class sourceHander
{
    public string sourceFile = "C:\\Users\\songy\\Desktop\\code_file\\sourceFile.txt";
    public string sourceText;
    public string destinationText;
    public string destinationFile = "C:\\Users\\songy\\Desktop\\code_file\\destinationText.txt";
    StreamReader SR;
    StreamWriter SW;

    Dictionary<string, string> replacements = new Dictionary<string, string>()
    {
        
        {"+", " " },
        {"  ", " "},
        {"a", "b" }

    };

    private static sourceHander instance = null;


    private sourceHander()
    {
        
    }

    public static sourceHander Instance
    {
        get
        {
            if (instance == null)
            {
                instance = new sourceHander();
            }

            return instance;
        }
        
    }

    public void SaveToFile()
    {
        try
        {
            SW = new StreamWriter(File.OpenWrite(this.destinationFile));
            SW.Write(sourceText);
            SW.Close();
            Console.WriteLine("Success to Write File.");
        }
        catch (IOException IOe)
        {
            Console.WriteLine(IOe);
            throw;
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
        }
    }

    public void openFile() 
    {
        try {
            SR = new StreamReader(File.OpenRead(this.sourceFile));
            sourceFile = SR.ReadToEnd();
            sourceText = sourceFile;
            SR.Close();
        }
        catch(IOException o) { 
            Console.WriteLine("IO error appear by {0}", o.Message);
        }
        catch (Exception xo)
        {
            Console.WriteLine("other error appear by {0}", xo.Message);
        }

    }

    public void replaceText()
    {
        foreach (var x in replacements)
        {
            while (sourceText.Contains(x.Key))
            {
                this.sourceText = sourceText.Replace(x.Key, x.Value);
            }
        }

        this.destinationText = this.sourceText;

    }

    public void Run()
    {
        Console.WriteLine("The origin Text : ");
        openFile();
        Console.WriteLine(sourceText);
        Console.WriteLine("-------------------------------------------------------");
        replaceText();
        Console.WriteLine("The fixed Text : ");
        Console.WriteLine(destinationText);
        SaveToFile();
    }
}





class Program
{
    static void Main(string[] args)
    {
        sourceHander hander = sourceHander.Instance;
        hander.Run();
    }
}