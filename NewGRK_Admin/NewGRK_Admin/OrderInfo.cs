using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewGRK_Admin
{
    public enum OrderType { Change = 0, Problem = 1}
    public class OrderInfo:UserInfo
    {
        public OrderType OrderType { get; set; }
        public string OrderNum { get; set; }
        public string OrderName { get; set; }

        public OrderInfo 
            (
            string orderNum, 
            string orderName, 
            int orderType, 
            string userName, 
            string developerFolderPath
            ) :base (userName, developerFolderPath)
        {
            OrderNum = orderNum;
            OrderName = orderName;
            OrderType = (OrderType)orderType;
        }

    }
}
