using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewGRK_Admin
{
    public enum OrderType { Change = 0, Problem = 1}

    [Serializable]
    public class OrderInfo
    {
        public OrderType OrderType { get; set; }
        public string OrderNum { get; set; }
        public string OrderName { get; set; }
        public ServerInfo ServerInfo { get; set; }
        public UserInfo UserInfo { get; set; }

        public string FullOrderName { get => GetFullOrderName(); }
        public string FullOrderNum { get => GetFullOrderNum(); }
        public string SQLFileFullName { get => GetSQLFileFullName(); }
        public string SQLFileName { get => GetSQLFileName(); }
        public string OrderDirectory { get => GetOrderDirectory(); }

        public OrderInfo() { }

        public OrderInfo
            (
            string orderNum,
            string orderName,
            OrderType orderType,
            ServerInfo serverInfo,
            UserInfo userInfo
            )
        {
            OrderNum = orderNum;
            OrderName = orderName;
            OrderType = orderType;
            ServerInfo = serverInfo;
            UserInfo = userInfo;
        }

        private string GetFullOrderNum()
        {
            string orderNum = (!String.IsNullOrEmpty(OrderNum)) ? OrderNum : String.Empty;
            if (!String.IsNullOrEmpty(orderNum))
            {
                orderNum = $"SP{orderNum}_{SetOrderPostfix(OrderType)}";
            }
            return orderNum;
        }

        private string GetFullOrderName()
        {
            string tmpFullorderName = String.Empty;

            tmpFullorderName = $"{FullOrderNum}{((!String.IsNullOrEmpty(OrderName)) ? $" ({OrderName})" : String.Empty)}";
            return tmpFullorderName;
        }

        private string GetSQLFileFullName()
        {
            return OrderDirectory + Path.DirectorySeparatorChar.ToString() + SQLFileName;
        }

        private string GetSQLFileName()
        {
            string tmpSQLFileName = String.Empty;
            tmpSQLFileName = $"{FullOrderNum}{((!String.IsNullOrEmpty(OrderName)) ? $" ({OrderName})" : String.Empty)}";

            
            tmpSQLFileName = ClearInvalidFileChars(tmpSQLFileName);
            return tmpSQLFileName+".sql";
        }

        private string GetOrderDirectory()
        {
            string tmpOrderDirectory = String.Empty;
            tmpOrderDirectory = $"{((!String.IsNullOrEmpty(OrderNum)) ? $"[{OrderNum}] - " : String.Empty)}{OrderName}";
            tmpOrderDirectory = ClearInvalidPathChars(tmpOrderDirectory);
            tmpOrderDirectory = UserInfo.DeveloperFolderPath + Path.DirectorySeparatorChar.ToString() + tmpOrderDirectory;
            return tmpOrderDirectory;
        }

        private string SetOrderPostfix(OrderType orderType)
        {
            string res = String.Empty;
            switch (orderType)
            {
                case OrderType.Change:
                    res = "CH";
                    break;
                case OrderType.Problem:
                    res = "P";
                    break;
                default:
                    res = String.Empty;
                    break;
            }
            return res;
        }

        private string ClearInvalidPathChars(string input)
        {

            char[] invPathChars = Path.GetInvalidPathChars();
            char[] invChars = {'\\', '/',':','*','?','"','<','>','|','+','%','!','@'};
            string output = input;
            foreach (char ch in invPathChars)
            {
                output = output.Replace(ch.ToString(), String.Empty);
            }
            foreach (char ch in invChars)
            {
                output = output.Replace(ch.ToString(), String.Empty);
            }
            return output;
        }

        private string ClearInvalidFileChars(string input)
        {
            char[] invFileNameChars = Path.GetInvalidFileNameChars();
            char[] invChars = { '\\', '/', ':', '*', '?', '"', '<', '>', '|', '+', '%', '!', '@' };
            string output = input;
            foreach (char ch in invFileNameChars)
            {
                output = output.Replace(ch.ToString(), String.Empty);
            }
            foreach (char ch in invChars)
            {
                output = output.Replace(ch.ToString(), String.Empty);
            }
            return output;
        }

        public override string ToString()
        {
            return this.FullOrderName;
        }
    }
}
