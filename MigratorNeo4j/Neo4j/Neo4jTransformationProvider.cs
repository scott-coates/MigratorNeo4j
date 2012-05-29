#region License

//The contents of this file are subject to the Mozilla Public License
//Version 1.1 (the "License"); you may not use this file except in
//compliance with the License. You may obtain a copy of the License at
//http://www.mozilla.org/MPL/
//Software distributed under the License is distributed on an "AS IS"
//basis, WITHOUT WARRANTY OF ANY KIND, either express or implied. See the
//License for the specific language governing rights and limitations
//under the License.

#endregion

using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using Migrator.Framework;
using Migrator.Framework.SchemaBuilder;
using Migrator.Providers;
using Neo4jClient;
using Newtonsoft.Json;
using ForeignKeyConstraint = Migrator.Framework.ForeignKeyConstraint;

namespace MigratorNeo4j.Neo4j
{
	/// <summary>
	/// Migration transformations provider for Microsoft SQL Server.
	/// </summary>
	public class Neo4jTransformationProvider : ITransformationProvider
	{
		private readonly Dialect _dialect;
		private readonly string _connectionString;
		private readonly GraphClient _graphClient;
		private List<long> _appliedMigrations;
		private Node<NeoSchemaVersion> _nodeReference;

		public Neo4jTransformationProvider(Dialect dialect, string connectionString)
		{
			_dialect = dialect;
			_connectionString = connectionString;
			_graphClient = new GraphClient(new Uri(connectionString));
			_graphClient.Connect();
		}

		public void Dispose()
		{
		}

		public ITransformationProvider this[string provider]
		{
			get { throw new NotImplementedException(); }
		}

		public List<long> AppliedMigrations
		{
			get
			{
				if (_appliedMigrations == null)
				{
					CreateSchemaInfoTable();
					_appliedMigrations = _nodeReference.Data.Migrations ?? new List<long>();
				}

				return _appliedMigrations;
			}
		}

		public ILogger Logger { get; set; }

		public IGraphClient GraphClient
		{
			get { return _graphClient; }
		}

		public void AddColumn(string table, string column, DbType type, int size, ColumnProperty property, object defaultValue)
		{
			throw new NotImplementedException();
		}

		public void AddColumn(string table, string column, DbType type)
		{
			throw new NotImplementedException();
		}

		public void AddColumn(string table, string column, DbType type, int size)
		{
			throw new NotImplementedException();
		}

		public void AddColumn(string table, string column, DbType type, int size, ColumnProperty property)
		{
			throw new NotImplementedException();
		}

		public void AddColumn(string table, string column, DbType type, ColumnProperty property)
		{
			throw new NotImplementedException();
		}

		public void AddColumn(string table, string column, DbType type, object defaultValue)
		{
			throw new NotImplementedException();
		}

		public void AddColumn(string table, Column column)
		{
			throw new NotImplementedException();
		}

		public void AddForeignKey(string name, string foreignTable, string[] foreignColumns, string primaryTable, string[] primaryColumns)
		{
			throw new NotImplementedException();
		}

		public void AddForeignKey(string name, string foreignTable, string[] foreignColumns, string primaryTable, string[] primaryColumns, ForeignKeyConstraint constraint)
		{
			throw new NotImplementedException();
		}

		public void AddForeignKey(string name, string foreignTable, string foreignColumn, string primaryTable, string primaryColumn)
		{
			throw new NotImplementedException();
		}

		public void AddForeignKey(string name, string foreignTable, string foreignColumn, string primaryTable, string primaryColumn, ForeignKeyConstraint constraint)
		{
			throw new NotImplementedException();
		}

		public void GenerateForeignKey(string foreignTable, string foreignColumn, string primaryTable, string primaryColumn)
		{
			throw new NotImplementedException();
		}

		public void GenerateForeignKey(string foreignTable, string[] foreignColumns, string primaryTable, string[] primaryColumns)
		{
			throw new NotImplementedException();
		}

		public void GenerateForeignKey(string foreignTable, string[] foreignColumns, string primaryTable, string[] primaryColumns, ForeignKeyConstraint constraint)
		{
			throw new NotImplementedException();
		}

		public void GenerateForeignKey(string foreignTable, string foreignColumn, string primaryTable, string primaryColumn, ForeignKeyConstraint constraint)
		{
			throw new NotImplementedException();
		}

		public void GenerateForeignKey(string foreignTable, string primaryTable)
		{
			throw new NotImplementedException();
		}

		public void GenerateForeignKey(string foreignTable, string primaryTable, ForeignKeyConstraint constraint)
		{
			throw new NotImplementedException();
		}

		public void AddPrimaryKey(string name, string table, params string[] columns)
		{
			throw new NotImplementedException();
		}

		public void AddUniqueConstraint(string name, string table, params string[] columns)
		{
			throw new NotImplementedException();
		}

		public void AddCheckConstraint(string name, string table, string checkSql)
		{
			throw new NotImplementedException();
		}

		public void AddTable(string name, params Column[] columns)
		{
			throw new NotImplementedException();
		}

		public void AddTable(string name, string engine, params Column[] columns)
		{
			throw new NotImplementedException();
		}

