using SmartEngineer.Core.Models;
using System.Collections.Generic;

namespace SmartEngineer.Core.Adapter
{
    public interface IConfigAdapter
    {
        Dictionary<string, dynamic> GeSubTaskTemplates(string project);
    }
}
