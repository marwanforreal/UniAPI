using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using UniAPI.Contexts;
using UniAPI.Entities;

namespace UniAPI.Services
{
    public class ClassRoomInfoRepository : IClassRoomInfoRepository
    {
        private readonly CourseInfoContext _context;

        public bool ClassRoomExists(int classRoomId)
        {
            var result = _context.ClassRooms.Any(p => p.Id == classRoomId);

            return result;
        }

        public bool ClassRoomExists(string classRoomName)
        {
            var result = _context.ClassRooms.Any(p => p.Name == classRoomName);

            return result;
        }
        public ClassRoomInfoRepository(CourseInfoContext context)
        {
            _context = context ?? throw new ArgumentNullException();
        }
        public IEnumerable<ClassRoom> GetAllClassRooms()
        {
            var result = _context.ClassRooms.Select(p => p)
                .Include(p=>p.Courses)
                .ThenInclude(p=>p.Lecturer)
                .ToList();

            return result;
        }

        public ClassRoom GetClassRoomById(int classRoomId)
        {
            var result = _context.ClassRooms
                .Include(p=>p.Courses)
                .ThenInclude(p=>p.Lecturer)
                .SingleOrDefault(p => p.Id == classRoomId);

            return result; 
        }

        public void AddNewClassRoom(ClassRoom classRoom)
        {
            _context.ClassRooms.Add(classRoom);
        }

        public void Save()
        {
            _context.SaveChanges();
        }
    }
}
