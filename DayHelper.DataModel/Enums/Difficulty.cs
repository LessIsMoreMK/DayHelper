using System.ComponentModel;

namespace DayHelper.DataModel
{
    public enum Difficulty
    {
        [Description("Nie określono")]
        NotDefined = 0,
        [Description("Łatwy")]
        Easy = 1,
        Medium = 2,
        Hard = 3,
    }
}
