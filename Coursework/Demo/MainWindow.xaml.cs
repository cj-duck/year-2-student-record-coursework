// Author: Christopher Johnson [40275286]
// MainWindow
// Date Last Modified: 23/10/2017

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using BusinessObjects;

namespace Demo
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>

    public partial class MainWindow : Window
    {
        private ModuleList store = new ModuleList();
        
        public MainWindow()
        {
            InitializeComponent();
        }

        private void ClearForm() // Method to clear all of the text boxes and set the date picker to default, saves writing it out multiple times
        {            
            txtFirstName.Clear();
            txtSecondName.Clear();
            txtCourseMark.Clear();
            txtExamMark.Clear();
            dpDOB.SelectedDate = null;
        }
        private void btnAdd_Click(object sender, RoutedEventArgs e) // Adds a new student to the module list and displays the matric number in the stored students list box
        {
            // Retrieve all the info entered into the text boxes and assign them to variables
            Student newStudent = new Student();
            

            try
            {
                // Assign the values to the student attributes 
                newStudent.Matric = Convert.ToInt32(txtMatric.Text);
                newStudent.FirstName = txtFirstName.Text;
                newStudent.SecondName = txtSecondName.Text;
                newStudent.courseworkMark = Convert.ToInt32(txtCourseMark.Text);
                newStudent.examMark = Convert.ToInt32(txtExamMark.Text);
                newStudent.dateOfBirth = dpDOB.SelectedDate.GetValueOrDefault();

                int matric = Convert.ToInt32(txtMatric.Text);
                // Add the students name to the list box
                lbxStudents.Items.Add(matric);

                // Increment the matric by 1 and print it to the text box (only works whilst continously adding new students)
                int newMatric = matric + 1;
                txtMatric.Text = newMatric.ToString();

                // Clear text boxes once student has been added to list
                ClearForm();              
            }
            catch (Exception excep)
            {
                // Display error message from the student class
                MessageBox.Show(excep.Message);
            }

            // Testing to see the values have been assigned correctly:
            // MessageBox.Show(newStudent.Matric + " " + newStudent.FirstName + " " + newStudent.SecondName + " " + newStudent.courseworkMark + " " + newStudent.examMark + " " + newStudent.dateOfBirth);

            store.add(newStudent);

        }

        private void btnFind_Click_1(object sender, RoutedEventArgs e) // Finds a student with a specific matric number and displays it's info in the text boxes/date picker
        {
            // Get the matric number from matric text box
            int matric = int.Parse(txtMatric.Text);
            // Create a new student and make its attributes equal to that of the found student with the same matric
            Student foundStudent = new Student();
            foundStudent = store.find(matric);

            // Check that the matrics match
            if (foundStudent.Matric == matric)
            {
                // Display the attributes in the text boxes and date picker
                txtFirstName.Text = foundStudent.FirstName;
                txtSecondName.Text = foundStudent.SecondName;
                txtCourseMark.Text = foundStudent.courseworkMark.ToString();
                txtExamMark.Text = foundStudent.examMark.ToString();
                dpDOB.SelectedDate = foundStudent.dateOfBirth;

            }
            else
            {
                MessageBox.Show("Student not found");
            }
        }

        private void btnDelete_Click(object send, RoutedEventArgs e) // Removes a student from the module list and the student list box
        {
            // Deletes a student using the store.delete method
            int matric = int.Parse(txtMatric.Text);
            store.delete(matric);

            // Removes the selected student from the student list box
            while (lbxStudents.SelectedItems.Count > 0)
            {
                lbxStudents.Items.Remove(lbxStudents.SelectedItems[0]);
            }

            ClearForm();
            txtMatric.Clear();   
        }

        private void lbxStudents_SelectionChanged(object sender, SelectionChangedEventArgs e) // Displays student details when a matric in the list box is selected
        {
            // If statement to prevent crashing when removing an item from the listbox
            if (lbxStudents.SelectedValue != null)
            {
                int matric = Convert.ToInt32(lbxStudents.SelectedValue.ToString());

                // Retrive student details and display the attributes in the text boxes
                Student foundStudent = new Student();
                foundStudent = store.find(matric);

                txtMatric.Text = foundStudent.Matric.ToString();
                txtFirstName.Text = foundStudent.FirstName;
                txtSecondName.Text = foundStudent.SecondName;
                txtCourseMark.Text = foundStudent.courseworkMark.ToString();
                txtExamMark.Text = foundStudent.examMark.ToString();
                dpDOB.SelectedDate = foundStudent.dateOfBirth;
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e) // Displays class list form when the button is clicked  
        {
            classList showAll = new classList();
            showAll.ShowDialog();
        }
    }
}
