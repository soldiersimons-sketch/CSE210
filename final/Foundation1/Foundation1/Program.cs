using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        List<Video> videos = new List<Video>();

        Video video1 = new Video("Learning C# Programming", "Code Academy", 600);
        video1.AddComment(new Comment("Alice", "This was very helpful!"));
        video1.AddComment(new Comment("Bob", "Great explanation."));
        video1.AddComment(new Comment("Sarah", "I learned a lot."));
        videos.Add(video1);

        Video video2 = new Video("Object-Oriented Programming", "Tech Tutorials", 720);
        video2.AddComment(new Comment("David", "Excellent tutorial!"));
        video2.AddComment(new Comment("Emma", "Very easy to understand."));
        video2.AddComment(new Comment("James", "Thanks for sharing."));
        videos.Add(video2);

        Video video3 = new Video("Understanding C# Classes", "Programming Basics", 540);
        video3.AddComment(new Comment("Olivia", "Really useful video."));
        video3.AddComment(new Comment("Michael", "Good examples."));
        video3.AddComment(new Comment("Sophia", "This helped with my homework."));
        videos.Add(video3);

        Console.WriteLine("YouTube Video Information");
        Console.WriteLine("=========================");
        foreach (Video video in videos)
            video.DisplayVideo();
    }
}
