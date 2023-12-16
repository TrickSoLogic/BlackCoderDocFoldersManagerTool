using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using BlackCoderDocFoldersManagerTool.Models;

namespace BlackCoderDocFoldersManagerTool.Data
{
    public class DemoDMSContext : DbContext
    {
        public DemoDMSContext(DbContextOptions<DemoDMSContext> options) : base(options) { }

        public DbSet<Folder> Folder { get; set; }

        public DbSet<Document> Document { get; set; }
    }
}