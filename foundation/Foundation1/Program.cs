using System;
using System.Collections.Generic;

class Video
{
    private string _title;
    private string _author;
    private int _length; // in seconds
    private List<Comment> _comments;

    public Video(string title, string author, int length)
    {
        _title = title;
        _author = author;
        _length = length;
        _comments = new List<Comment>();
    }

    public void AddComment(Comment comment)
    {
        _comments.Add(comment);
    }

    public int GetNumberOfComments()
    {
        return _comments.Count;
    }

    public void DisplayVideoDetails()
    {
        Console.WriteLine($"Title: {_title}, Author: {_author}, Length: {_length} seconds");
        Console.WriteLine($"Number of comments: {GetNumberOfComments()}");
        Console.WriteLine("Comments:");
        foreach (var comment in _comments)
        {
            Console.WriteLine($"- {comment.GetCommenterName()}: {comment.GetText()}");
        }
        Console.WriteLine();
    }
}

class Comment
{
    private string _commenterName;
    private string _text;

    public Comment(string commenterName, string text)
    {
        _commenterName = commenterName;
        _text = text;
    }

    public string GetCommenterName()
    {
        return _commenterName;
    }

    public string GetText()
    {
        return _text;
    }
}

class Program
{
    static void Main(string[] args)
    {
        // Create three videos
        Video video1 = new Video("Mastering C# Basics", "Tech University", 1200);
        Video video2 = new Video("Understanding Design Patterns", "Coding Academy", 900);
        Video video3 = new Video("Object-Oriented Programming Explained", "Dev Learn", 1500);

        // Add three comments to each video
        video1.AddComment(new Comment("John", "This video was really informative."));
        video1.AddComment(new Comment("Jane", "Great explanations!"));
        video1.AddComment(new Comment("Sam", "Please make a follow-up video!"));

        video2.AddComment(new Comment("Alice", "Helped me understand design patterns."));
        video2.AddComment(new Comment("Bob", "Fantastic examples, thanks!"));
        video2.AddComment(new Comment("Charlie", "Clear and concise!"));

        video3.AddComment(new Comment("David", "OOP explained so well!"));
        video3.AddComment(new Comment("Eva", "This was exactly what I needed."));
        video3.AddComment(new Comment("Frank", "Looking forward to more content."));

        // Store videos in a list
        List<Video> videos = new List<Video> { video1, video2, video3 };

        // Display details for each video
        foreach (var video in videos)
        {
            video.DisplayVideoDetails();
        }
    }
}
