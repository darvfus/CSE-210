using System;

public class Assignment
{
    private string _studentName {get; set;}
    private string _topic {get; set;}

    public Assignment(string studentName, string topic)
    {
        _studentName = studentName;
        _topic = topic;
    }

    public string GetStudentName()
    {
        return _studentName;
    }
    public string GetTopic()
    {
        return _topic;
    }
    public string GetSummary()
    {
        return _studentName + " -" +  _topic;
    }
}