Dictionary<int, string> difficultyLevel = new Dictionary<int, string>()
{
    { 1, "Easy" },
    { 2,"Medium"},
    {3,"Hard"}
};

Dictionary<string, int> chances = new Dictionary<string, int>()
{
    {"Easy", 10},
    { "Medium", 5},
    {"Hard",3}
};


Console.WriteLine("Welcome to the Number Guessing Game!\nI'm thinking of a number between 1 and 100.\n");
Console.WriteLine("Please select the difficulty level:\n1.Easy (10 chances)\n2.Medium (5 chances)\n3.Hard (3 chances)\n");

Console.Write("Enter your choice: ");
int choice = Convert.ToInt32(Console.ReadLine());

int attempts = chances[difficultyLevel[choice]];
Random random = new Random();
int randomNum = random.Next(1,101);

Console.WriteLine($"Great! You have selected the {difficultyLevel[choice]} difficulty level.\n");
Console.WriteLine($"You have {attempts} chances to guess the correct number\n");
Console.WriteLine("Lets's start the game!\n");

while(attempts > 0)
{
    Console.Write("Enter Your guess: ");
    int guess = Convert.ToInt32(Console.ReadLine());
    if(guess == randomNum)
    {
        attempts--;
        Console.WriteLine($"Congratulations! You guessed the correct number in {chances[difficultyLevel[choice]] - attempts} attempt(s).");
        break;
    }
    if(guess > randomNum)
    {
        Console.WriteLine($"Incorrect! the number is less than {guess}\n");
        attempts --;
        Console.WriteLine($"You have {attempts} attempts left\n");
    }
    if(guess < randomNum )
    {
        Console.WriteLine($"Incorrect the number is greater than {guess}");
        attempts--;
        Console.WriteLine($"You have {attempts} attempts left\n");
    }if(attempts == 0)
    {
        Console.WriteLine("Womp! Womp! Womp!");
        Console.WriteLine($"Game over! the number was {randomNum}");
    }
}
