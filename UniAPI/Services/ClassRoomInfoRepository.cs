using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UniAPI.Contexts;
using UniAPI.Entities;

namespace UniAPI.Services
{
    public class ClassRoomInfoRepository : IClassRoomInfoRepository
    {
        private readonly CourseInfoContext _context;

        public ClassRoomInfoRepository(CourseInfoContext context)
        {
            _context = context ?? throw new ArgumentNullException();
        }
        public IEnumerable<ClassRoom> GetAllClassRooms()
        {
            var result = _context.ClassRooms.Select(p => p).ToList();

            return result;
        }

        public ClassRoom GetClassRoomById(int classRoomId)
        {
            var result = _context.ClassRooms.SingleOrDefault(p => p.Id == classRoomId);

            return result; 
        }
    }
}
