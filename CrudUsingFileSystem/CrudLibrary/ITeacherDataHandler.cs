using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TeacherRecordLibrary
{
    public interface ITeacherDataHandler
    {
        void AddTeacher();
        void DisplayTeacher();
        void UpdateTeacher();
    }
}
