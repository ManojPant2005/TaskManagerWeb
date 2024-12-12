using TM.Api.Data.Entities;
using TM.Api.Data;
using TM.Shared.DTOs;
using Microsoft.EntityFrameworkCore;

namespace TM.Api.Services
{
    public class ClassService
    {
        private readonly TaskContext _context;

        public ClassService(TaskContext context)
        {
            _context = context;
        }
        public async Task<ClassDto[]> GetClassesByDepartmentAsync(int departmentId)
        {
            return await _context.Classes
                .AsNoTracking()
                .Where(c => c.DepartmentId == departmentId)
                .Select(c => new ClassDto
                {
                    Id = c.Id,
                    Name = c.Name,
                    DepartmentId = c.DepartmentId
                })
                .ToArrayAsync();
        }

        public async Task SaveClassAsync(ClassDto dto)
        {
            if (dto.Id == 0)
            {
                var newClass = new Class
                {
                    Name = dto.Name,
                    DepartmentId = dto.DepartmentId
                };
                _context.Classes.Add(newClass);
            }
            else
            {
                var existingClass = await _context.Classes.FirstOrDefaultAsync(c => c.Id == dto.Id);
                if (existingClass == null || existingClass.DepartmentId != dto.DepartmentId)
                {
                    throw new InvalidOperationException("Class not found or access denied.");
                }

                existingClass.Name = dto.Name;
                _context.Classes.Update(existingClass);
            }

            await _context.SaveChangesAsync();
        }
        public async Task DeleteClassAsync(int id, int departmentId)
        {
            var classToDelete = await _context.Classes
                .FirstOrDefaultAsync(c => c.Id == id && c.DepartmentId == departmentId);

            if (classToDelete != null)
            {
                _context.Classes.Remove(classToDelete);
                await _context.SaveChangesAsync();
            }
        }


    }
}