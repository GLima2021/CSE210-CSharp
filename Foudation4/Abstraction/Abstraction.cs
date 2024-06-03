using System;
using System.Collections.Generic;

#region Comment Class
// Represents a comment with a commenter's name and text
public class Comment
{
    private string _commenterName;
    private string _text;

    public Comment(string commenterName, string text)
    {
        _commenterName = commenterName;
        _text = text;
    }

    // Returns the name of the commenter
    public string GetCommenterName() => _commenterName;

    // Returns the text of the comment
    public string GetText() => _text;
}
#endregion

#region Video Class
// Represents a video with a title, author, length, and list of comments
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

    // Adds a comment to the video's comment list
    public void AddComment(Comment comment)
    {
        _comments.Add(comment);
    }

    // Returns the number of comments on the video
    public int GetCommentCount() => _comments.Count;

    // Returns the title of the video
    public string GetTitle() => _title;

    // Returns the author of the video
    public string GetAuthor() => _author;

    // Returns the length of the video in seconds
    public int GetLength() => _length;

    // Returns the list of comments on the video
    public List<Comment> GetComments() => _comments;
}
#endregion

#region Program Class
// Main program to create and display videos with their comments
public class Program
{
    public static void Main(string[] args)
    {
        // Creating a list to store videos
        List<Video> videos = new List<Video>();

        // Creating and adding comments to the first video
        Video video1 = new Video("How to Cook Pasta", "Chef John", 600);
        video1.AddComment(new Comment("Alice", "Great recipe!"));
        video1.AddComment(new Comment("Bob", "Tried it and loved it!"));
        video1.AddComment(new Comment("Charlie", "Will try this weekend."));

        // Creating and adding comments to the second video
        Video video2 = new Video("Yoga for Beginners", "YogaWithAdriene", 1800);
        video2.AddComment(new Comment("Dave", "Feeling relaxed already."));
        video2.AddComment(new Comment("Eve", "Perfect for starting my day."));
        video2.AddComment(new Comment("Frank", "Loved the session."));

        // Creating and adding comments to the third video
        Video video3 = new Video("Travel Vlog: Japan", "TravelWithMe", 1200);
        video3.AddComment(new Comment("Grace", "Amazing views!"));
        video3.AddComment(new Comment("Heidi", "Can't wait to visit Japan."));
        video3.AddComment(new Comment("Ivan", "Great tips for travelers."));

        // Adding all videos to the list
        videos.Add(video1);
        videos.Add(video2);
        videos.Add(video3);

        // Displaying details of each video and its comments
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
#endregion
