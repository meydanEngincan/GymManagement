using AutoMapper;
using GymManagement.Application.Interfaces.ServiceInterfaces;
using GymManagement.Application.Interfaces.UnitOfWorks;
using GymManagement.Application.ViewModels.EquipmentViewModel;
using GymManagement.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GymManagement.Application.Services
{
    public class EquipmentServices : IEquipmentService
    {
        private readonly IUnitOfWork _unitOfWork;
        readonly IMapper _mapper;

        public EquipmentServices(IUnitOfWork unitofWork,IMapper mapper)
        {
            _unitOfWork = unitofWork;
            _mapper = mapper;
        }

        public bool Create(EquipmentCommandViewModel model)
        {
            var equipment = _mapper.Map<Equipment>(model);
            _unitOfWork.Equipments.Create(equipment);
            if (_unitOfWork.SaveChanges())
            {
                return true;
            }
            return false;

        }

        public bool Delete(int id)
        {
            var equipment = _unitOfWork.Equipments.GetById(id);
            if (equipment == null)
            {
                throw new InvalidOperationException("Campaign  not found");
            }
            equipment.IsDeleted = true;
            _unitOfWork.Equipments.Update(equipment);
            if (_unitOfWork.SaveChanges())
            {
                return true;
            }
            return false;

        }

        public EquipmentQueryViewModel GetById(int id)
        {
            throw new NotImplementedException();
        }

        public List<EquipmentQueryViewModel> GetEquipmentsWithTrainer()
        {
           var equipments= _unitOfWork.Equipments.GetEquipmentsWithTrainer();
           return _mapper.Map<List<EquipmentQueryViewModel>>(equipments);
        }

        public bool Update(EquipmentCommandViewModel model, int id)
        {
            var equipments = _unitOfWork.Equipments.GetById(id);
            if (equipments == null)
            {
                throw new InvalidOperationException("Equipment  not found");
            }
            equipments.MaintenancePeriod = equipments.CreatedDate.AddMonths(model.Duration);
          
            _unitOfWork.Equipments.Update(equipments);
            if (_unitOfWork.SaveChanges())
            {
                return true;
            }
            return false;
        }
    }
}
