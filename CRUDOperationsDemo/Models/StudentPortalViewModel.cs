namespace School.Models
{
    public class StudentPortalViewModel
    {
        public string StudentName { get; set; } = string.Empty;

        public String Date { get; set; } = string.Empty;

        public string Semester { get; set; }

        public int Achrayus { get; set; } = 0;

        public List<PointSystem> PointSystems;
    }

    public class PointSystem
    {
        public string SubjectName { get; set; } = string.Empty;

        public string Teacher { get; set; } = string.Empty;
        public int Allowed { get; set; }

        public int Missed { get; set; }

        public int Deducated { get; set; }

        public List<StudentAbsense> StudentAbsenses { get; set; }

    }
}
