using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net;
using System.IO;

namespace darbas_su_ftp_serveriu
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            //cahnge listbox drawing mode
            lstData.DrawMode = DrawMode.OwnerDrawFixed;
            //adds drawing event
            lstData.DrawItem += LstData_DrawItem;
            lstData.DoubleClick += LstData_DoubleClick;
        }

        private void LstData_DoubleClick(object sender, EventArgs e)
        {
            if (lstData.SelectedIndex == -1) return;
            //if not file
            if((lstData.SelectedItem as OneFtpItems).DataType !=DataType.File)
            {
                txtURL.Text += "/" + (lstData.SelectedItem as OneFtpItems).Name;
                browse.PerformClick();
            }
        }

        private void LstData_DrawItem(object sender, DrawItemEventArgs e)
        {
            if (e.Index == -1) return;
            //get added item or selected item
            OneFtpItems item = lstData.Items[e.Index] as OneFtpItems;

            Brush myBrush;
            if((e.State & DrawItemState.Selected)==0)
            {
                myBrush = SystemBrushes.WindowText;
            }
            else
            {
                myBrush = SystemBrushes.HighlightText;
            }
            e.DrawBackground();
            StringFormat format = new StringFormat();
            format.Trimming = StringTrimming.EllipsisCharacter;

            //draw info
            e.Graphics.DrawString(item.Name, e.Font, myBrush, new Rectangle(label2.Left - lstData.Left, e.Bounds.Y, label3.Left - label2.Left, e.Bounds.Top), format);

            //size
            if(item.DataType == DataType.File)
            {
                e.Graphics.DrawString(item.SizeString, e.Font, myBrush, new Rectangle(label3.Left - lstData.Left, e.Bounds.Y, label4.Left - label3.Left, e.Bounds.Top), format);
            }

            //last modified
            e.Graphics.DrawString(item.LastModified, e.Font, myBrush, new Rectangle(label4.Left - lstData.Left, e.Bounds.Y, lstData.Right - label4.Left, e.Bounds.Top), format);

        }

        FtpWebRequest request;
        FtpWebResponse response;

        private void browse_Click(object sender, EventArgs e)
        {
            try
            {
                //create request
                //needs conversion from WebRequest type to FtpWebReq
                request = WebRequest.Create(txtURL.Text) as FtpWebRequest;

                //check
                if (request == null) return; //end current job

                //define username and password
                request.Credentials = new NetworkCredential("", "");

                //define what to do 
                request.Method = WebRequestMethods.Ftp.ListDirectoryDetails;

                //get response
                response = request.GetResponse() as FtpWebResponse;

                //clear listbox
                lstData.Items.Clear();

                //print response data
                lstData.Items.AddRange(ReadStream(response.GetResponseStream()).ToArray());

                //close response
                response.Close();

                //collect garbage
                GC.Collect();
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
                Console.WriteLine(ex.StackTrace);
            }
        }

        private List<OneFtpItems> ReadStream(Stream stream)
        {
            //create return data type
            List<OneFtpItems> data = new List<OneFtpItems>();
            using (StreamReader reader = new StreamReader(stream))
            {
                //read while reader has data
                while(!reader.EndOfStream)
                {
                    //getting rid of all the spaces (making it cleaner)
                    //split data adn remove spaces from string
                    var arr= reader.ReadLine().Split(" ".ToCharArray(),StringSplitOptions.RemoveEmptyEntries);

                    foreach (var item in arr)
                    {
                        Console.WriteLine(item);
                    }
                    Console.WriteLine("------------");

                    //format string
                    //data.Add($"Type: {arr[0][0]} Size: {arr[4]} Last mod. {arr[7]} {arr[5]} {arr[6]} Name: {arr[8]}");

                    OneFtpItems one = new OneFtpItems()
                    {
                        Name = arr[8],
                        //Size = Convert.ToInt64 (arr[4])
                        LastModified = $"{arr[7]}-{arr[5]}-{arr[6]}",
                        DataType = arr[0][0] == '-' ? DataType.File:DataType.Directory
                    };

                    long temp;
                    one.Size = long.TryParse(arr[4], out temp) ? temp : -1;

                    switch (arr[0][0])
                    {
                        case '-':
                            one.DataType = DataType.File;
                            break;
                        case 'd':
                            one.DataType = DataType.Directory;
                            break;
                        case 'l':
                            one.DataType = DataType.Link;
                            break;
                    }
                    data.Add(one);
                }
            }
            return data;
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

    }
}
