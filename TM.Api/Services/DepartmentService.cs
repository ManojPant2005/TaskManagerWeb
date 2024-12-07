using Microsoft.EntityFrameworkCore;
using TM.Api.Data;
using TM.Api.Data.Entities;
using TM.Shared.DTOs;

namespace TM.Api.Services
{
    public class DepartmentService
    {
        private readonly TaskContext _task;

        public DepartmentService(TaskContext task)
        {
            _task = task;
        }

        public async Task<QuizApiResponse> SaveDepartmentAsync(DepartmentDto dept)
        {
            if (await _task.Departments
                          .AsNoTracking()
                          .AnyAsync(c => c.Name == dept.Name && c.Id != dept.Id))
            {
                //category with same name already exist
                return QuizApiResponse.Fail("Department with same name exists already"); ;
            }

            if (dept.Id == 0)
            {
                //create new category

                var cat = new Department
                {
                    Name = dept.Name
                };
                _task.Departments.Add(cat);
            }
            else
            {
                //update existing category

                var dbCat = await _task.Departments
                           .FirstOrDefaultAsync(c => c.Id == dept.Id);
                if (dbCat == null)
                {
                    //Department does not exist
                    return QuizApiResponse.Fail("Department does not exist");
                }
                dbCat.Name = dept.Name;
                _task.Departments.Update(dbCat);
            }
            await _task.SaveChangesAsync();
            return QuizApiResponse.Success();
        }

        public async Task<DepartmentDto[]> GetDepartmentsAsync() =>
               await _task.Departments
              .AsNoTracking()
              .Select(c => new DepartmentDto
              {
                  Name = c.Name,
                  Id = c.Id
              })
             .ToArrayAsync();

    }
}
