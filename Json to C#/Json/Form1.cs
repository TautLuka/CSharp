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
using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Json;
using System.Web;
using System.Web.Script.Serialization;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json.Serialization;
using unirest_net.http;

namespace Json
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        //zmoniu sarasai saugoti
        List<Person> people = new List<Person>();

        private void btnReadData_Click(object sender, EventArgs e)
        {
            //skaitome duomenis is excel failo
            try
            {
                WorkBook book = WorkBook.Load(Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + @"/Book1.xlsx");
                WorkSheet sheet = book.DefaultWorkSheet;

                var range = sheet["A2:E6"];

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
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnCsharpStyle_Click(object sender, EventArgs e)
        {
            try
            {
                //tikriname ar yra ka konvertuoti i json
                if (people.Count == 0) return;

                DataContractJsonSerializer data = new DataContractJsonSerializer(people.GetType());
                //second variant for override           
                //DataContractSerializer data = new DataContractSerializer(typeof(List<Person>));

                string path = Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + @"/CsharpStyle.Json";

                //irasome konvertuotus duomenis i atminti(RAM), del RUNTIME
                using (MemoryStream mem = new MemoryStream())
                {
                    data.WriteObject(mem, people);

                    //nuskaitome gauta rezultata is atminties 
                    using (StreamReader reader = new StreamReader(mem))
                    {
                        //irasome duomenis i faila
                        using (StreamWriter writer = new StreamWriter(path))
                        {
                            //gryztam i mem pradzia
                            mem.Position = 0;
                            writer.Write(reader.ReadToEnd());
                        }
                    }
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnWebStyle_Click(object sender, EventArgs e)
        {
            try
            {
                if (people.Count == 0) return;

                string path = Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + @"/CsharpWebStyle.Json";

                JavaScriptSerializer java = new JavaScriptSerializer();

                using (StreamWriter writer = new StreamWriter(path))
                {
                    writer.Write(java.Serialize(people));
                }

                java.Serialize(people);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnNewtonStyle_Click(object sender, EventArgs e)
        {
            try
            {
                if (people.Count == 0) return;

                string path = Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + @"/NewtonWebStyle.Json";

                using (StreamWriter writer = new StreamWriter(path))
                {
                    writer.Write(JsonConvert.SerializeObject(people));
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var rez= Unirest.get("some kind of api adress https etc").asJson<string>();
            var joke = JsonConvert.DeserializeObject<Dictionary<string, object>>(rez.Body);
            MessageBox.Show(joke["value"].ToString());
        }
    }
}
