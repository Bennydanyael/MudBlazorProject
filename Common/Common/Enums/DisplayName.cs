﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Common.Common.Enums
{
    public static class DisplayName
    {
        public static string GetDisplayName(this Enum enumValue)
        {
            return enumValue
            .GetType()
            .GetMember(enumValue.ToString())
            .First()?
            .GetCustomAttribute<DisplayAttribute>()?
            .Name;
        }
    }
}
