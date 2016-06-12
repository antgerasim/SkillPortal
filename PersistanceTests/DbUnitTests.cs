using System.Data;
using System.Data.Common;
using System.Data.SQLite;
using System.IO;
using DomainModel;
using FluentNHibernate.Cfg;
using FluentNHibernate.Cfg.Db;
using NDbUnit.Core;
using NDbUnit.Core.SqlLite;
using NHibernate;
using NUnit.Framework;

namespace PersistanceTests
{
    [TestFixture]
    public class Tests
    {
        private ISession _session;
        private INDbUnitTest donSqlDatabase;
        private string _connectionString;
        private SQLiteConnection _connection;

        [Test]
        public void Test()
        {
            _connectionString = "Data Source=:memory:;Version=3;New=True;";

            //Create an Instance of the NDbUnit database test class
            donSqlDatabase = new SqlLiteDbUnitTest(_connectionString);

            //Tell the NDbUnit test class what schema and data files to use
            donSqlDatabase.ReadXmlSchema(@"..\..\MyDataset.xsd");
            donSqlDatabase.ReadXml(@"..\..\DonTestData.xml");

            //Delete all existing data in the database and load test data
            donSqlDatabase.PerformDbOperation(NDbUnit.Core.DbOperationFlag.CleanInsertIdentity);

            var connection = new SqlLiteDbCommandBuilder(_connectionString);
        }

        //[OneTimeSetUp]
        //public void _TestFixtureSetup()
        //{
        //    //when the fixture is setup, we configure our NDbUnit class instance and save it in the fixture
            
          

        //    _mySqlDatabase.ReadXmlSchema(@"..\..\MyDataset.xsd");
        //}

        private void ExecuteSchemaCreationScript()
        {
            IDbCommand command = _connection.CreateCommand();
            command.CommandText = ReadTextFromFile(@"scripts\sqlite-testdb-create.sql");

            if (_connection.State != ConnectionState.Open)
                _connection.Open();

            command.ExecuteNonQuery();

            command.CommandText = "Select * from Role";
            command.ExecuteReader();
        }

        private string ReadTextFromFile(string filename)
        {
            using (var sr = new StreamReader(filename))
            {
                return sr.ReadToEnd();
            }
        }
    }
}