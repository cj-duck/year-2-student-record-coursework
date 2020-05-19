// Author: Christopher Johnson [40275286]
// Class Purpose: Student Class to be created within the main window
// Date Last Modified: 23/10/2017

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BusinessObjects
{
    public class Student
    {
        // Declaring the attributes for the Student Class
        private int _matricNo;
        private string _firstName;
        private string _secondName;
        private int _courseMark;
        private int _examMark;
        private DateTime _dateOfBirth;

        public int Matric
        {
            get
            {
                return _matricNo;
            }
            set
            {
                // Validates that the matric number provided is between the accepted values
                if(value < 10001 || value > 50000)
                {
                    // Generates an error which is passed back to the calling method
                    throw new ArgumentException("Matriculation Number must be between 10001 and 50000");
                }
                _matricNo = value;
            }
        }
        public string FirstName
        {
            get
            {
                return _firstName;
            }
            set
            {
                // Validates that the First name provided isn't blank or whitespace
                if(string.IsNullOrWhiteSpace(value))
                {
                    // Generates error if if statement is true
                    throw new ArgumentException("First Name cannot be blank");
                }
                _firstName = value;
            }
        }

        public string SecondName
        {
            get
            {
                return _secondName;
            }
           set
            {
               // Validates that the Second Name provided isn't blank or whitespace
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("Second Name cannot be blank");
                }
                _secondName = value;
            }
        }

        public int courseworkMark
        {
            get
            {
                return _courseMark;
            }
            set
            {
                // Validates that the coursework mark provided is within the accepted range 
                if (value > 20 || value < 0 )
                {
                    throw new ArgumentException("Coursework Mark must be out of 20");
                }
                _courseMark = value;
            }
        }

        public int examMark
        {
            get
            {
                return _examMark;
            }
            set
            {
                // Validates that the coursework mark provided is within the accepted range
                if (value > 40 || value < 0 )
                {
                    throw new ArgumentException("Exam Mark must be out of 40");
                }
                _examMark = value;
            }
        }

        public DateTime dateOfBirth
        {
            get
            {
                return _dateOfBirth;
            }
            set
            {
                // Validates that the date of birth proved is not blank or white space
                if(dateOfBirth == null)
                {
                    throw new ArgumentException("Date of Birth cannot be blank");
                }
                _dateOfBirth = value;
            }
        }
    }
}
