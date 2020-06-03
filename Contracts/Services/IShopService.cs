using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contracts.Services
{
    public interface IShopService:IDomainEntityServices<Shop>
    {
        IList<Customer> FindAllCustomers();
        IList<Equipment> FindAllEquipment();

        Equipment FindAllEquipmentPerId(int? id);
        Customer FindAllCustomersPerId(int? id);

        IList<Shop> FindCheaper(int Price);

        IList<Shop> FindExpensive(int Price);

        IList<Shop> FindBetween(int MinPrice, int MaxPrice);
    }
}
