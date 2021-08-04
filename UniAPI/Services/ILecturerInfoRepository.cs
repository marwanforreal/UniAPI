using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UniAPI.Entities;

namespace UniAPI.Services
{
    public interface ILecturerInfoRepository
    {
        bool LecturerExists(int id);
        bool EmailExist(string email);
        List<Lecturer> getAllLecturers();
        Lecturer GetLecturerById(int id);
        void AddNewLecturer(Lecturer lecturer);
        void DeleteLecturer(int lecturerId);
        void Save();
    }
}
