using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using IronXL;
using System.Xml.Serialization;
using System.IO;


namespace excel_pwp_word
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        Person p = new Person();

        private void btnReadExcel_Click(object sender, EventArgs e)
        {
            try
            {
                WorkBook book = WorkBook.Load(Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + @"/Book1.xlsx");
                WorkSheet sheet = book.DefaultWorkSheet;

                //update formulas
                //book.EvaluateAll();

                //testing cords printing
                //MessageBox.Show(sheet["A1"].Value.ToString());

                //setting cords value
                sheet["A10:B15"].Value = "Test";
                book.Save();

                p.Name = sheet["A2"].Value.ToString();
                p.LastName = sheet["B2"].Value.ToString();
                p.DateOfBirth = Convert.ToDateTime(sheet["C2"].Value);
                p.Age = Convert.ToByte(sheet["D2"].Value);
                p.Email = sheet["E2"].Value.ToString();

                //to successfully convert class object to xml we must meet the following requirements
                //1.Class must have default constructor
                //2.only public properties can be serialized

                //hint
                //serialization does not cotain data type

                //create serialization object
                XmlSerializer xml = new XmlSerializer(p.GetType());
                string path = Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + @"/One.xml";

                using (var writer = new StreamWriter(path))
                {
                    xml.Serialize(writer, p);
                }

                List<Person> people = new List<Person>();
                var range = sheet["A2:E6"];
                //read all data 

                for (int i = 0; i < range.Rows.Length; i++)
                {
                    var per = new Person();
                    per.Name = range.Rows[i].Columns[0].Value.ToString();
                    per.LastName = range.Rows[i].Columns[1].Value.ToString();
                    per.DateOfBirth = Convert.ToDateTime(range.Rows[i].Columns[2].Value);
                    per.Age = Convert.ToByte(range.Rows[i].Columns[3].Value);
                    per.Email = range.Rows[i].Columns[4].Value.ToString();
                    people.Add(per);
                }

                xml = new XmlSerializer(people.GetType());
                path = Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + @"/All.xml";

                using (var writer = new StreamWriter(path))
                {
                    xml.Serialize(writer, people);
                }

                //read data from xml file
                List<Person> readPeople = new List<Person>();
                xml = new XmlSerializer(readPeople.GetType());
                using (var reader = new StreamReader(path))
                {
                    readPeople = xml.Deserialize(reader) as List<Person>;
                }
                //check if read successfull 
                MessageBox.Show(readPeople[0].Name);

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            

        }
    }
}
