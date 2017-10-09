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
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SQLiteNullableDateTimeIssue.Models
{
    class MyDbContext : DbContext
    {
        public DbSet<Dog> Dogs { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Data Source=SQLiteNullableDateTimeIssue.db");
        }
    }
}
