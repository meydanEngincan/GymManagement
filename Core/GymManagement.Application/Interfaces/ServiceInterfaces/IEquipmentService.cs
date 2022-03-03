using GymManagement.Application.Interfaces.UnitOfWorks;
using GymManagement.Application.ViewModels.EquipmentViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GymManagement.Application.Interfaces.ServiceInterfaces
{
    public interface IEquipmentService
    {
        public List<EquipmentQueryViewModel> GetEquipmentsWithTrainer();
        EquipmentQueryViewModel GetById(int id);
        bool Create(EquipmentCommandViewModel model);
        bool Update(EquipmentCommandViewModel model, int id);
        bool Delete(int id);
    }
}
