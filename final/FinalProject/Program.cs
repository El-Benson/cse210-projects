using System;
using System.Collections.Generic;

namespace GoalTrackerApp
{
    
    public abstract class Goal
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime Deadline { get; set; }
        public bool IsCompleted { get; set; }

        
        public abstract void RecordAchievement();

        
        public abstract void TrackProgress();

        
        public abstract void CalculateRewards();
    }

    
    public class SimpleGoal : Goal
    {
        public override void RecordAchievement()
        {
            IsCompleted = true;
            Console.WriteLine($"{Title} goal achieved!");
        }

        public override void TrackProgress()
        {
            
        }

        public override void CalculateRewards()
        {
            
        }
    }

    
    public class PerpetualGoal : Goal
    {
        public override void RecordAchievement()
        {
            Console.WriteLine($"{Title} goal recorded!");
        }

        public override void TrackProgress()
        {
            
        }

        public override void CalculateRewards()
        {
            
        }
    }

    
    public class ChecklistGoal : Goal
    {
        private int completionCount;
        private int requiredCompletions;

        public ChecklistGoal(int requiredCompletions)
        {
            this.requiredCompletions = requiredCompletions;
        }

        public override void RecordAchievement()
        {
            completionCount++;
            Console.WriteLine($"Achievement recorded for {Title}");
            if (completionCount >= requiredCompletions)
            {
                IsCompleted = true;
                Console.WriteLine($"{Title} goal completed!");
            }
        }

        public override void TrackProgress()
        {
            Console.WriteLine($"Progress: {completionCount}/{requiredCompletions}");
        }

        public override void CalculateRewards()
        {
            if (IsCompleted)
            {
                Console.WriteLine($"Congratulations! You've earned a bonus for completing {Title}");
            }
        }
    }

    
    public class GoalManager
    {
        private List<Goal> goals = new List<Goal>();

        
        public void AddGoal(Goal goal)
        {
            goals.Add(goal);
        }

        
        public void RecordAchievement(string goalTitle)
        {
            Goal goal = goals.Find(g => g.Title == goalTitle);
            if (goal != null)
            {
                goal.RecordAchievement();
                goal.TrackProgress();
                goal.CalculateRewards();
            }
            else
            {
                Console.WriteLine($"Goal '{goalTitle}' not found.");
            }
        }

        
        public void DisplayGoals()
        {
            Console.WriteLine("Current Goals:");
            foreach (var goal in goals)
            {
                Console.WriteLine($"- {goal.Title} ({(goal.IsCompleted ? "Completed" : "Incomplete")})");
            }
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            
            GoalManager goalManager = new GoalManager();

            
            goalManager.AddGoal(new SimpleGoal { Title = "Run 5 miles", Description = "Run 5 miles in one session", Deadline = DateTime.Today.AddDays(7) });
            goalManager.AddGoal(new PerpetualGoal { Title = "Read 30 minutes", Description = "Read for at least 30 minutes each day", Deadline = DateTime.MaxValue });
            goalManager.AddGoal(new ChecklistGoal(5) { Title = "Practice guitar", Description = "Practice guitar for 30 minutes each session", Deadline = DateTime.Today.AddDays(30) });

            
            goalManager.RecordAchievement("Run 5 miles");
            goalManager.RecordAchievement("Read 30 minutes");
            goalManager.RecordAchievement("Practice guitar");

            
            goalManager.DisplayGoals();
        }
    }
}

