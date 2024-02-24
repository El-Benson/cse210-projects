using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

class Goal {
    protected string name;
    protected int value;
    protected bool completed;

    public Goal(string name) {
        this.name = name;
        this.value = 0;
        this.completed = false;
    }

    public virtual void RecordEvent() {
        value++;
    }

    public virtual void CompleteGoal() {
        completed = true;
    }

    public override string ToString() {
        string status = completed ? "Completed" : "Incomplete";
        return $"{name} - {status} | Value: {value}";
    }
}

class SimpleGoal : Goal {
    public SimpleGoal(string name) : base(name) { }

    public override void RecordEvent() {
        base.RecordEvent();
    }
}

class EternalGoal : Goal {
    public EternalGoal(string name) : base(name) { }
}

class ChecklistGoal : Goal {
    private int targetCount;
    private int bonusPoints;

    public ChecklistGoal(string name, int targetCount, int bonusPoints) : base(name) {
        this.targetCount = targetCount;
        this.bonusPoints = bonusPoints;
    }

    public override void RecordEvent() {
        base.RecordEvent();
        if (value == targetCount) {
            value += bonusPoints;
            completed = true;
        }
    }
}

class EternalQuest {
    private List<Goal> goals;
    private int score;

    public EternalQuest() {
        goals = new List<Goal>();
        score = 0;
    }

    public void AddGoal(Goal goal) {
        goals.Add(goal);
    }

    public void RecordEvent(int index) {
        goals[index].RecordEvent();
        UpdateScore();
    }

    private void UpdateScore() {
        score = goals.Sum(g => g.value);
    }

    public void DisplayGoals() {
        foreach (var goal in goals) {
            Console.WriteLine(goal);
        }
    }

    public void DisplayScore() {
        Console.WriteLine($"Current Score: {score}");
    }

    public void SaveProgress(string filename) {
        using (StreamWriter writer = new StreamWriter(filename)) {
            foreach (var goal in goals) {
                writer.WriteLine($"{goal.GetType().Name},{goal}");
            }
            writer.WriteLine($"Score,{score}");
        }
    }

    public void LoadProgress(string filename) {
        goals.Clear();
        using (StreamReader reader = new StreamReader(filename)) {
            string line;
            while ((line = reader.ReadLine()) != null) {
                string[] parts = line.Split(',');
                if (parts[0] == "SimpleGoal") {
                    SimpleGoal goal = new SimpleGoal(parts[1]);
                    goal.RecordEvent();
                    goals.Add(goal);
                } else if (parts[0] == "EternalGoal") {
                    EternalGoal goal = new EternalGoal(parts[1]);
                    goal.RecordEvent();
                    goals.Add(goal);
                } else if (parts[0] == "ChecklistGoal") {
                    string[] goalInfo = parts[1].Split('|');
                    string name = goalInfo[0];
                    string status = goalInfo[1].Split('-')[1].Trim();
                    int value = int.Parse(goalInfo[2].Split(':')[1]);
                    ChecklistGoal goal = new ChecklistGoal(name, 0, 0);
                    goal.RecordEvent();
                    if (status == "Completed") {
                        goal.CompleteGoal();
                    }
                    goals.Add(goal);
                } else if (parts[0] == "Score") {
                    score = int.Parse(parts[1]);
                }
            }
        }
    }
}

// This C# code implements an "Eternal Quest" program to track various types of goals, including simple goals, eternal goals, and checklist goals. It utilizes inheritance, polymorphism, encapsulation, and abstraction to ensure a well-structured and extensible design. The program allows users to add goals, record events, display goals and scores, and save/load progress. Additionally, it includes the functionality to handle different types of goals and their completion criteria.
