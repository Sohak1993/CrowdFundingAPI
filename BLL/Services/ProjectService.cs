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

namespace BLL.Services
{
    public class ProjectService : IProjectService
    {
        private readonly IProjectRepo _projectRepo;

        public ProjectService(IProjectRepo movieRepo)
        {
            _projectRepo = movieRepo;
        }

        public void CreateProject(Project p)
        {
            _projectRepo.CreateProject(p.ToDal());
        }

        public void Delete(int id)
        {
            _projectRepo.Delete(id);
        }

        public IEnumerable<Project> GetAll()
        {

            return _projectRepo.GetAll().Select(element => element.ToBll());
        }

        public Project GetById(int id)
        {
            return _projectRepo.GetById(id).ToBll();
        }

        public void Update(Project p)
        {
            _projectRepo.Update(p.ToDal());
        }
    }
}
