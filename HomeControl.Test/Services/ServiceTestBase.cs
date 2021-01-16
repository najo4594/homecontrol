using System;
using System.Data.Common;
using HomeControl.DataAccess;
using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;

namespace HomeControl.Test.Services
{
	public class ServiceTestBase : IDisposable
	{
		private readonly DbConnection _connection;
		protected readonly HomeControlContext Context;

		protected ServiceTestBase()
		{
			DbContextOptions<HomeControlContext> homeControlContextOptions = new DbContextOptionsBuilder<HomeControlContext>()
				.UseSqlite(CreateInMemoryDatabase())
				.Options;
			_connection = RelationalOptionsExtension.Extract(homeControlContextOptions).Connection;

			Context = new HomeControlContext(homeControlContextOptions);
			Context.Database.EnsureCreated();
		}

		private static DbConnection CreateInMemoryDatabase()
		{
			var connection = new SqliteConnection("Filename=:memory:");
			connection.Open();
			return connection;
		}

		public void Dispose()
		{
			_connection.Dispose();
		}
	}
}