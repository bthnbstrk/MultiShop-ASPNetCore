using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace Shop.Discount.Context
{
	public class DapperContext : DbContext
	{

		private readonly IConfiguration _configuration;

		private readonly string _connectionString;

        public DapperContext(IConfiguration configuration)
		{
            _configuration = configuration;
			_connectionString = _configuration.GetConnectionString("DefaultConnection");
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Servers=;");
        }

    }
}