		public void BeginTransaction()
		{

		}

		public void ChangeColumn(string table, Column column)
		{
			throw new NotImplementedException();
		}

		public bool ColumnExists(string table, string column)
		{
			throw new NotImplementedException();
		}

		public void Commit()
		{

		}

		public bool ConstraintExists(string table, string name)
		{
			throw new NotImplementedException();
		}

		public bool PrimaryKeyExists(string table, string name)
		{
			throw new NotImplementedException();
		}

		public int ExecuteNonQuery(string sql)
		{
			throw new NotImplementedException();
		}

		public IDataReader ExecuteQuery(string sql)
		{
			throw new NotImplementedException();
		}

		public object ExecuteScalar(string sql)
		{
			throw new NotImplementedException();
		}

		public Column[] GetColumns(string table)
		{
			throw new NotImplementedException();
		}

		public Column GetColumnByName(string table, string column)
		{
			throw new NotImplementedException();
		}

		public string[] GetTables()
		{
			throw new NotImplementedException();
		}

		public int Insert(string table, string[] columns, string[] values)
		{
			throw new NotImplementedException();
		}

		public int Delete(string table, string[] columns, string[] values)
		{
			throw new NotImplementedException();
		}

		public int Delete(string table, string whereColumn, string whereValue)
		{
			throw new NotImplementedException();
		}

		public void MigrationApplied(long version)
		{
			_graphClient.Update(_nodeReference.Reference,nodeFromDb =>nodeFromDb.Add(version));
		}

		public void MigrationUnApplied(long version)
		{
			_graphClient.Update(_nodeReference.Reference, nodeFromDb => nodeFromDb.Remove(version));
		}

		public void RemoveColumn(string table, string column)
		{
			throw new NotImplementedException();
		}

		public void RemoveForeignKey(string table, string name)
		{
			throw new NotImplementedException();
		}

		public void RemoveConstraint(string table, string name)
		{
			throw new NotImplementedException();
		}

		public void RemoveTable(string tableName)
		{
			throw new NotImplementedException();
		}

		public void RenameTable(string oldName, string newName)
		{
			throw new NotImplementedException();
		}

		public void RenameColumn(string tableName, string oldColumnName, string newColumnName)
		{
			throw new NotImplementedException();
		}

		public void Rollback()
		{
		}

		public IDataReader Select(string what, string @from, string @where)
		{
			throw new NotImplementedException();
		}

		public IDataReader Select(string what, string @from)
		{
			throw new NotImplementedException();
		}

		public object SelectScalar(string what, string @from, string @where)
		{
			throw new NotImplementedException();
		}

		public object SelectScalar(string what, string @from)
		{
			throw new NotImplementedException();
		}

		public bool TableExists(string tableName)
		{
			throw new NotImplementedException();
		}

		public int Update(string table, string[] columns, string[] columnValues)
		{
			throw new NotImplementedException();
		}

		public int Update(string table, string[] columns, string[] values, string @where)
		{
			throw new NotImplementedException();
		}

		public IDbCommand GetCommand()
		{
			throw new NotImplementedException();
		}

		public void ExecuteSchemaBuilder(SchemaBuilder schemaBuilder)
		{
			throw new NotImplementedException();
		}

		private void CreateSchemaInfoTable()
		{
			var schemaInfoNode = _graphClient
				.RootNode
				.StartCypher("n")
				.Match("n <-[:SCHEMA_INFO_BELONGS_TO]-(x)")
				.Return<Node<NeoSchemaVersion>>("x")
				.ResultSet.FirstOrDefault();

			if (schemaInfoNode == null)
			{
				var reference = _graphClient.Create(new NeoSchemaVersion(), new[] { new SchemaInfoBelongsTo(_graphClient.RootNode) });
				_nodeReference = _graphClient.Get(reference);
			}
			else
			{
				_nodeReference = schemaInfoNode;
			}
		}

		public class NeoSchemaVersion
		{
			[JsonProperty("SchemaVersion", NullValueHandling = NullValueHandling.Ignore, DefaultValueHandling = DefaultValueHandling.Ignore)]
			public List<long> Migrations { get; set; }

			public void Remove(long version)
			{
				InitCollection();
				Migrations.Remove(version);
			}

			public void Add(long version)
			{
				InitCollection();
				Migrations.Add(version);
			}

			private void InitCollection()
			{
				if(Migrations == null)
				{
					Migrations = new List<long>();
				}
			}
		}


		[AttributeUsage(AttributeTargets.Method | AttributeTargets.Class, AllowMultiple = false, Inherited = false)]
		public sealed class NeoMigration : Attribute
		{
		}

		public class SchemaInfoBelongsTo : Relationship,
									 IRelationshipAllowingSourceNode<NeoSchemaVersion>,
									 IRelationshipAllowingTargetNode<RootNode>
		{
			public const string TypeKey = "SCHEMA_INFO_BELONGS_TO";

			public override string RelationshipTypeKey
			{
				get { return TypeKey; }
			}

			public SchemaInfoBelongsTo(NodeReference targetNode)
				: base(targetNode)
			{
			}
		}
	}
}
