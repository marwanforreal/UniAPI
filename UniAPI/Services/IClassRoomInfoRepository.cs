using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UniAPI.Entities;

namespace UniAPI.Services
{
    public interface IClassRoomInfoRepository
    {
        bool ClassRoomExists(int classRoomId);

        bool ClassRoomExists(string classRoomName);

        IEnumerable<ClassRoom> GetAllClassRooms();

        ClassRoom GetClassRoomById(int classRoomId);

        void AddNewClassRoom(ClassRoom classRoom);

        void Save();
    }
}
