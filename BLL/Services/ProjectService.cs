using BLL.Interface;
using BLL.Mappers;
using BLL.Models;
using DAL.Interface;
using DAL.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToolBox.Mapper;
using DALM = DAL.Models;

namespace BLL.Services
{
    public class ProjectService : ObjectMapper, IProjectService
    {
        private readonly IProjectRepo _projectRepo;

        public ProjectService(IProjectRepo projectRepo)
        {
            _projectRepo = projectRepo;
        }

        public void CreateProject(Project p)
        {
            _projectRepo.CreateProject(MapModel<DALM.Project,Project>(p));
        }

        public void Delete(int id)
        {
            _projectRepo.Delete(id);
        }

        public IEnumerable<Project> GetAll()
        {
            return _projectRepo.GetAll().Select(elem => MapModel<Project, DALM.Project>(elem));
            
        }

        public Project GetById(int id)
        {
            return MapModel<Project, DALM.Project>(_projectRepo.GetById(id));
        }

        public void Update(Project p)
        {
            _projectRepo.Update(MapModel<DALM.Project, Project>(p));
        }
    }
}
