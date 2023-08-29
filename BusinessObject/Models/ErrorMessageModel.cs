namespace BusinessObject.Models;

public class ErrorMessageModel
{
    public ErrorMessageModel(string title, string text)
    {
        Title = title;
        Text = text;
    }

    public string Title { get; }
    public string Text{ get; }
}