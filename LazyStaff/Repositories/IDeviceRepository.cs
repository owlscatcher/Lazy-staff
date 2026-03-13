using System.Collections.Generic;
using LazyStaff.Models;

namespace LazyStaff.Repositories
{
    interface IDeviceRepository
    {
        IEnumerable<Device> GetAll();
        Device GetById(int id);
        void Add(Device device);
        void Update(Device device);
        void Delete(int id);
    }
}
