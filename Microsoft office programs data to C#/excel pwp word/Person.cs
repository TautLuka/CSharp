using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace excel_pwp_word
{
    [XmlRoot("klientas")]
    public class Person
    {
        [XmlAttribute("Vardas")]
        public string Name { get; set; }    
        public string LastName { get; set; }
        [XmlElement("Gimimo_data")]
        public DateTime DateOfBirth { get; set; }
        [XmlElement("Amžius")]
        public byte Age { get; set; }
        public string Email { get; set; }

    }
}
