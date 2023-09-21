using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW_7_Accounting_of_goods_
{
    public interface ICommodityManagement
    {
        void Add(int count);
        void Sell(int count);
        void Dispose(int count);
        void Transfer (int count, string export );
    }

    public interface IGenID
    {
        int GetID(int ID);
    }
}
