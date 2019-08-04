using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NovellaStudio
{
    class MyExceptions
    {
        public class ScriptTextException : Exception
        {
            public new string Message() => "Неправильно заполнен файл скрипта!";
        }

        public class ScriptNotFoundException : Exception
        {
            public new string Message() => "Заданный скрипт не найден!";
        }
    }
}
