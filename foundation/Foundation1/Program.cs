using System;
using System.Collections.Generic;

class Video
{
    public string Title { get; set; }
    public string Author { get; set; }
    public int Length { get; set; } // length in seconds
    private List<Comment> Comments { get; set; }

    public Video(string title, string author, int length)
    {
        Title = title;
        Author = author;
        Length = length;
        Comments = new List<Comment>();
    }

    public void AddComment(Comment comment)
    {
        Comments.Add(comment);
    }

    public int GetNumberOfComments()
    {
        return Comments.Count;
    }

    public void DisplayVideoDetails()
    {
        Console.WriteLine($"Title: {Title}, Author: {Author}, Length: {Length} seconds");
        Console.WriteLine($"Number of comments: {GetNumberOfComments()}");
        Console.WriteLine("Comments:");
        foreach (var comment in Comments)
        {
            Console.WriteLine($"- {comment.CommenterName}: {comment.Text}");
        }
        Console.WriteLine();
    }
}

class Comment
{
    public string CommenterName { get; set; }
    public string Text { get; set; }

    public Comment(string commenterName, string text)
    {
        CommenterName = commenterName;
        Text = text;
    }
}

class Program
{
    static void Main(string[] args)
    {
        // Create videos
        Video video1 = new Video("Learn C# in 10 minutes", "Code Academy", 600);
        Video video2 = new Video("Understanding OOP Principles", "Tech Guru", 720);
        Video video3 = new Video("C# Abstraction Example", "Programming with Alex", 480);

        // Add comments to video1
        video1.AddComment(new Comment("John", "Great tutorial!"));
        video1.AddComment(new Comment("Sarah", "Very helpful, thanks!"));
        video1.AddComment(new Comment("Mike", "Can you make a video on inheritance?"));

        // Add comments to video2
        video2.AddComment(new Comment("Anna", "Clear explanation of OOP concepts."));
        video2.AddComment(new Comment("Tom", "Loved the examples!"));

        // Add comments to video3
        video3.AddComment(new Comment("Emily", "Short and concise."));
        video3.AddComment(new Comment("James", "Thanks for the quick overview."));
        video3.AddComment(new Comment("Sophia", "Looking forward to more videos like this."));

        // Store videos in a list
        List<Video> videos = new List<Video> { video1, video2, video3 };

        // Display details for each video
        foreach (var video in videos)
        {
            video.DisplayVideoDetails();
        }
    }
}
