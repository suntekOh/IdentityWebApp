﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Models;

public static class Constants
{
    public static class Role
    {
        public const string Administrator = nameof(Administrator);
        public const string Member = nameof(Member);
    }

    public static class Module
    {
        public const int MsgBoardManagement = 101;
        public const int Documents = 102;
    }
}
