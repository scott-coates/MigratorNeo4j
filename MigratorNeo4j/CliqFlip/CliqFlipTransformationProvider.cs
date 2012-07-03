using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using Migrator.Framework;
using Migrator.Framework.SchemaBuilder;
using Migrator.Providers;
using Migrator.Providers.SqlServer;
using MigratorNeo4j.Neo4j;
using Neo4jClient;
using ForeignKeyConstraint = Migrator.Framework.ForeignKeyConstraint;

namespace MigratorNeo4j.CliqFlip
{
	public class CliqFlipTransformationProvider : ITransformationProvider
	{
		private readonly Neo4jTransformationProvider _neo4JTransformationProvider;
		private readonly SqlServerTransformationProvider _sqlServerTransformationProvider;
		private bool _neoLastUsed;

		public IGraphClient GraphClient
		{
			get
			{
				_neoLastUsed = true;
				return _neo4JTransformationProvider.GraphClient;
			}
		}

		public CliqFlipTransformationProvider(Dialect dialect, string connectionString)
		{
			try
			{
				string[] strings = connectionString.Split(new[] {"|^|"}, StringSplitOptions.RemoveEmptyEntries);
				_sqlServerTransformationProvider = new SqlServerTransformationProvider(dialect, strings[0]);
				_neo4JTransformationProvider = new Neo4jTransformationProvider(dialect, strings[1]);
			}
			catch (IndexOutOfRangeException e)
			{
				throw new Exception("The connection string needs data for sql and neo4j");
			}
		}

		#region ITransformationProvider Members

		public ITransformationProvider this[string provider]
		{
			get { return _sqlServerTransformationProvider[provider]; }
		}

		public List<long> AppliedMigrations
		{
			get 
            { 
                return _sqlServerTransformationProvider.AppliedMigrations.Concat(_neo4JTransformationProvider.AppliedMigrations ?? new List<long>())
                .OrderBy(x=>x)
                .ToList(); 
            }
		}

		public ILogger Logger
		{
			get { return _sqlServerTransformationProvider.Logger; }
			set { _sqlServerTransformationProvider.Logger = value; }
		}

		public void AddColumn(string table, string column, DbType type, int size, ColumnProperty property, object defaultValue)
		{
			_sqlServerTransformationProvider.AddColumn(table, column, type, size, property, defaultValue);
		}

		public void AddColumn(string table, string column, DbType type)
		{
			_sqlServerTransformationProvider.AddColumn(table, column, type);
		}

		public void AddColumn(string table, string column, DbType type, int size)
		{
			_sqlServerTransformationProvider.AddColumn(table, column, type, size);
		}

		public void AddColumn(string table, string column, DbType type, int size, ColumnProperty property)
		{
			_sqlServerTransformationProvider.AddColumn(table, column, type, size, property);
		}

		public void AddColumn(string table, string column, DbType type, ColumnProperty property)
		{
			_sqlServerTransformationProvider.AddColumn(table, column, type, property);
		}

		public void AddColumn(string table, string column, DbType type, object defaultValue)
		{
			_sqlServerTransformationProvider.AddColumn(table, column, type, defaultValue);
		}

		public void AddColumn(string table, Column column)
		{
			_sqlServerTransformationProvider.AddColumn(table, column);
		}

		public void AddForeignKey(string name, string foreignTable, string[] foreignColumns, string primaryTable, string[] primaryColumns)
		{
			_sqlServerTransformationProvider.AddForeignKey(name, foreignTable, foreignColumns, primaryTable, primaryColumns);
		}

		public void AddForeignKey(string name, string foreignTable, string[] foreignColumns, string primaryTable, string[] primaryColumns, ForeignKeyConstraint constraint)
		{
			_sqlServerTransformationProvider.AddForeignKey(name, foreignTable, foreignColumns, primaryTable, primaryColumns, constraint);
		}

		public void AddForeignKey(string name, string foreignTable, string foreignColumn, string primaryTable, string primaryColumn)
		{
			_sqlServerTransformationProvider.AddForeignKey(name, foreignTable, foreignColumn, primaryTable, primaryColumn);
		}

		public void AddForeignKey(string name, string foreignTable, string foreignColumn, string primaryTable, string primaryColumn, ForeignKeyConstraint constraint)
		{
			_sqlServerTransformationProvider.AddForeignKey(name, foreignTable, foreignColumn, primaryTable, primaryColumn, constraint);
		}

		public void GenerateForeignKey(string foreignTable, string foreignColumn, string primaryTable, string primaryColumn)
		{
			_sqlServerTransformationProvider.GenerateForeignKey(foreignTable, foreignColumn, primaryTable, primaryColumn);
		}

		public void GenerateForeignKey(string foreignTable, string[] foreignColumns, string primaryTable, string[] primaryColumns)
		{
			_sqlServerTransformationProvider.GenerateForeignKey(foreignTable, foreignColumns, primaryTable, primaryColumns);
		}

		public void GenerateForeignKey(string foreignTable, string[] foreignColumns, string primaryTable, string[] primaryColumns, ForeignKeyConstraint constraint)
		{
			_sqlServerTransformationProvider.GenerateForeignKey(foreignTable, foreignColumns, primaryTable, primaryColumns, constraint);
		}

		public void GenerateForeignKey(string foreignTable, string foreignColumn, string primaryTable, string primaryColumn, ForeignKeyConstraint constraint)
		{
			_sqlServerTransformationProvider.GenerateForeignKey(foreignTable, foreignColumn, primaryTable, primaryColumn, constraint);
		}

		public void GenerateForeignKey(string foreignTable, string primaryTable)
		{
			_sqlServerTransformationProvider.GenerateForeignKey(foreignTable, primaryTable);
		}

