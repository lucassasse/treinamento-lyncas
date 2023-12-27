using System.ComponentModel;

namespace WebAPI.Enums
{
    public enum StatusTask
    {
        [Description("To do")]
        ToDo = 1,
        [Description("In Progress")]
        InProgress = 2,
        [Description("Concluded")]
        Concluded = 3
    }
}
