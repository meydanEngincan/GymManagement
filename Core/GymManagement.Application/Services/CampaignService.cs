using AutoMapper;
using GymManagement.Application.Interfaces.ServiceInterfaces;
using GymManagement.Application.Interfaces.UnitOfWorks;
using GymManagement.Application.ViewModels.CampaignViewModel;
using GymManagement.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GymManagement.Application.Services
{
    public class CampaignService : ICampaignService
    {
        private readonly IUnitOfWork _unitOfWork;
        readonly IMapper _mapper;

        public CampaignService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public bool Create(CampaignCommandViewModel model)
        {
            var campaign = _mapper.Map<Campaign>(model);
            _unitOfWork.Campaigns.Create(campaign);
            if (_unitOfWork.SaveChanges())
            {
                return true;
            }
            return false;
        }

        public bool Delete(int id)
        {
            var campaign=_unitOfWork.Campaigns.GetById(id);
            if (campaign == null)
            {
                throw new InvalidOperationException("Campaign  not found");
            }
            campaign.IsDeleted = true;
            _unitOfWork.Campaigns.Update(campaign);
            if (_unitOfWork.SaveChanges())
            {
                return true;
            }
            return false;
        }

        public List<CampaignQueryViewModel> GetAll()
        {
            var campaigns = _unitOfWork.Campaigns.GetAll();
            return _mapper.Map<List<CampaignQueryViewModel>>(campaigns);
            
        }

        public CampaignQueryViewModel GetById(int id)
        {
            var campaigns = _unitOfWork.Campaigns.GetById(id);
            return _mapper.Map<CampaignQueryViewModel>(campaigns);
        }
        public bool Update(CampaignCommandViewModel model, int id)
        {
            var campaign=_unitOfWork.Campaigns.GetById(id);
            if (campaign == null)
            {
                throw new InvalidOperationException("Campaign  not found");
            }

            var vmModel = _mapper.Map<Campaign>(model);
            _unitOfWork.Campaigns.Update(vmModel);
            if (_unitOfWork.SaveChanges())
            {
                return true;
            }
            return false;
        }
    }
}
