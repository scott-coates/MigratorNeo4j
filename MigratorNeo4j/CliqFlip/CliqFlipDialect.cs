using System;
using Migrator.Providers.SqlServer;

namespace MigratorNeo4j.CliqFlip
{
	public class CliqFlipDialect : SqlServer2005Dialect
	{
		public override Type TransformationProvider
		{
			get { return typeof (CliqFlipTransformationProvider); }
		}
	}
}