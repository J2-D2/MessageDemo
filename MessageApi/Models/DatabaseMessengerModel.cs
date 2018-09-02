using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Options;

namespace MessageApi
{
    public class DatabaseMessengerModel : IMessenger // writes and reads messages/ data from a DB
    {
        private readonly AppSettings _appSettings;

        public DatabaseMessageDto message { get; set; }     

        public bool WriteContent(){ // writes to DB

            string connString = _appSettings.DBConnectionString; // example of getting connection string for appsettings
            // connect to db, write data and return result

            int dbSaveResult = 1;
            message.id = dbSaveResult;
            return true;
        }

        public string ReadContent(){ // reads from DB
            
            string connString = _appSettings.DBConnectionString; // example of getting connection string for appsettings
            // connect to db, read data and return result

            return "hello world";
        }

        public DatabaseMessengerModel(AppSettings appSettings, int id){ // constructor for getting data
            _appSettings = appSettings;
            message = new DatabaseMessageDto();
            message.id = id;
            message.content = null;
        }

        public DatabaseMessengerModel(AppSettings appSettings, string content){ // constructor for saving data
            _appSettings = appSettings;
            message = new DatabaseMessageDto();
            message.id = null;
            message.content = content;
        }

        public DatabaseMessengerModel(AppSettings appSettings, int? id, string content){ // constructor for updating data
            _appSettings = appSettings;
            message = new DatabaseMessageDto();
            message.id = id;
            message.content = content;
        }
        
    }
}