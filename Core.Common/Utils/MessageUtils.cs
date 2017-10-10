namespace Core.Common.Utils
{
    public class MessageUtils
    {
        public static string Err(string message)
        {
            return string.Format("<div class=\"alert alert-error\"><button class=\"close\" data-dismiss=\"alert\">×</button>{0}</div>", message);
        }

        public static string Infor(string message)
        {
            return string.Format("<div class=\"alert alert-info\"><button class=\"close\" data-dismiss=\"alert\">×</button>{0}</div>", message);
        }

        public static string Success(string message)
        {
            return string.Format("<div class=\"alert alert-success\"><button class=\"close\" data-dismiss=\"alert\">×</button>{0}</div>", message);
        }
    }
}
