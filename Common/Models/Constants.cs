using System;
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

    public static class ModuleAccess
    {
        public const int MsgBoardManagement = 10101;
        public const int NewLetters = 10201;
        public const int StandardForms = 10202;
    }
}
