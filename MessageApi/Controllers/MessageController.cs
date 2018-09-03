using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;

namespace MessageApi.Controllers
{
    [Route("api/message")]
    
    public class MessageController : Controller // controller sends and reads messages
    {
        private readonly AppSettings _appSettings;

        public MessageController(IOptions<AppSettings> appSettings){
            _appSettings = appSettings.Value; // set config settings
        }

        // GET demo
        [HttpGet("demo")]
        public IActionResult GetDemoMessage()
        {
            try{
                return Ok("Hello World");

            }catch{
                return StatusCode(500);
            }
        }

        // GET file content from a file path
        [HttpGet("file")]
        public IActionResult GetFileMessage(string fileName, string filePath)
        {
            try{

                if(fileName == null || filePath == null){
                    return BadRequest();
                }

                FileMessengerModel messenger = new FileMessengerModel(fileName, filePath);

                string content = messenger.ReadContent();
                
                return Ok(content);

            }catch{
                return StatusCode(500);
            }
        }

        // POST writes data to a file
        [HttpPost("file")]
        public IActionResult PostFileMessage([FromBody]FileMessageBindingModel message)
        {
            try{

                if(message == null){
                    return BadRequest();
                }
                
                FileMessageDto dto = MakeFileMessageDto(message);

                FileMessengerModel messenger = new FileMessengerModel(message.fileName, message.filePath, message.content);

                bool result = messenger.WriteContent();

                return Ok(result);

            }
            catch{
                return StatusCode(500);
            }
 
        }

        // GET read data from DB based on its ID
        [HttpGet("database")]
        public IActionResult GetDatabaseMessage(int id)
        {
            try{

                if(id <= 0){
                    return BadRequest();
                }

                DatabaseMessengerModel messenger = new DatabaseMessengerModel(_appSettings, id);

                string content = messenger.ReadContent();
                
                return Ok(content);

            }catch{
                return StatusCode(500);
            }
        }

        // POST wites data to DB
        [HttpPost("database")]
        public IActionResult PostDatabaseMessage([FromBody]DatabaseMessageBindingModel message)
        {
            try{

                if(message == null){
                    return BadRequest();
                }
                
                DatabaseMessageDto dto = MakeDatabaseMessageDto(message);

                DatabaseMessengerModel messenger = new DatabaseMessengerModel(_appSettings, message.content);

                bool result = messenger.WriteContent();

                if(result == true){
                    return Ok(messenger.message); // return message to verify results
                }else{
                    return StatusCode(500);
                } 

            }
            catch{
                return StatusCode(500);
            }
 
        }

        // PUT updates DB record
        [HttpPut("database")]
        public IActionResult PutDatabaseMessage([FromBody]DatabaseMessageBindingModel message)
        {
            try{

                if(message?.id <= 0){ // id is required for PUT/ DB update to work
                    return BadRequest();
                }
                
                DatabaseMessageDto dto = MakeDatabaseMessageDto(message);

                DatabaseMessengerModel messenger = new DatabaseMessengerModel(_appSettings, message.id, message.content);

                bool result = messenger.WriteContent();

                if(result == true){
                    return Ok(messenger.message); // return message to verify results
                }else{
                    return StatusCode(500);
                } 

            }
            catch{
                return StatusCode(500);
            }
 
        }

        private FileMessageDto MakeFileMessageDto(FileMessageBindingModel model){
            
            FileMessageDto dto = new FileMessageDto();
            
            dto.fileName =  model.fileName;
            dto.filePath =  model.filePath;

            return dto;
        }

        private DatabaseMessageDto MakeDatabaseMessageDto(DatabaseMessageBindingModel model){
            
            DatabaseMessageDto dto = new DatabaseMessageDto();
            
            dto.id =  model.id;
            dto.content =  model.content;

            return dto;
        }

        private FileMessageBindingModel MakeFileMessageBindingModel(FileMessageDto dto){
            
            FileMessageBindingModel model = new FileMessageBindingModel();
            
            model.fileName =  dto.fileName;
            model.filePath =  dto.filePath;

            return model;
        }

        private DatabaseMessageBindingModel MakeDatabaseMessageBindingModel(DatabaseMessageDto dto){
            
            DatabaseMessageBindingModel model = new DatabaseMessageBindingModel();
            
            model.id =  dto.id;
            model.content =  dto.content;

            return model;
        }

    }
}
