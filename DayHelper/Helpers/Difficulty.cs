using System.ComponentModel;

namespace DayHelper
{
    public enum Difficulty
    {
        [Description("Nie określono")]
        NotDefined = 0,
        [Description("Łatwy")]
        Easy = 1,
        [Description("Średni")]
        Medium = 2,
        [Description("Trudny")]
        Hard = 3,
    }
}
