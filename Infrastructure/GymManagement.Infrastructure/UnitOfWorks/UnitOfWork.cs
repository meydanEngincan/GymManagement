﻿using GymManagement.Application.Interfaces.Repositories;
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
        public IEmployeDetailRepository EmployeeDetails { get; }
        public IEquipmentRepository Equipments { get; }
        public IExerciseProgramRepository ExercisePrograms { get; }
        public IManagerRepository Managers { get; }
        public IMemberRepository Members { get; }
        public IMissionRepository Missions { get; }
        public ITrainerRepository Trainers { get; }
        public IWorkerContractRepository WorkerContracts { get; }
        public IWorkerRepository Workers { get; }
        public IEmployeDetailRepository EmployeDetails => throw new NotImplementedException();

        public UnitOfWork(ICampaignRepository campaigns, IEmployeDetailRepository employeeDetails,
            IEquipmentRepository equipments, IExerciseProgramRepository exercisePrograms,
            IManagerRepository managers, IMemberRepository members, IMissionRepository missions,
            ITrainerRepository trainers, IWorkerContractRepository workerContracts, IWorkerRepository workers,GymManagementDbContext context)
        {
            Campaigns = campaigns;
            EmployeeDetails = employeeDetails;
            Equipments = equipments;
            ExercisePrograms = exercisePrograms;
            Managers = managers;
            Members = members;
            Missions = missions;
            Trainers = trainers;
            WorkerContracts = workerContracts;
            Workers = workers;
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
    