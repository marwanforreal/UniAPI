﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UniAPI.Contexts;
using UniAPI.Entities;

namespace UniAPI.Services
{
    public class LecturerInfoRepository : ILecturerInfoRepository
    {
        private readonly CourseInfoContext _context;
        public LecturerInfoRepository(CourseInfoContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public bool LecturerExists(int id)
        {
            var result = _context.Lecturers.Any(p => p.Id == id);

            return result;
        }

        public bool EmailExist(string email)
        {
            var result = _context.Lecturers.Any(p => p.Email == email);

            return result;
        }

        public List<Lecturer> getAllLecturers()
        {
            var result = _context.Lecturers.Select(p => p).ToList();

            return result;
        }

        public Lecturer GetLecturer(int id, bool includeCourses, bool includeStudents)
        {
            throw new NotImplementedException();
        }

        public void Save()
        {
            _context.SaveChanges();
        }

        public void AddNewLecturer(Lecturer lecturer)
        {
            _context.Lecturers.Add(lecturer);
        }

        public void DeleteLecturer(int lecturerId)
        {
            var lecturerToDelete = _context.Lecturers.Find(lecturerId);

            _context.Lecturers.Remove(lecturerToDelete);
        }
    }
}