		public void GenerateForeignKey(string foreignTable, string primaryTable, ForeignKeyConstraint constraint)
		{
			_sqlServerTransformationProvider.GenerateForeignKey(foreignTable, primaryTable, constraint);
		}

		public void AddPrimaryKey(string name, string table, params string[] columns)
		{
			_sqlServerTransformationProvider.AddPrimaryKey(name, table, columns);
		}

		public void AddUniqueConstraint(string name, string table, params string[] columns)
		{
			_sqlServerTransformationProvider.AddUniqueConstraint(name, table, columns);
		}

		public void AddCheckConstraint(string name, string table, string checkSql)
		{
			_sqlServerTransformationProvider.AddCheckConstraint(name, table, checkSql);
		}

		public void AddTable(string name, params Column[] columns)
		{
			_sqlServerTransformationProvider.AddTable(name, columns);
		}

		public void AddTable(string name, string engine, params Column[] columns)
		{
			_sqlServerTransformationProvider.AddTable(name, engine, columns);
		}

		public void BeginTransaction()
		{
			_sqlServerTransformationProvider.BeginTransaction();
		}

		public void ChangeColumn(string table, Column column)
		{
			_sqlServerTransformationProvider.ChangeColumn(table, column);
		}

		public bool ColumnExists(string table, string column)
		{
			return _sqlServerTransformationProvider.ColumnExists(table, column);
		}

		public void Commit()
		{
			_sqlServerTransformationProvider.Commit();
		}

		public bool ConstraintExists(string table, string name)
		{
			return _sqlServerTransformationProvider.ConstraintExists(table, name);
		}

		public bool PrimaryKeyExists(string table, string name)
		{
			return _sqlServerTransformationProvider.PrimaryKeyExists(table, name);
		}

		public int ExecuteNonQuery(string sql)
		{
			return _sqlServerTransformationProvider.ExecuteNonQuery(sql);
		}

		public IDataReader ExecuteQuery(string sql)
		{
			return _sqlServerTransformationProvider.ExecuteQuery(sql);
		}

		public object ExecuteScalar(string sql)
		{
			return _sqlServerTransformationProvider.ExecuteScalar(sql);
		}

		public Column[] GetColumns(string table)
		{
			return _sqlServerTransformationProvider.GetColumns(table);
		}

		public Column GetColumnByName(string table, string column)
		{
			return _sqlServerTransformationProvider.GetColumnByName(table, column);
		}

		public string[] GetTables()
		{
			return _sqlServerTransformationProvider.GetTables();
		}

		public int Insert(string table, string[] columns, string[] values)
		{
			return _sqlServerTransformationProvider.Insert(table, columns, values);
		}

		public int Delete(string table, string[] columns, string[] values)
		{
			return _sqlServerTransformationProvider.Delete(table, columns, values);
		}

		public int Delete(string table, string whereColumn, string whereValue)
		{
			return _sqlServerTransformationProvider.Delete(table, whereColumn, whereValue);
		}

		public void MigrationApplied(long version)
		{
			if (_neoLastUsed)
			{
				_neo4JTransformationProvider.MigrationApplied(version);
			}
			else
			{
				_sqlServerTransformationProvider.MigrationApplied(version);
			}

			_neoLastUsed = false;
		}

		public void MigrationUnApplied(long version)
		{
			if (_neoLastUsed)
			{
				_neo4JTransformationProvider.MigrationUnApplied(version);
			}
			else
			{
				_sqlServerTransformationProvider.MigrationUnApplied(version);
			}
			_neoLastUsed = false;
		}

		public void RemoveColumn(string table, string column)
		{
			_sqlServerTransformationProvider.RemoveColumn(table, column);
		}

		public void RemoveForeignKey(string table, string name)
		{
			_sqlServerTransformationProvider.RemoveForeignKey(table, name);
		}

		public void RemoveConstraint(string table, string name)
		{
			_sqlServerTransformationProvider.RemoveConstraint(table, name);
		}

		public void RemoveTable(string tableName)
		{
			_sqlServerTransformationProvider.RemoveTable(tableName);
		}

		public void RenameTable(string oldName, string newName)
		{
			_sqlServerTransformationProvider.RenameTable(oldName, newName);
		}

		public void RenameColumn(string tableName, string oldColumnName, string newColumnName)
		{
			_sqlServerTransformationProvider.RenameColumn(tableName, oldColumnName, newColumnName);
		}

		public void Rollback()
		{
			_sqlServerTransformationProvider.Rollback();
		}

		public IDataReader Select(string what, string @from, string @where)
		{
			return _sqlServerTransformationProvider.Select(what, @from, @where);
		}

		public IDataReader Select(string what, string @from)
		{
			return _sqlServerTransformationProvider.Select(what, @from);
		}

		public object SelectScalar(string what, string @from, string @where)
		{
			return _sqlServerTransformationProvider.SelectScalar(what, @from, @where);
		}

		public object SelectScalar(string what, string @from)
		{
			return _sqlServerTransformationProvider.SelectScalar(what, @from);
		}

		public bool TableExists(string tableName)
		{
			return _sqlServerTransformationProvider.TableExists(tableName);
		}

		public int Update(string table, string[] columns, string[] columnValues)
		{
			return _sqlServerTransformationProvider.Update(table, columns, columnValues);
		}

		public int Update(string table, string[] columns, string[] values, string @where)
		{
			return
				_sqlServerTransformationProvider.Update(table, columns, values, @where);
		}

		public IDbCommand GetCommand()
		{
			return
				_sqlServerTransformationProvider.GetCommand();
		}

		public void ExecuteSchemaBuilder(SchemaBuilder schemaBuilder)
		{
			_sqlServerTransformationProvider.ExecuteSchemaBuilder(schemaBuilder);
		}

		#endregion
	}
}