﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheZ.Shared.DataTransferObjects
{
    public record CompanyDto(Guid Id, string name, string FullAddress);
    public record EmployeeDto(Guid Id, string Name, int Age, string Position);
}
