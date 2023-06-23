using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace library.Models
{
    [MetadataType(typeof(bookMetaData))]
    public partial class book
    {
        public class bookMetaData
        {
            [DisplayName("Book Name")]
            public string bookname { get; set; }

            [DisplayName("Category ID")]
            public Nullable<int> categoryid { get; set; }

            [DisplayName("Author ID")]
            public Nullable<int> authorid { get; set; }

            [DisplayName("Publisher ID")]
            public Nullable<int> publisherid { get; set; }

            [DisplayName("Contents")]
            public string contents { get; set; }

            [DisplayName("Pages")]
            public Nullable<int> pages { get; set; }

            [DisplayName("Edition")]
            public string edition { get; set; }
        }
    }
}