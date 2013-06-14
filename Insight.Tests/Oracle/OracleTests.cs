﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Insight.Database;
using NUnit.Framework;

namespace Insight.Tests.Oracle
{
	/// <summary>
	/// Oracle-specific tests.
	/// </summary>
	[TestFixture]
	public class OracleTests : BaseDbTest
	{
		[Test]
		public void ExecuteSql()
		{
			_connection.QuerySql<decimal>("SELECT 1 as p FROM dual");
		}

		[Test]
		public void ExecuteProcedure()
		{
			try
			{
				_connection.ExecuteSql("CREATE PROCEDURE OracleTestProc (i int) IS BEGIN null; END;");
				_connection.Execute("OracleTestProc", new { i = 5 });
			}
			finally
			{
				_connection.ExecuteSql("DROP PROCEDURE OracleTestProc");
			}
		}
	}
}
