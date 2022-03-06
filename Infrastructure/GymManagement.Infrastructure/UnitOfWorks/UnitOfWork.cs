using GymManagement.Application.Interfaces.Repositories;
using GymManagement.Application.Interfaces.UnitOfWorks;
using GymManagement.Infrastructure.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GymManagement.Infrastructure.UnitOfWorks
{
    public class UnitOfWork : IUnitOfWork
    { 
        private readonly GymManagementDbContext _context;

        public ICampaignRepository Campaigns { get; }
      //  public IEmployeDetailRepository EmployeeDetails { get; }
        public IEquipmentRepository Equipments { get; }
        public IExerciseProgramRepository ExercisePrograms { get; }
        public IManagerRepository Managers { get; }
        public IMissionRepository Missions { get; }
        public ITrainerRepository Trainers { get; }
        public IWorkerContractRepository WorkerContracts { get; }
        public IEmployeDetailRepository EmployeDetails { get; }
        public UnitOfWork(ICampaignRepository campaigns, IEmployeDetailRepository employeeDetails,
            IEquipmentRepository equipments, IExerciseProgramRepository exercisePrograms,
            IManagerRepository managers,IMissionRepository missions,
            ITrainerRepository trainers, IWorkerContractRepository workerContracts, GymManagementDbContext context)
        {
            Campaigns = campaigns;
            EmployeDetails = employeeDetails;
            Equipments = equipments;
            ExercisePrograms = exercisePrograms;
            Managers = managers;
            
            Missions = missions;
            Trainers = trainers;
            WorkerContracts = workerContracts;
            _context = context;
        }
        public bool SaveChanges()
        {
            if( _context.SaveChanges() > 0)
            {
                return true;
            }
            return false;
        }
    }
}
    
