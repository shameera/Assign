using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BusinessLayer.propertyLayer
{
    public class objStudentDetails
    {

        private string _StudentId;
        private string _Name;
        private string _dob;
        private decimal _gradePoint;
        private Boolean _status;

        public string StudentId
        {
            get { return _StudentId; }
            set { _StudentId = value; }
        }

        public string Name
        {
            get { return _Name; }
            set { _Name = value; }
        }

        public string dob
        {
            get { return _dob; }
            set { _dob = value; }
        }

        public decimal gradePoint
        {
            get { return _gradePoint; }
            set { _gradePoint = value; }
        }

        public Boolean status
        {
            get { return _status; }
            set { _status = value; }
        }

    }
}
