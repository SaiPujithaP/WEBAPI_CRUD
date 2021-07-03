using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Threading.Tasks;

namespace CRUD.Models
{
    [Serializable]
    [DataContract(Name = "User")]
    public class User
    {
        [DataMember]
        public long UserId { get; set; }

        [DataMember]
        public long UserName { get; set; }
    }
}
