using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Buber.Contracts.Breakfast
{
    public record BreakfastResponse(
        Guid Id,
        string Name,
        string Description,
        DateTime StartDateTime,
        DateTime EndDateTime,
        DateTime LastModifiedDataTime,
        List<string> Savory,
        List<string> Sweet);
}
