using System;
using System.Data;
using System.Data.Common;
using System.Data.SQLite;
using System.Diagnostics;
using System.IO;
using NDbUnit.Core;
using NDbUnit.Core.SqlLite;
using NUnit.Framework;

namespace PersistanceTests
{
    [TestFixture]
    public class SqlLiteNdbUnit
    {
        //weiter mit NDBUnitXMLTestfiles
        //https://github.com/NDbUnit/NDbUnit/blob/master/test/NDbUnit.Test/SqlLite-InMemory/SQLliteInMemoryIntegrationTest.cs
        private SQLiteConnection _connection;
        private string _connectionString;

        //[TestFixtureSetUp,Ignore("ficken")]
        public void _TestFixtureSetUp()
        {
            _connectionString = "Data Source=:memory:;Version=3;New=True;";

            _connection = new SQLiteConnection(_connectionString);

            ExecuteSchemaCreationScript();
        }

        //[Test,Ignore("ficken")]
        public void Can_Get_Data_From_In_Memory_Instance()
        {
            var database = new SqlLiteDbUnitTest(_connection);

            var p = AppDomain.CurrentDomain.BaseDirectory;
            var newpath = Path.GetFullPath(Path.Combine(p, @"..\..\"));

            //var dtp = String.Concat(newpath, "DonDataSet.xsd");
            var dtp = String.Concat(newpath, "UserDs.xsd");

            //var tdp = String.Concat(newpath, "DonTestData.xml");
            var tdp = String.Concat(newpath, "User.xml");


            try
            {
                //database.ReadXmlSchema(@"..\..\MyDataset.xsd");
                database.ReadXmlSchema(dtp);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }

            //database.ReadXml(@"..\..\DonTestData.xml");
            database.ReadXml(tdp);


            database.PerformDbOperation(DbOperationFlag.CleanInsertIdentity);


            var command = _connection.CreateCommand();
            command.CommandText = "Select * from [Role]";

            var results = command.ExecuteReader();

            Assert.IsTrue(results.HasRows);

            int recordCount = 0;

            while (results.Read())
            {
                recordCount++;
                Debug.WriteLine(results.GetString(1));
            }

            Assert.AreEqual(2, recordCount);

        }

        private void ExecuteSchemaCreationScript()
        {
            IDbCommand command = _connection.CreateCommand();

            var p = AppDomain.CurrentDomain.BaseDirectory;
            var newpath = Path.GetFullPath(Path.Combine(p, @"..\..\"));
         

            var ppp = String.Concat(newpath, "scripts\\sqlite-testdb-create.sql");

            command.CommandText = ReadTextFromFile(ppp);

            if (_connection.State != ConnectionState.Open)
                _connection.Open();

            command.ExecuteNonQuery();

            command.CommandText = "Select * from Role";
            command.ExecuteReader();
        }

        private string ReadTextFromFile(string filename)
        {
            try
            {
                using (var sr = new StreamReader(filename))
                {
                    return sr.ReadToEnd();
                }
            }
            catch (Exception e)
            {
                return null;
            }
        }
    }
}