using AutoMapper;
using GymManagement.Application.ViewModels.CampaignViewModel;
using GymManagement.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GymManagement.Application.Mapping
{
    public class CampaignMappingProfile : Profile
    {
        public CampaignMappingProfile()
        {
            CreateMap<CampaignQueryViewModel, Campaign>().ReverseMap();
            CreateMap<CampaignCommandViewModel, Campaign>().ReverseMap();
        }
    }
}
