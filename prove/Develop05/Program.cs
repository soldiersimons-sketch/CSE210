
using System;

// CSE 210 - Unit 05: Eternal Quest
//
// EXCEEDING REQUIREMENTS:
// 1. Added a leveling system. Players gain one level for every
//    1,000 points and receive a celebration when leveling up.
// 2. Eternal goals track how many times they have been recorded.
// 3. Added input validation to prevent invalid entries.
// 4. Added error handling when saving and loading files.
// 5. Goal information is encoded to preserve special characters
//    when saving and loading.

class Program
{
    static void Main(string[] args)
    {
        GoalManager manager = new GoalManager();
        manager.Start();
    }
}
