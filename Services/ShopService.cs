using Contracts.Repositories;
using Contracts.Services;
using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public class ShopService : DomainEntityServices<Shop>, IShopService
    {
        IRepository<Shop> _repoShop;
        IRepository<Equipment> _repoEquipment;
        IRepository<Customer> _repoCustomer;

        public ShopService(IRepository<Shop> repoShop, IRepository<Equipment> repoEquipment, IRepository<Customer> repoCustomer) : base(repoShop)
        {
            _repoShop = repoShop;
            _repoEquipment = repoEquipment;
            _repoCustomer = repoCustomer;
        }

        public IList<Customer> FindAllCustomers()
        {
            return _repoCustomer.FindAll().ToList<Customer>();
        }

        public Customer FindAllCustomersPerId(int? id)
        {
            return _repoCustomer.Find(id);
        }

        public IList<Equipment> FindAllEquipment()
        {
            return _repoEquipment.FindAll().ToList<Equipment>();
        }

        public Equipment FindAllEquipmentPerId(int? id)
        {
            return _repoEquipment.Find(id);
        }

        public IList<Shop> FindBetween(int MinPrice, int MaxPrice)
        {
            IList<Shop> dd = _repoShop.FindAll().Where(d => d.Price <= MaxPrice && d.Price >= MinPrice).ToList<Shop>();
            return dd;
        }

        public IList<Shop> FindCheaper(int Price)
        {
            return _repoShop.FindAll().Where(d => d.Price < Price + 1).ToList<Shop>();
        }

        public IList<Shop> FindExpensive(int Price)
        {
            return _repoShop.FindAll().Where(d => d.Price > Price - 1).ToList<Shop>();
        }
    }
}
