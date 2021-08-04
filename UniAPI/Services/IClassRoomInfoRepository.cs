using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UniAPI.Entities;

namespace UniAPI.Services
{
    public interface IClassRoomInfoRepository
    {
        IEnumerable<ClassRoom> GetAllClassRooms();

        ClassRoom GetClassRoomById(int classRoomId);
    }
}
