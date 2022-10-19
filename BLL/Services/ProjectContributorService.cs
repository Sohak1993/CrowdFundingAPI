using BLL.Interface;
using BLL.Models;
using DAL.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToolBox.Mapper;
using DALM = DAL.Models;

namespace BLL.Services
{
    public class ProjectContributorService : ObjectMapper, IProjectContributorService
    {
        private readonly IProjectContributorRepo _projectContributorRepo;

        public ProjectContributorService(IProjectContributorRepo projectContributorRepo)
        {
            _projectContributorRepo = projectContributorRepo;
        }
        public void AddContribution(ProjectContributor pc)
        {
            _projectContributorRepo.AddContribution(MapModel<DALM.ProjectContributor, ProjectContributor>(pc));
        }
    }
}
