using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;

namespace Json
{
    [DataContract]

    class Person
    {
        [DataMember] //nuoroda, kad reikia eksportuoti i json
        public string Name { get; set; }
        [IgnoreDataMember]
        public string LastName { get; set; }
        [DataMember]
        public DateTime DateOfBirth { get; set; }
        [DataMember]
        public byte Age { get; set; }
        [IgnoreDataMember]
        public string Email { get; set; }
        
    }
}
