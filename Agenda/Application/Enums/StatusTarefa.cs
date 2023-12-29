using System.ComponentModel;

namespace Agenda.Application.Enums
{
    public enum StatusTarefa
    {
        [Description("A fazer")]
        AFazzer = 1,
        [Description("Em andamento")]
        EmAndamento = 2,
        [Description("Concluído")]
        Concluido = 3
    }
}
