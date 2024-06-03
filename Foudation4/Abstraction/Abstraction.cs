using System;
using System.Collections.Generic;

public class Comment
{
    private string _commenterName;
    private string _text;

    public Comment(string commenterName, string text)
    {
        _commenterName = commenterName;
        _text = text;
    }

    public string GetCommenterName() => _commenterName;
    public string GetText() => _text;
}

public class Video
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

    public int GetCommentCount() => _comments.Count;

    public string GetTitle() => _title;
    public string GetAuthor() => _author;
    public int GetLength() => _length;
    public List<Comment> GetComments() => _comments;
}

public class Program
{
    public static void Main(string[] args)
    {
        List<Video> videos = new List<Video>();

        Video video1 = new Video("How to Cook Pasta", "Chef John", 600);
        video1.AddComment(new Comment("Alice", "Great recipe!"));
        video1.AddComment(new Comment("Bob", "Tried it and loved it!"));
        video1.AddComment(new Comment("Charlie", "Will try this weekend."));

        Video video2 = new Video("Yoga for Beginners", "YogaWithAdriene", 1800);
        video2.AddComment(new Comment("Dave", "Feeling relaxed already."));
        video2.AddComment(new Comment("Eve", "Perfect for starting my day."));
        video2.AddComment(new Comment("Frank", "Loved the session."));

        Video video3 = new Video("Travel Vlog: Japan", "TravelWithMe", 1200);
        video3.AddComment(new Comment("Grace", "Amazing views!"));
        video3.AddComment(new Comment("Heidi", "Can't wait to visit Japan."));
        video3.AddComment(new Comment("Ivan", "Great tips for travelers."));

        videos.Add(video1);
        videos.Add(video2);
        videos.Add(video3);

        foreach (Video video in videos)
        {
            Console.WriteLine($"Title: {video.GetTitle()}");
            Console.WriteLine($"Author: {video.GetAuthor()}");
            Console.WriteLine($"Length: {video.GetLength()} seconds");
            Console.WriteLine($"Number of Comments: {video.GetCommentCount()}");

            foreach (Comment comment in video.GetComments())
            {
                Console.WriteLine($"Comment by {comment.GetCommenterName()}: {comment.GetText()}");
            }
            Console.WriteLine();
        }
    }
}
