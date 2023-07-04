using System.Collections.Generic;

public class Constants {
    public const string JoinKey = "j";
    public const string DifficultyKey = "d";
    public const string GameTypeKey = "t";

    public static readonly List<string> GameTypes = new() { "Single Player Game", "Group Play Game"};
    public static readonly List<string> Difficulties = new() { "Easy", "Medium", "Hard" };

    public enum InputType{ Join, Creat };

}