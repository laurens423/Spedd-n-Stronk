using Godot;
using System;
using Godot.Collections;


public class SaveFileFormat
{
    public static Dictionary<string,string> format = new Dictionary<string, string>()
    {
        {"Scene", "0"},
        {"Position", "0,0"},
        {"Character", "Stronk"},
        {"Progress", "0"}
    };
    public static Dictionary<string,string> getFormat(){
        return format;
    }
}
