/* /////////////////////////////////////////////////////////////////////////////////////////////////
//                      Copyright (c) ob'do Contact Agile
//
//                           (C)ob'do Contact Agile 2017
//         All rights are reserved. Reproduction in whole or in part is
//        prohibited without the written consent of the copyright owner.
//    ob'do Contact Agile reserves the right to make changes without notice at any time.
//   ob'do Contact Agile makes no warranty, expressed, implied or statutory, including but
//   not limited to any implied warranty of merchantability or fitness for any
//  particular purpose, or that the use will not infringe any third party patent,
//   copyright or trademark. ob'do Contact Agile must not be liable for any loss or damage
//                            arising from its use.
///////////////////////////////////////////////////////////////////////////////////////////////// */
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SQLiteNullableDateTimeIssue.Models
{
    class Dog
    {
        [Key]
        public int Id { get; set; }

        public string Name { get; set; }
        public DateTime? Birthdate { get; set; }

        public override string ToString()
        {
            return $"dog name: {Name} -- birthdate: {Birthdate?.ToString("dd/MM/yyyy")}";
        }
    }
}
