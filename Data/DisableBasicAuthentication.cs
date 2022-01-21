using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Projekt_ASP.Data
{
    public class DisableBasicAuthentication: Attribute, IFilterMetadata
    {

    }
}
