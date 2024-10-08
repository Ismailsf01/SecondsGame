using System;
using System.Collections.Generic;

//Writing the time formula first
int seconds = 0;
int minutes = 0;

Random random = new Random();
int number = random.Next(0, 501);
Console.WriteLine($"The number to convert is {number}, type your guess in MM:SS format then press Enter.");


while (number >= 60)
{
    minutes++;
    number -= 60;
}

if (number > 0 && number < 60)
{
    seconds = number;
}

//looping to give the guesser 3 attempts
for (int i = 3; i != 0; i--)
{
    Console.WriteLine("You have {0} guesses left", i);
    string? userInput;
    string[] seperatedInput = { };

    //Reading user's input
    userInput = Console.ReadLine();

    //Making sure the input is not null and only contains two parts
    if (userInput != null)
        seperatedInput = userInput.Split(":");

    while (userInput == null || seperatedInput.Length != 2)
    {
        Console.WriteLine("Please enter a valid guess");
        userInput = Console.ReadLine();
        if (userInput != null)
            seperatedInput = userInput.Split(":");
    }

    string minutesGuess = "";
    string secondsGuess = "";

    int convertedMinutesGuess = 0;
    int convertedSecondsGuess = 0;

    minutesGuess = seperatedInput[0];
    secondsGuess = seperatedInput[1];

    //Making sure the input contains only numbers
    while (int.TryParse(minutesGuess, out convertedMinutesGuess) == false || int.TryParse(secondsGuess, out convertedSecondsGuess) == false)
    {
        Console.WriteLine("Please enter a valid guess");
        userInput = Console.ReadLine();
        if (userInput != null)
            seperatedInput = userInput.Split(":");
    }

    minutesGuess = seperatedInput[0];
    secondsGuess = seperatedInput[1];

    //Making the final if-else logic to write to console
    if (int.TryParse(minutesGuess, out convertedMinutesGuess) || int.TryParse(secondsGuess, out convertedSecondsGuess))
    {
        if (convertedMinutesGuess == minutes && convertedSecondsGuess == seconds)
        {
            string smiley = "😃";
            Console.WriteLine("Congratulations you did great {0}", smiley);
            break;
        }
        else if (convertedMinutesGuess == minutes && convertedSecondsGuess != seconds)
        {
            if (convertedSecondsGuess > seconds)
            {
                Console.WriteLine("You got the minutes right, but the seconds are higher");
            }
            else if (convertedSecondsGuess < seconds)
            {
                Console.WriteLine("You got the minutes right, but the seconds are lower");
            }
        }
        else if (convertedMinutesGuess != minutes && convertedSecondsGuess == seconds)
        {
            if (convertedMinutesGuess > minutes)
            {
                Console.WriteLine("You got the seconds right, but the minutes are higher");
            }
            else if (convertedMinutesGuess < minutes)
            {
                Console.WriteLine("You got the seconds right, but the minutes are lower");
            }
        }
        else if (convertedMinutesGuess != minutes && convertedSecondsGuess != seconds)
        {
            if (convertedMinutesGuess > minutes && convertedSecondsGuess > seconds)
                Console.WriteLine("You got none right, both the minutes and seconds are higher!");
            else if (convertedMinutesGuess < minutes && convertedSecondsGuess < seconds)
                Console.WriteLine("You got none right, both the minutes and seconds are lower!");
            else if (convertedMinutesGuess > minutes && convertedSecondsGuess < seconds)
                Console.WriteLine("You got none right, the minutes are higher and the seconds are lower!");
            else if (convertedMinutesGuess < minutes && convertedSecondsGuess > seconds)
                Console.WriteLine("You got none right, the minutes are lower and the seconds are higher!");
        }
    }
}