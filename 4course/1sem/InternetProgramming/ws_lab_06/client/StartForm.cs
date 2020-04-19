using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Services.Client;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace client {
    public partial class StartForm : Form {
        MSUWS.WSEntities entity;

        public StartForm() {

            entity = new MSUWS.WSEntities(new Uri("http://localhost:54570/MSUService.svc/"));

            InitializeComponent();
        }

        private void getStudents_Click(object sender, EventArgs e) {
            result.Text = "";
            foreach (MSUWS.student student in entity.students.AsEnumerable()) {
                result.Text += string.Format("Student: '{0}' (id:{1})\n", student.name, student.id);
            }
        }

        private void getNotes_Click(object sender, EventArgs e) {
            List<MSUWS.note> notes = entity.notes.Where(n => n.notes >= 4).ToList();
            
            result.Text = "";
            foreach (MSUWS.note note in notes) {
                result.Text += string.Format("Note: {0} on exam {1} (id student:{2})\n", note.notes, note.subject, note.id);
            }
        }

        private void button55_Click(object sender, EventArgs e)
        {
            // Create the new product.
            var std = MSUWS.student.Createstudent(322, "Vladimir");

            try
            {
                // Add the new product to the Products entity set.
                entity.AddTostudents(std);
                //entity.AddObject("student", std);
                // Send the insert to the data service.
                DataServiceResponse response = entity.SaveChanges(SaveChangesOptions.Batch);

                result.Text = "";
                foreach (MSUWS.student student in entity.students.AsEnumerable())
                {
                    result.Text += string.Format("Student: '{0}' (id:{1})\n", student.name, student.id);
                }

                // Enumerate the returned responses.
                foreach (ChangeOperationResponse change in response)
                {
                    // Get the descriptor for the entity.
                    EntityDescriptor descriptor = change.Descriptor as EntityDescriptor;

                    if (descriptor != null)
                    {
                        MSUWS.student addedStd = descriptor.Entity as MSUWS.student;

                        if (addedStd != null)
                        {
                            Console.WriteLine("New product added with ID {0}.",
                                addedStd.name);
                        }
                    }
                }
            }
            catch (DataServiceRequestException ex)
            {
                throw new ApplicationException(
                    "An error occurred when saving changes.", ex);
            }
        }

        private void button66_Click(object sender, EventArgs e)
        {

            var customerToChange = (from student in entity.students
                                    where student.id == 1
                                    select student).Single();

            // Change some property values.
            customerToChange.name = "BEST STUDENT IT'S NOT ME";

            try
            {
                // Mark the customer as updated.
                entity.UpdateObject(customerToChange);

                // Send the update to the data service.
                entity.SaveChanges();
            }
            catch (DataServiceRequestException ex)
            {
                throw new ApplicationException(
                    "An error occurred when saving changes.", ex);
            }
        }
    }
}
