using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace library.Models
{
    [MetadataType(typeof(memberMetaData))]
    public partial class member
    {
        public class memberMetaData
        {
            [DisplayName("Member Name")]
            public string name { get; set; }

            [DisplayName("Address")]
            public string address { get; set; }

            [DisplayName("Phone")]
            public Nullable<int> phone { get; set; }
        }
    }
}