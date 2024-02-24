using System;
using System.Collections.Generic;
using System.Linq;
class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Hello Develop04 World!");
    }
}


class MindfulnessActivity {
    protected int duration;

    public MindfulnessActivity(int duration) {
        this.duration = duration;
    }

    public void Start() {
        DisplayStartingMessage();
        PerformActivity();
        DisplayEndingMessage();
    }

    protected virtual void DisplayStartingMessage() {
        Console.WriteLine("Starting the activity...");
        // Display common starting message
    }

    protected virtual void PerformActivity() {
        // Perform common activity
    }

    protected virtual void DisplayEndingMessage() {
        Console.WriteLine("Congratulations! You've completed the activity.");
        // Display common ending message
    }
}

class BreathingActivity : MindfulnessActivity {
    public BreathingActivity(int duration) : base(duration) { }

    protected override void PerformActivity() {
        Console.WriteLine("Breathe in...");
        // Perform breathing activity
        Console.WriteLine("Breathe out...");
    }
}

class ReflectionActivity : MindfulnessActivity {
    public ReflectionActivity(int duration) : base(duration) { }

    protected override void PerformActivity() {
        Console.WriteLine("Think deeply about the prompt...");
        // Perform reflection activity
    }
}

class ListingActivity : MindfulnessActivity {
    public ListingActivity(int duration) : base(duration) { }

    protected override void PerformActivity() {
        Console.WriteLine("List as many items as you can...");
        // Perform listing activity
    }
}

class Program {
    static void Main(string[] args) {
        BreathingActivity breathingActivity = new BreathingActivity(60);
        breathingActivity.Start();

        ReflectionActivity reflectionActivity = new ReflectionActivity(120);
        reflectionActivity.Start();

        ListingActivity listingActivity = new ListingActivity(90);
        listingActivity.Start();
    }
}


