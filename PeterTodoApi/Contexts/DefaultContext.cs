using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using PeterTodoApi.Models;

namespace PeterTodoApi.Contexts
{
    public class DefaultContext : DbContext
    {
        public virtual DbSet<ProductItem> Products { get; set; }

        public DefaultContext(DbContextOptions<DefaultContext> options) :
            base(options)
        {
        }
    }
}
