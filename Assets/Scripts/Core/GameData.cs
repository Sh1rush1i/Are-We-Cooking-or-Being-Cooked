public static class GameData
{
    public static int ShellJumpScore;
    public static int EggBeatsScore;
    public static int FeatherFlapsScore;

    public static int TotalScore =>
        ShellJumpScore + EggBeatsScore + FeatherFlapsScore;

    public static void ResetSession()
    {
        ShellJumpScore = 0;
        EggBeatsScore = 0;
        FeatherFlapsScore = 0;
    }
}
